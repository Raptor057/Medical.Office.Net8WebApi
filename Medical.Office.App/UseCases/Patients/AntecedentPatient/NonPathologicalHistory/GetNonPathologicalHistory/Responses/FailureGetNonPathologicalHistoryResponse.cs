using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.GetNonPathologicalHistory.Responses
{
    public record FailureGetNonPathologicalHistoryResponse(string Message): GetNonPathologicalHistoryResponse,IFailure;
}
