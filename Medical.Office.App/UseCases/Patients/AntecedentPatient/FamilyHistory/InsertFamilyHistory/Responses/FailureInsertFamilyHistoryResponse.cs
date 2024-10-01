using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.InsertFamilyHistory.Responses
{
    public record FailureInsertFamilyHistoryResponse(string Message): InsertFamilyHistoryResponse,IFailure;
}
