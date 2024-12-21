using Common.Common.CleanArch;
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


        public Task<UpdateMedicalHistoryNotesResponse> Handle(UpdateMedicalHistoryNotesRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}