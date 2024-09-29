using Common.Common;

namespace Medical.Office.App.UseCases.Patients.InsertPatientData.Responses
{
    public record FailureInsertPatientDataResponse(string Message): InsertPatientDataResponse, IFailure;
}
