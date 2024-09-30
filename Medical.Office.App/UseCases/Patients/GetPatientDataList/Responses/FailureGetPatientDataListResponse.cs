using Common.Common;

namespace Medical.Office.App.UseCases.Patients.GetPatientDataList.Responses
{
    public record FailureGetPatientDataListResponse(string Message) : GetPatientDataListResponse, IFailure;
}
