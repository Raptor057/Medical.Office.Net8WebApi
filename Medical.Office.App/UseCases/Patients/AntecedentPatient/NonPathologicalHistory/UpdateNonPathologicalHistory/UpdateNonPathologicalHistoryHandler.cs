using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.NonPathologicalHistory;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.UpdateNonPathologicalHistory.Response;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.UpdateNonPathologicalHistory
{
    internal sealed class UpdateNonPathologicalHistoryHandler : IInteractor<UpdateNonPathologicalHistoryRequest, UpdateNonPathologicalHistoryResponse>
    {
        private readonly IAntecedentPatient _patient;
        private readonly IPatientsData _patients;

        public UpdateNonPathologicalHistoryHandler(IAntecedentPatient patient, IPatientsData patients)
        {
            _patient = patient;
            _patients = patients;
        }

        public async Task<UpdateNonPathologicalHistoryResponse> Handle(UpdateNonPathologicalHistoryRequest request, CancellationToken cancellationToken)
        {
            var data = request.NonPathologicalHistory;

            await _patient.UpdateNonPathologicalHistoryAsync(
                data.IDPatient,
                data.PhysicalActivity.HasValue ? (data.PhysicalActivity.Value ? 1 : 0) : 0,
                data.Smoking.HasValue ? (data.Smoking.Value ? 1 : 0) : 0,
                data.Alcoholism.HasValue ? (data.Alcoholism.Value ? 1 : 0) : 0,
                data.SubstanceAbuse.HasValue ? (data.SubstanceAbuse.Value ? 1 : 0) : 0,
                data.SubstanceAbuseData ?? string.Empty,
                data.RecentVaccination.HasValue ? (data.RecentVaccination.Value ? 1 : 0) : 0,
                data.RecentVaccinationData ?? string.Empty,
                data.Others.HasValue ? (data.Others.Value ? 1 : 0) : 0,
                data.OthersData ?? string.Empty,
                DateTime.UtcNow
            ).ConfigureAwait(false);

            var patient = await _patients.GetPatientDataByIDPatientAsync(data.IDPatient).ConfigureAwait(false);

            if (patient == null)
            {
                return new FailureUpdateNonPathologicalHistoryResponse("Patient not found");
            }

            var updatedData = new NonPathologicalHistoryDto
            (
                data.Id,
                data.IDPatient,
                data.PhysicalActivity,
                data.Smoking,
                data.Alcoholism,
                data.SubstanceAbuse,
                data.SubstanceAbuseData,
                data.RecentVaccination,
                data.RecentVaccinationData,
                data.Others,
                data.OthersData,
                data.DateTimeSnap
            );

            return new SuccessUpdateNonPathologicalHistoryResponse(updatedData);
        }
    }
}