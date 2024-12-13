using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Configurations.Doctors.UpdateDoctors.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.Doctors.UpdateDoctors
{
    public class UpdateDoctorsPresenter<T> : IPresenter<UpdateDoctorsResponse>
        where T : UpdateDoctorsResponse
    {
        private readonly GenericViewModel<UpdateDoctorsController> _viewModel;

        public UpdateDoctorsPresenter(GenericViewModel<UpdateDoctorsController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(UpdateDoctorsResponse notification, CancellationToken cancellationToken)
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
