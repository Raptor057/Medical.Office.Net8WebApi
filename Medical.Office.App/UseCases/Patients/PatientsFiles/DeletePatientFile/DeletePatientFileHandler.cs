using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.FilesPatients.DeletePatientFile.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.FilesPatients.DeletePatientFile;

internal sealed class DeletePatientFileHandler : IInteractor<DeletePatientFileRequest, DeletePatientFileResponse>
{
    private readonly ILogger<DeletePatientFileHandler> _logger;
    private readonly IPatientsData _patientsData;

    public DeletePatientFileHandler(ILogger<DeletePatientFileHandler> logger, IPatientsData patientsData)
    {
        _logger = logger;
        _patientsData = patientsData;
    }
    
    public async Task<DeletePatientFileResponse> Handle(DeletePatientFileRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("DeletePatientFileHandler Started");
        _patientsData.DeletePatientFileAsync(request.IDPatient, request.Id).ConfigureAwait(false);
        _logger.LogInformation("DeletePatientFileHandler Completed");
        return new SucessDeletePatientFileResponse($"Archivo borrado correctamente");
    }
}