using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.FamilyHistory;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.InsertFamilyHistory.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.InsertFamilyHistory
{
    internal class InsertFamilyHistoryHandler : IInteractor<InsertFamilyHistoryRequest, InsertFamilyHistoryResponse>
    {
        private readonly ILogger<InsertFamilyHistoryHandler> _logger;
        private readonly IAntecedentPatient _antecedent;
        private readonly IPatientsData _patients;

        public InsertFamilyHistoryHandler(ILogger<InsertFamilyHistoryHandler> logger, IAntecedentPatient antecedent, IPatientsData patients)
        {
            _logger=logger;
            _antecedent=antecedent;
            _patients=patients;

        }

        public async Task<InsertFamilyHistoryResponse> Handle(InsertFamilyHistoryRequest request, CancellationToken cancellationToken)
        {
            var FamilyHistory = await _antecedent.GetFamilyHistoryByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            var PatientsData = await _patients.GetPatientDataByIDPatientAsync(request.IDPatient).ConfigureAwait(false);

            if (PatientsData == null || !Equals(request.IDPatient, PatientsData.ID) || string.IsNullOrEmpty(Convert.ToString(request.IDPatient)))
            {
                return new FailureInsertFamilyHistoryResponse ($"No se encontro al paciente {request.IDPatient} o no es valido con el registo que se quiere ingresar");
            }

            if (FamilyHistory != null)
            {
                return new FailureInsertFamilyHistoryResponse("Este paciente ya cuenta con un registro");
            }


            await _antecedent.InsertFamilyHistoryAsync(
                request.IDPatient,
                request.Diabetes,
                request.Cardiopathies,
                request.Hypertension,
                request.ThyroidDiseases,
                request.ChronicKidneyDisease,
                request.Others,
                request.OthersData
                ).ConfigureAwait(false);

            FamilyHistory = await _antecedent.GetFamilyHistoryByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            return new SuccessInsertFamilyHistoryResponse(new FamilyHistoryDto(
            FamilyHistory.Id,
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
