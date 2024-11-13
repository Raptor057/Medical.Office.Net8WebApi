using Common.Common;
using Medical.Office.App.Dtos.Configurations;

namespace Medical.Office.App.UseCases.Configurations.OfficeSetup.InsertOfficeSetup.Responses
{
    public record SuccessInsertOfficeSetupResponse(OfficeSetupDto InsertOfficeSetup):InsertOfficeSetupResponse, ISuccess;
}
