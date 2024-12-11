using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.FilesPatients.InsertPatientFile.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Medical.Office.App.UseCases.Patients.FilesPatients.InsertPatientFile;

internal sealed class InsertPatientFileHandler : IInteractor<InsertPatientFileRequest, InsertPatientFileResponse>
{
    private readonly ILogger<InsertPatientFileHandler> _logger;
    private readonly IPatientsData _patientsData;

    public InsertPatientFileHandler(ILogger<InsertPatientFileHandler> logger, IPatientsData patientsData)
    {
        _logger = logger;
        _patientsData = patientsData;
    }
    public async Task<InsertPatientFileResponse> Handle(InsertPatientFileRequest request, CancellationToken cancellationToken)
    {
        if (request.PatientsFilesData == null)
            return new FailureInsertPatientFileResponse("No se recibio el archivo correctamente, intenta nuevamente.");

        var FileData = request.PatientsFilesData;
        

        try
        {
            var stopwatch = Stopwatch.StartNew();
            await _patientsData.InsertPatientFileAsync(
                FileData.IDPatient,
                FileData.FileName,
                FileData.FileType,
                FileData.FileExtension,
                FileData.Description,
                FileData.FileData,
                DateTime.UtcNow
            );

            // Si todo est� bien, calcular el tama�o en MB y retornar �xito
            double sizeInMB = FileData.FileData.LongLength / (1024.0 * 1024.0);


            // Inserci�n en la base de datos...
            _logger.LogInformation($"Tiempo de inserci�n: {stopwatch.ElapsedMilliseconds / 1000.0:F2} Segundos");
            stopwatch.Restart();

            return new SuccessInsertPatientFileResponse($"Archivo subido exitosamente: {sizeInMB:F2} MB");
        }
        catch (Exception ex) 
        {
            return new FailureInsertPatientFileResponse(ex.Message);
        }
    }
}
