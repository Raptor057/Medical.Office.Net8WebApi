using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes.Responses
{
    public record FailureInsertMedicalHistoryNotesResponse(string Message) : InsertMedicalHistoryNotesResponse, IFailure;
}
