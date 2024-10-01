using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.InsertNonPathologicalHistory.Responses
{
    public record FailureInsertNonPathologicalHistoryResponse(string Message) : InsertNonPathologicalHistoryResponse,IFailure;
}
