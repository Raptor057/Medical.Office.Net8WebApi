using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Configurations.OfficeSetup.InsertOfficeSetup.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.OfficeSetup.InsertOfficeSetup
{
    public sealed class InsertOfficeSetupPresenter<T> : IPresenter<InsertOfficeSetupResponse> 
        where T : InsertOfficeSetupResponse
    {
        private readonly GenericViewModel<InsertOfficeSetupController> _viewModel;

        public InsertOfficeSetupPresenter(GenericViewModel<InsertOfficeSetupController> viewModel)
        {
            _viewModel= viewModel;
        }
        public async Task Handle(InsertOfficeSetupResponse notification, CancellationToken cancellationToken)
        {
            if (notification is IFailure failure)
            {
                _viewModel.Fail(failure.Message);
                await Task.CompletedTask;
            }
            else if (notification is SuccessInsertOfficeSetupResponse response)
            {
                _viewModel.OK(response);
                await Task.CompletedTask;
            }
        }
    }
}
