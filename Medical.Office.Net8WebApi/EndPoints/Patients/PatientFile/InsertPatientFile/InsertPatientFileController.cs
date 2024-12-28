using MediatR;
using Common.Common.CleanArch;
using Microsoft.AspNetCore.Mvc;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.FilesPatients.InsertPatientFile;
using System.Diagnostics;
using System.Runtime;
using Microsoft.AspNetCore.Authorization;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.PatientFile.InsertPatientFile
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class InsertPatientFileController : ControllerBase
    {
        private readonly ILogger<InsertPatientFileController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertPatientFileController> _viewModel;
        // Diccionario para almacenar temporalmente los chunks
        private static readonly Dictionary<string, List<byte[]>> FileChunks = new();

        public InsertPatientFileController(ILogger<InsertPatientFileController> logger, IMediator mediator, GenericViewModel<InsertPatientFileController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        #region Original - Archivos con un limite de 1.8 GB de peso, Consume un maximo de 6.9 GB de ram en archivos de 1.8 GB en su pico mas alto, en promedio se mantiene entre 1 y 2 GB de ram.
        [HttpPost("/api/UploadPatientFile")]
        public async Task<IActionResult> Execute([FromBody] InsertPatientFileRequestBody requestBody)
        {

            if (requestBody == null || string.IsNullOrEmpty(requestBody.FileData))
            {
                return BadRequest("Invalid chunk data.");
            }

            // Decodificar los datos del chunk desde Base64
            try
            {
                var chunkData = Convert.FromBase64String(requestBody.FileData);

                // Generar clave única para el archivo basado en IDPatient y FileName
                var fileKey = $"{requestBody.IDPatient}_{requestBody.FileName}";

                // Asegurar que exista una lista para almacenar los chunks
                if (!FileChunks.ContainsKey(fileKey))
                {
                    FileChunks[fileKey] = new List<byte[]>();
                }

                // Agregar el chunk a la lista
                FileChunks[fileKey].Add(chunkData);

                // Si este es el último chunk, ensamblar y procesar el archivo
                if (requestBody.ChunkIndex == requestBody.TotalChunks - 1)
                {
                    var stopwatch = Stopwatch.StartNew();
                    // Ensamblar los chunks
                    var fileData = CombineChunks(FileChunks[fileKey]);

                    // Limpiar los datos temporales
                    // Limpiar los datos temporales
                    FileChunks[fileKey].Clear();
                    FileChunks.Remove(fileKey);

                    // Crear el objeto PatientsFilesDto
                    var patientsFilesDto = new PatientsFilesDto(
                        0, // ID (autogenerado)
                        requestBody.IDPatient,
                        requestBody.FileName,
                        requestBody.FileType,
                        requestBody.FileExtension,
                        requestBody.Description,
                        fileData,
                        DateTime.UtcNow
                    );

                    // Crear la solicitud InsertPatientFileRequest
                    var request = new InsertPatientFileRequest(patientsFilesDto);
                    _ = await _mediator.Send(request).ConfigureAwait(false);

                    // Liberar memoria usada por grandes objetos
                    fileData = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                    GC.Collect();


                    // Procesos...
                    _logger.LogInformation($"Tiempo de ensamblado: {stopwatch.ElapsedMilliseconds / 1000.0:F2} segundos");
                    stopwatch.Restart();

                    return _viewModel.IsSuccess ? Ok(_viewModel) : StatusCode(500, _viewModel);
                }

                //_logger.LogInformation($"Chunk {requestBody.ChunkIndex} de {requestBody.TotalChunks} restantes {requestBody.TotalChunks - requestBody.ChunkIndex} uploaded successfully.");

                //return Ok(new { Message = "Chunk uploaded successfully." });
                return Ok(new { Message = $"Chunk {requestBody.ChunkIndex} de {requestBody.TotalChunks} restantes {requestBody.TotalChunks - requestBody.ChunkIndex} uploaded successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading patient file.");
                var innerEx = ex;
                while (innerEx.InnerException != null) innerEx = innerEx.InnerException!;
                return StatusCode(500, _viewModel.Fail(innerEx.Message));
            }
        }

        private static byte[] CombineChunks(List<byte[]> chunks)
        {
            using var memoryStream = new MemoryStream();
            foreach (var chunk in chunks)
            {
                memoryStream.Write(chunk, 0, chunk.Length);
            }
            return memoryStream.ToArray();
        }
        #endregion

        #region Metodo File.ReadAllBytesAsync Limite 2.0 GB Consume hata 9 GB de ram
        /// <summary>
        /// Este metodo es mas lento, y solo soporta maximo 2GB por archivo
        /// Tiempo de inserción en SQL: 52.03 Segundos
        /// Tiempo de ensamblado y lectura del archivo temporal en C:\Users\rarriaga\AppData\Local\Temp\06b0c09f-7c0f-4cd8-bb24-b8a672ddb839_File test size 500 MB.rar: 48.90 segundos
        /// El error The file is too long. This operation is currently limited to supporting files less than 2 gigabytes in size ocurre porque el método File.ReadAllBytesAsync tiene un límite de 2 GB al trabajar con archivos
        /// </summary>
        /// <param name="requestBody">
        /// </param>
        /// <returns></returns>
        //[HttpPost("/api/UploadPatientFile")]
        //public async Task<IActionResult> Execute([FromBody] InsertPatientFileRequestBody requestBody)
        //{
        //    if (requestBody == null || string.IsNullOrEmpty(requestBody.FileData))
        //    {
        //        return BadRequest("Invalid chunk data.");
        //    }

        //    try
        //    {
        //        // Decodificar los datos del chunk desde Base64
        //        var chunkData = Convert.FromBase64String(requestBody.FileData);

        //        // Generar clave única para el archivo basado en IDPatient y FileName
        //        var fileKey = $"{requestBody.IDPatient}_{requestBody.FileName}";

        //        // Asegurar que exista una lista para almacenar los chunks
        //        if (!FileChunks.ContainsKey(fileKey))
        //        {
        //            FileChunks[fileKey] = new List<byte[]>();
        //        }

        //        // Agregar el chunk a la lista
        //        FileChunks[fileKey].Add(chunkData);

        //        // Si este es el último chunk, ensamblar y procesar el archivo
        //        if (requestBody.ChunkIndex == requestBody.TotalChunks - 1)
        //        {
        //            var stopwatch = Stopwatch.StartNew();
        //            // Ruta para el archivo temporal ensamblado
        //            var tempFilePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_{requestBody.FileName}");

        //            // Ensamblar los chunks en un archivo en disco
        //            CombineChunksToFile(FileChunks[fileKey], tempFilePath);

        //            // Limpiar los datos temporales
        //            FileChunks.Remove(fileKey);

        //            // Leer los datos ensamblados desde el archivo para insertarlos en la base de datos
        //            var fileData = await System.IO.File.ReadAllBytesAsync(tempFilePath);

        //            // Crear el objeto PatientsFilesDto
        //            var patientsFilesDto = new PatientsFilesDto(
        //                0, // ID (autogenerado)
        //                requestBody.IDPatient,
        //                requestBody.FileName,
        //                requestBody.FileType,
        //                requestBody.FileExtension,
        //                requestBody.Description,
        //                fileData,
        //                DateTime.UtcNow
        //            );

        //            // Crear la solicitud InsertPatientFileRequest
        //            var request = new InsertPatientFileRequest(patientsFilesDto);

        //            // Enviar la solicitud al handler
        //            var response = await _mediator.Send(request).ConfigureAwait(false);

        //            // Eliminar el archivo temporal
        //            System.IO.File.Delete(tempFilePath);

        //            _logger.LogInformation($"Tiempo de ensamblado o lectura del archivo temporal en {tempFilePath}: {stopwatch.ElapsedMilliseconds / 1000.0:F2} segundos");
        //            stopwatch.Restart();
        //            return _viewModel.IsSuccess ? Ok(_viewModel) : StatusCode(500, _viewModel);
        //        }

        //        return Ok(new { Message = "Chunk uploaded successfully." });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error uploading patient file.");
        //        return StatusCode(500, new { Message = "Error uploading patient file.", Details = ex.Message });
        //    }
        //}
        //private static string CombineChunksToFile(List<byte[]> chunks, string outputFilePath)
        //{
        //    try
        //    {
        //        // Crear o sobrescribir el archivo de salida
        //        using (var fileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
        //        {
        //            foreach (var chunk in chunks)
        //            {
        //                fileStream.Write(chunk, 0, chunk.Length); // Escribir cada chunk en el archivo
        //            }
        //        }

        //        return outputFilePath; // Retornar la ruta del archivo ensamblado
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new IOException("Error combinando los chunks en el archivo.", ex);
        //    }
        //}
        #endregion

        #region Metodo FileStream limite menos de 2.0 GB el menos recomendable hata mas 9 GB de ram
        //[HttpPost("/api/UploadPatientFile")]
        //public async Task<IActionResult> Execute([FromBody] InsertPatientFileRequestBody requestBody)
        //{
        //    if (requestBody == null || string.IsNullOrEmpty(requestBody.FileData))
        //    {
        //        return BadRequest("Invalid chunk data.");
        //    }

        //    try
        //    {
        //        // Decodificar los datos del chunk desde Base64
        //        var chunkData = Convert.FromBase64String(requestBody.FileData);

        //        // Generar clave única para el archivo basado en IDPatient y FileName
        //        var fileKey = $"{requestBody.IDPatient}_{requestBody.FileName}";

        //        // Asegurar que exista una lista para almacenar los chunks
        //        if (!FileChunks.ContainsKey(fileKey))
        //        {
        //            FileChunks[fileKey] = new List<byte[]>();
        //        }

        //        // Agregar el chunk a la lista
        //        FileChunks[fileKey].Add(chunkData);


        //        // Si este es el último chunk, ensamblar y procesar el archivo
        //        if (requestBody.ChunkIndex == requestBody.TotalChunks - 1)
        //        {
        //            var stopwatch = Stopwatch.StartNew();
        //            // Ruta para el archivo temporal ensamblado
        //            var tempFilePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_{requestBody.FileName}");

        //            // Ensamblar los chunks en un archivo
        //            using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
        //            {
        //                foreach (var chunk in FileChunks[fileKey])
        //                {
        //                    await fileStream.WriteAsync(chunk, 0, chunk.Length);
        //                }
        //            }

        //            // Limpiar los datos temporales
        //            FileChunks.Remove(fileKey);

        //            // Leer y procesar el archivo en chunks sin cargar todo el archivo en memoria
        //            using (var fileStream = new FileStream(tempFilePath, FileMode.Open, FileAccess.Read, FileShare.None))
        //            {

        //                const int bufferSize = 1 * 1024 * 1024; // Leer en chunks de 1 MB
        //                var buffer = new byte[bufferSize];
        //                int bytesRead;

        //                using (var memoryStream = new MemoryStream())
        //                {
        //                    while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
        //                    {
        //                        memoryStream.Write(buffer, 0, bytesRead);
        //                    }

        //                    // Convertir el contenido del MemoryStream a un arreglo final
        //                    var fileData = memoryStream.ToArray();

        //                    // Crear el objeto PatientsFilesDto
        //                    var patientsFilesDto = new PatientsFilesDto(
        //                        0, // ID (autogenerado)
        //                        requestBody.IDPatient,
        //                        requestBody.FileName,
        //                        requestBody.FileType,
        //                        requestBody.FileExtension,
        //                        requestBody.Description,
        //                        fileData,
        //                        DateTime.UtcNow
        //                    );

        //                    // Crear la solicitud InsertPatientFileRequest
        //                    var request = new InsertPatientFileRequest(patientsFilesDto);

        //                    // Enviar la solicitud al handler
        //                    var response = await _mediator.Send(request).ConfigureAwait(false);

        //                    // Eliminar el archivo temporal
        //                    System.IO.File.Delete(tempFilePath);

        //                    _logger.LogInformation($"Tiempo de ensamblado o lectura del archivo temporal en {tempFilePath}: {stopwatch.ElapsedMilliseconds / 1000.0:F2} segundos");
        //                    stopwatch.Restart();
        //                    return _viewModel.IsSuccess ? Ok(_viewModel) : StatusCode(500, _viewModel);
        //                }
        //            }
        //        }

        //        return Ok(new { Message = "Chunk uploaded successfully." });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error uploading patient file.");
        //        return StatusCode(500, new { Message = "Error uploading patient file.", Details = ex.Message });
        //    }
        //}
        ///*
        // * Manejo de archivos grandes (más de 2 GB):

        //Ya no estás limitado por la memoria o los límites del método ReadAllBytesAsync.
        //Eficiencia:

        //Al usar FileStream, solo usas la memoria necesaria para procesar partes del archivo.
        //Escalabilidad:

        //Esta solución permite manejar múltiples solicitudes sin consumir demasiados recursos.
        // */
        #endregion 
    }
}

