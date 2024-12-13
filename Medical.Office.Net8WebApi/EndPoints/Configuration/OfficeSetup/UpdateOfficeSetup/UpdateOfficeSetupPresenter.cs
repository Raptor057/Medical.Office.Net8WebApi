using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Configurations.OfficeSetup.InsertOfficeSetup.Responses;
using Medical.Office.App.UseCases.Configurations.OfficeSetup.UpdateOfficeSetup.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.OfficeSetup.UpdateOfficeSetup
{
    public class UpdateOfficeSetupPresenter<T> : IPresenter<UpdateOfficeSetupResponse>
        where T : UpdateOfficeSetupResponse
    {
        private readonly GenericViewModel<UpdateOfficeSetupController> _viewModel;

        public UpdateOfficeSetupPresenter(GenericViewModel<UpdateOfficeSetupController> viewModel) 
        {
            _viewModel=viewModel;
        }

        public async Task Handle(UpdateOfficeSetupResponse notification, CancellationToken cancellationToken)
        {

            if (notification is IFailure failure)
            {
                _viewModel.Fail(failure.Message);
                await Task.CompletedTask;
            }
            else if (notification is ISuccess response)
            {
                _viewModel.OK(response);
                await Task.CompletedTask;
            }
        }
    }
}
