using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.FilesPatients.GetPatientFile.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.FilesPatients.GetPatientFile;

internal sealed class GetPatientFileHandler : IInteractor<GetPatientFileRequest, GetPatientFileResponse>
{
    private readonly ILogger<GetPatientFileHandler> _logger;
    private readonly IPatientsData _patientsData;

    public GetPatientFileHandler(ILogger<GetPatientFileHandler> logger, IPatientsData patientsData)
    {
        _logger = logger;
        _patientsData = patientsData;

    }
    public async Task<GetPatientFileResponse> Handle(GetPatientFileRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == 0)
        {
            // Obtener la lista de archivos del paciente
            var patientFileList = await _patientsData.GetPatientsFilesListAsync(request.IDPatient).ConfigureAwait(false);

            // Mapear a DTOs
            var filesDto = patientFileList.Select(p => new PatientsFilesDto(p.Id,p.IDPatient,p.FileName,p.FileType,p.FileExtension,p.Description,new Byte[0],p.DateTimeUploaded));

            // Retornar la respuesta exitosa
            _logger.LogInformation($"Lista de archivos del paciente {request.IDPatient} obtenida con exito.");
            return new SuccessGetPatientFilesListResponse(filesDto);
        }
        else if (request.Id > 0)
        {
            // Obtener el archivo del paciente por ID
            var patientFile = await _patientsData.GetPatientFileByIDPatientAndIdAsync(request.IDPatient, request.Id).ConfigureAwait(false);

            if (patientFile == null)
            {
                // Manejo de error en caso de no encontrar el archivo
                _logger.LogError("Patient File not found");
                throw new Exception($"No se encontró el archivo con Id {request.Id} para el paciente {request.IDPatient}.");
            }

            // Mapear a DTO
            var fileDto = new PatientsFilesDto(patientFile.Id,patientFile.IDPatient,patientFile.FileName,patientFile.FileType,patientFile.FileExtension,patientFile.Description,patientFile.FileData,patientFile.DateTimeUploaded);

            // Retornar la respuesta exitosa
            _logger.LogInformation($"Archivo {patientFile.Id}: {patientFile.FileName} obtenido");
            return new SuccessGetPatientFileResponse(fileDto);
        }
        return new FailureGetPatientFileResponse("Error al obtener el archivo o la lista de archivos");
    }
}