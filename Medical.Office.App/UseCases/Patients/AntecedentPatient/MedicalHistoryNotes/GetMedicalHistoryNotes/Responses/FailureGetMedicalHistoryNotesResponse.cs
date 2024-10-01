using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.GetMedicalHistoryNotes.Responses
{
    public record FailureGetMedicalHistoryNotesResponse(string Message) : GetMedicalHistoryNotesResponse,IFailure;
}
