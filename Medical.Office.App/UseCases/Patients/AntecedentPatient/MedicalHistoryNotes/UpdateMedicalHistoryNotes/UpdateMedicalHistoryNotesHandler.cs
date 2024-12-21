using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.MedicalHistoryNotes;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.UpdateMedicalHistoryNotes.Response;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.UpdateMedicalHistoryNotes
{
    internal sealed class UpdateMedicalHistoryNotesHandler : IInteractor<UpdateMedicalHistoryNotesRequest, UpdateMedicalHistoryNotesResponse>
    {
        private readonly IAntecedentPatient _patient;
        private readonly IPatientsData _patients;

        public UpdateMedicalHistoryNotesHandler(IAntecedentPatient patient, IPatientsData patients)
        {
            _patient = patient;
            _patients = patients;
        }

        public async Task<UpdateMedicalHistoryNotesResponse> Handle(UpdateMedicalHistoryNotesRequest request, CancellationToken cancellationToken)
        {
            var data = request.MedicalHistoryNotes;

            await _patient.UpdateMedicalHistoryNotesAsync(
                data.IDPatient,
                data.MedicalHistoryNotesData,
                DateTime.Now
            ).ConfigureAwait(false);

            var patient = await _patients.GetPatientDataByIDPatientAsync(data.IDPatient).ConfigureAwait(false);

            if (patient == null)
            {
                return new FailureUpdateMedicalHistoryNotesResponse("Patient not found");
            }

            var updatedData = new MedicalHistoryNotesDto
            (
                data.Id,
                data.IDPatient,
                data.MedicalHistoryNotesData,
                data.DateTimeSnap
            );

            return new SuccessMedicalHistoryNotesResponse(updatedData);
        }
    }
}