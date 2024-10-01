using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.GetPsychiatricHistory.Responses
{
    public record FailureGetPsychiatricHistoryResponse(string Message):GetPsychiatricHistoryResponse, IFailure;
}
