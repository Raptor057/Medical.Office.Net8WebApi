using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.UpdateMedicalHistoryNotes.Response;

public record FailureUpdateMedicalHistoryNotesResponse(string Message) : UpdateMedicalHistoryNotesResponse,IFailure;