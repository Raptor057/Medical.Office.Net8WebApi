using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.FamilyHistory;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.UpdateFamilyHistory
{
    internal sealed class UpdateFamilyHistoryHandler : IInteractor<UpdateFamilyHistoryRequest, UpdateFamilyHistoryResponse>
    {
        private readonly IAntecedentPatient _patient;
        private readonly IPatientsData _patients;

        public UpdateFamilyHistoryHandler(IAntecedentPatient patient, IPatientsData patients)
        {
            _patient = patient;
            _patients = patients;
        }

        public async Task<UpdateFamilyHistoryResponse> Handle(UpdateFamilyHistoryRequest request, CancellationToken cancellationToken)
        {
            var data = request.FamilyHistory;

            await _patient.UpdateFamilyHistoryAsync(
                data.IDPatient,
                data.Diabetes,
                data.Cardiopathies,
                data.Hypertension,
                data.ThyroidDiseases,
                data.ChronicKidneyDisease,
                data.Others,
                data.OthersData,
                DateTime.Now
            ).ConfigureAwait(false);

            var patient = await _patients.GetPatientDataByIDPatientAsync(data.IDPatient).ConfigureAwait(false);

            if (patient == null)
            {
                return new FailureUpdateFamilyHistoryResponse("Patient not found");
            }

            var updatedData = new FamilyHistoryDto
            (
                data.Id,
                data.IDPatient,
                data.Diabetes,
                data.Cardiopathies,
                data.Hypertension,
                data.ThyroidDiseases,
                data.ChronicKidneyDisease,
                data.Others,
                data.OthersData,
                data.DateTimeSnap
            );

            return new SuccessUpdateFamilyHistoryResponse(updatedData);
        }
    }
}