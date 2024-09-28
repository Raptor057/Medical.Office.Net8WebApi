using Common.Common;

namespace Medical.Office.App.UseCases.Configurations.GetAllConfigurations.Responses
{
    public record FailureGetAllConfigurationsResponse(string Message):GetAllConfigurationsResponse, IFailure;
}
