using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.FamilyHistory;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.GetFamilyHistory.Responses;
using Medical.Office.Domain.Entities.MedicalOffice.AntecedentPatient;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.GetFamilyHistory
{
    internal sealed class GetFamilyHistoryHandler : IInteractor<GetFamilyHistoryRequest,GetFamilyHistoryResponse>
    {
        private readonly ILogger<GetFamilyHistoryHandler> _logger;
        private readonly IAntecedentPatient _antecedent;

        public GetFamilyHistoryHandler(ILogger<GetFamilyHistoryHandler> logger, IAntecedentPatient antecedent) 
        {
            _logger=logger;
            _antecedent=antecedent;
        }

        public async Task<GetFamilyHistoryResponse> Handle(GetFamilyHistoryRequest request, CancellationToken cancellationToken)
        {
            var FamilyHistory = await _antecedent.GetFamilyHistoryByPatientIdAsync(request.IdPatient).ConfigureAwait(false);
            if (FamilyHistory == null) 
            {
                return new FailureGetFamilyHistoryResponse("No se encontro informacion para este paciente");
            }

            return new SuccessGetFamilyHistoryResponse(new FamilyHistoryDto(FamilyHistory.Id,
                FamilyHistory.IDPatient,
                FamilyHistory.Diabetes.HasValue ? (FamilyHistory.Diabetes.Value ? 1 : 0) : (int?)null,
                FamilyHistory.Cardiopathies.HasValue ? (FamilyHistory.Cardiopathies.Value ? 1 : 0) : (int?)null,
                FamilyHistory.Hypertension.HasValue ? (FamilyHistory.Hypertension.Value ? 1 : 0) : (int?)null,
                FamilyHistory.ThyroidDiseases.HasValue ? (FamilyHistory.ThyroidDiseases.Value ? 1 : 0) : (int?)null,
                FamilyHistory.ChronicKidneyDisease.HasValue ? (FamilyHistory.ChronicKidneyDisease.Value ? 1 : 0) : (int?)null,
                FamilyHistory.Others.HasValue ? (FamilyHistory.Others.Value ? 1 : 0) : (int?)null,
                FamilyHistory.OthersData ?? "",
                FamilyHistory.DateTimeSnap));
        }
    }
}
