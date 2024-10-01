using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.GetFamilyHistory.Responses
{
    public record FailureGetFamilyHistoryResponse(string Message) : GetFamilyHistoryResponse, IFailure;
}
