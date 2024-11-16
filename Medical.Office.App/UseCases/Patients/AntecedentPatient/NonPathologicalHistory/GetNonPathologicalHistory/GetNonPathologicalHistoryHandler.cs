using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.NonPathologicalHistory;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.GetNonPathologicalHistory.Responses;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.GetPathologicalBackground.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.GetNonPathologicalHistory
{
    internal sealed class GetNonPathologicalHistoryHandler : IInteractor<GetNonPathologicalHistoryRequest, GetNonPathologicalHistoryResponse>
    {
        private readonly ILogger<GetNonPathologicalHistoryHandler> _logger;
        private readonly IAntecedentPatient _antecedent;

        public GetNonPathologicalHistoryHandler(ILogger<GetNonPathologicalHistoryHandler> logger, IAntecedentPatient antecedent)
        {
            _logger=logger;
            _antecedent=antecedent;
        }
        public async Task<GetNonPathologicalHistoryResponse> Handle(GetNonPathologicalHistoryRequest request, CancellationToken cancellationToken)
        {
            var NonPathologicalHistory = await _antecedent.GetNonPathologicalHistoryByPatientIdAsync(request.IdPatient).ConfigureAwait(false);
            if (NonPathologicalHistory == null)
            {
                return new FailureGetNonPathologicalHistoryResponse("No se encontro informacion para este paciente");
            }
            return new SuccessGetNonPathologicalHistoryResponse(new NonPathologicalHistoryDto(NonPathologicalHistory.Id,
                NonPathologicalHistory.IDPatient,
                NonPathologicalHistory.PhysicalActivity,
                NonPathologicalHistory.Smoking,
                NonPathologicalHistory.Alcoholism,
                NonPathologicalHistory.SubstanceAbuse,
                NonPathologicalHistory.SubstanceAbuseData,
                NonPathologicalHistory.RecentVaccination,
                NonPathologicalHistory.RecentVaccinationData,
                NonPathologicalHistory.Others,
                NonPathologicalHistory.OthersData,
                NonPathologicalHistory.DateTimeSnap));
        }
    }
}
