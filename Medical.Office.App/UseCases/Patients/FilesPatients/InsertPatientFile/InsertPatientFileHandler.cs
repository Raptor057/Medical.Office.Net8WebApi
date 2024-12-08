using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.FilesPatients.InsertPatientFile.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

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
    public Task<InsertPatientFileResponse> Handle(InsertPatientFileRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
