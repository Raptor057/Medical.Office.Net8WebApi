using Common.Common;

namespace Medical.Office.App.UseCases.Configurations.OfficeSetup.InsertOfficeSetup.Responses
{
    public record FailureInsertOfficeSetupResponse(string Message): InsertOfficeSetupResponse, IFailure;

}
