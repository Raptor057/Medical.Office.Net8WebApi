using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.MedicalHistoryNotes;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes
{
    internal class InsertMedicalHistoryNotesHandler : IInteractor<InsertMedicalHistoryNotesRequest, InsertMedicalHistoryNotesResponse>
    {
        private readonly IAntecedentPatient _antecedent;
        private readonly IPatientsData _patients;

        public InsertMedicalHistoryNotesHandler(ILogger<InsertMedicalHistoryNotesHandler> logger, IAntecedentPatient antecedent, IPatientsData patients)
        {
            _antecedent=antecedent;
            _patients=patients;
        }

        public async Task<InsertMedicalHistoryNotesResponse> Handle(InsertMedicalHistoryNotesRequest request, CancellationToken cancellationToken)
        {
            var PatientData = await _patients.GetPatientDataByIDPatientAsync(request.IDPatient).ConfigureAwait(false);
            var MedicalHistoryNotes = await _antecedent.GetMedicalHistoryNotesByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            if (MedicalHistoryNotes == null) 
            {
                return new FailureInsertMedicalHistoryNotesResponse("Este paciente ya cuenta con un registro");
            }
            else if (!Equals(request.IDPatient,PatientData.ID))
            {
                return new FailureInsertMedicalHistoryNotesResponse("Este paciente no esta registrado o el ID del registro del paciente no coincide con el paciente");
            }

            MedicalHistoryNotes = await _antecedent.GetMedicalHistoryNotesByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            return new SuccessInsertMedicalHistoryNotesResponse(new MedicalHistoryNotesDto(MedicalHistoryNotes.Id,
                MedicalHistoryNotes.IDPatient,
                MedicalHistoryNotes.MedicalHistoryNotesData,
                MedicalHistoryNotes.DateTimeSnap));
        }
    }
}
