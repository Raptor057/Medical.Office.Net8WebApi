using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Configurations.GetAllConfigurations.Responses;


namespace Medical.Office.Net8WebApi.EndPoints.GetAllConfigurations
{
    public sealed class GetAllConfigurationsPresenter<T> : IPresenter<GetAllConfigurationsResponse>
        where T : GetAllConfigurationsResponse
    {
        private readonly GenericViewModel<GetAllConfigurationsController> _viewModel;

        public GetAllConfigurationsPresenter(GenericViewModel<GetAllConfigurationsController> viewModel)
        {
            _viewModel=viewModel;
        }

        public async Task Handle(GetAllConfigurationsResponse notification, CancellationToken cancellationToken)
        {
            if (notification is IFailure failure)
            {
                _viewModel.Fail(failure.Message);
                await Task.CompletedTask;
            }
            else if (notification is SuccessGetAllConfigurationsResponse success)
            {
                _viewModel.OK(success);
                await Task.CompletedTask;
            }
        }
    }
}
