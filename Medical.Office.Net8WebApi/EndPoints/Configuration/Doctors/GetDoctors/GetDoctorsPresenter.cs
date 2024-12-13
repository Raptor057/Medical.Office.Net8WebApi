using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Configurations.Doctors.GetDoctors.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.Doctors.GetDoctors
{
    public class GetDoctorsPresenter<T> : IPresenter<GetDoctorsResponse>
        where T : GetDoctorsResponse
    {
        private readonly GenericViewModel<GetDoctorsController> _viewModel;

        public GetDoctorsPresenter(GenericViewModel<GetDoctorsController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(GetDoctorsResponse notification, CancellationToken cancellationToken)
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
