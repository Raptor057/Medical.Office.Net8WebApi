using Medical.Office.App.Dtos.Patients.AntecedentPatient.MedicalHistoryNotes;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes.Responses
{
    public record SuccessInsertMedicalHistoryNotesResponse(MedicalHistoryNotesDto MedicalHistoryNotesDto) : InsertMedicalHistoryNotesResponse;
}
