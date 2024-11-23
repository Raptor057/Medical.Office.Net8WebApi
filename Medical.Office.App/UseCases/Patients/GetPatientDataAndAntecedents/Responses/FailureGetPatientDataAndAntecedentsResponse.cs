using Common.Common;

namespace Medical.Office.App.UseCases.Patients.GetPatientDataAndAntecedents.Responses
{
    public record FailureGetPatientDataAndAntecedentsResponse(string Message) : GetPatientDataAndAntecedentsResponse, IFailure;
}
