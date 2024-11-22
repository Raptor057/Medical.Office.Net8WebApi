using Medical.Office.App.Dtos.Configurations;

namespace Medical.Office.App.UseCases.Configurations.GetAllConfigurations.Responses
{
    public record SuccessGetAllConfigurationsResponse(GetAllConfigurationsDto AllConfigurations): GetAllConfigurationsResponse;
}
