using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.InsertPsychiatricHistory.Responses
{
    public record FailureInsertPsychiatricHistoryResponse(string Message) : InsertPsychiatricHistoryResponse,IFailure;
}
