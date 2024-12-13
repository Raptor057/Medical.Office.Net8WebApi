using Common.Common;

namespace Medical.Office.App.UseCases.Configurations.OfficeSetup.UpdateOfficeSetup.Responses
{
    public record FailureUpdateOfficeSetupResponse(string Message): UpdateOfficeSetupResponse, IFailure;
}
