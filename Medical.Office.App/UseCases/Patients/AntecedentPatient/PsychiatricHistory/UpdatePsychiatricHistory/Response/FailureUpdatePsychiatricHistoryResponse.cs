using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.UpdatePsychiatricHistory.Response;

public record FailureUpdatePsychiatricHistoryResponse(string Message) : UpdatePsychiatricHistoryResponse,IFailure;