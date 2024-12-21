using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PathologicalBackground;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.UpdatePathologicalBackground.Response;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.UpdatePathologicalBackground
{
    internal sealed class UpdatePathologicalBackgroundHandler : IInteractor<UpdatePathologicalBackgroundRequest, UpdatePathologicalBackgroundResponse>
    {
        private readonly IAntecedentPatient _patient;
        private readonly IPatientsData _patients;

        public UpdatePathologicalBackgroundHandler(IAntecedentPatient patient, IPatientsData patients)
        {
            _patient = patient;
            _patients = patients;
        }

        public async Task<UpdatePathologicalBackgroundResponse> Handle(UpdatePathologicalBackgroundRequest request, CancellationToken cancellationToken)
        {
            var data = request.PathologicalBackground;

            await _patient.UpdatePathologicalBackgroundAsync(
                data.IDPatient,
                data.PreviousHospitalization.HasValue ? (data.PreviousHospitalization.Value ? 1 : 0) : 0,
                data.PreviousSurgeries.HasValue ? (data.PreviousSurgeries.Value ? 1 : 0) : 0,
                data.Diabetes.HasValue ? (data.Diabetes.Value ? 1 : 0) : 0,
                data.ThyroidDiseases.HasValue ? (data.ThyroidDiseases.Value ? 1 : 0) : 0,
                data.Hypertension.HasValue ? (data.Hypertension.Value ? 1 : 0) : 0,
                data.Cardiopathies.HasValue ? (data.Cardiopathies.Value ? 1 : 0) : 0,
                data.Trauma.HasValue ? (data.Trauma.Value ? 1 : 0) : 0,
                data.Cancer.HasValue ? (data.Cancer.Value ? 1 : 0) : 0,
                data.Tuberculosis.HasValue ? (data.Tuberculosis.Value ? 1 : 0) : 0,
                data.Transfusions.HasValue ? (data.Transfusions.Value ? 1 : 0) : 0,
                data.RespiratoryDiseases.HasValue ? (data.RespiratoryDiseases.Value ? 1 : 0) : 0,
                data.GastrointestinalDiseases.HasValue ? (data.GastrointestinalDiseases.Value ? 1 : 0) : 0,
                data.STDs.HasValue ? (data.STDs.Value ? 1 : 0) : 0,
                data.STDsData ?? string.Empty,
                data.ChronicKidneyDisease.HasValue ? (data.ChronicKidneyDisease.Value ? 1 : 0) : 0,
                data.Others ?? string.Empty,
                DateTime.Now
            ).ConfigureAwait(false);

            var patient = await _patients.GetPatientDataByIDPatientAsync(data.IDPatient).ConfigureAwait(false);

            if (patient == null)
            {
                return new FailureUpdatePathologicalBackgroundResponse("Patient not found");
            }

            var updatedData = new PathologicalBackgroundDto
            (
                data.Id,
                data.IDPatient,
                data.PreviousHospitalization,
                data.PreviousSurgeries,
                data.Diabetes,
                data.ThyroidDiseases,
                data.Hypertension,
                data.Cardiopathies,
                data.Trauma,
                data.Cancer,
                data.Tuberculosis,
                data.Transfusions,
                data.RespiratoryDiseases,
                data.GastrointestinalDiseases,
                data.STDs,
                data.STDsData,
                data.ChronicKidneyDisease,
                data.Others,
                data.DateTimeSnap
            );

            return new SuccessUpdatePathologicalBackgroundResponse(updatedData);
        }
    }
}