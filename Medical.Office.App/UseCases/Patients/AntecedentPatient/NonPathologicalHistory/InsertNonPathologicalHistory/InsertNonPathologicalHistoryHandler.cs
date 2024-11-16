using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.NonPathologicalHistory;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.InsertNonPathologicalHistory.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.InsertNonPathologicalHistory
{
    internal sealed class InsertNonPathologicalHistoryHandler : IInteractor<InsertNonPathologicalHistoryRequest, InsertNonPathologicalHistoryResponse>
    {
        private readonly ILogger<InsertNonPathologicalHistoryHandler> _logger;
        private readonly IAntecedentPatient _antecedent;

        public InsertNonPathologicalHistoryHandler(ILogger<InsertNonPathologicalHistoryHandler> logger, IAntecedentPatient antecedent)
        {
            _logger=logger;
            _antecedent=antecedent;
        }

        public async Task<InsertNonPathologicalHistoryResponse> Handle(InsertNonPathologicalHistoryRequest request, CancellationToken cancellationToken)
        {
            var NonPathologicalHistory = await _antecedent.GetNonPathologicalHistoryByPatientIdAsync(request.IDPatient).ConfigureAwait(false);
            if (NonPathologicalHistory != null)
            {
                return new FailureInsertNonPathologicalHistoryResponse("Este paciente ya cuenta con un registro");
            }

            await _antecedent.InsertNonPathologicalHistoryAsync(
            request.IDPatient,
            request.PhysicalActivity.HasValue ? (request.PhysicalActivity.Value ? 1 : 0) : (int?)null,
            request.Smoking.HasValue ? (request.Smoking.Value ? 1 : 0) : (int?)null,
            request.Alcoholism.HasValue ? (request.Alcoholism.Value ? 1 : 0) : (int?)null,
            request.SubstanceAbuse.HasValue ? (request.SubstanceAbuse.Value ? 1 : 0) : (int?)null,
            request.SubstanceAbuseData,
            request.RecentVaccination.HasValue ? (request.RecentVaccination.Value ? 1 : 0) : (int?)null,
            request.RecentVaccinationData,
            request.Others.HasValue ? (request.Others.Value ? 1 : 0) : (int?)null,
            request.OthersData
            ).ConfigureAwait(false);

            NonPathologicalHistory = await _antecedent.GetNonPathologicalHistoryByPatientIdAsync(request.IDPatient).ConfigureAwait(false);
            return new SuccessInsertNonPathologicalHistoryResponse(new NonPathologicalHistoryDto(
                NonPathologicalHistory.Id,
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
