using Common.Common;
using Medical.Office.App.Dtos.Configurations;

namespace Medical.Office.App.UseCases.Configurations.OfficeSetup.UpdateOfficeSetup.Responses
{
    public record SuccessUpdateOfficeSetupResponse(OfficeSetupDto OfficeSetup) : UpdateOfficeSetupResponse, ISuccess;
}
