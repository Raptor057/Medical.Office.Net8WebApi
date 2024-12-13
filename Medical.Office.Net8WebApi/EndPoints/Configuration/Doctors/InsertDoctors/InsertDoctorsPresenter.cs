using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Configurations.Doctors.InsertDoctors.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.Doctors.InsertDoctors
{
    public class InsertDoctorsPresenter<T> : IPresenter<InsertDoctorsResponse>
        where T : InsertDoctorsResponse
    {
        private readonly GenericViewModel<InsertDoctorsController> _viewModel;

        public InsertDoctorsPresenter(GenericViewModel<InsertDoctorsController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(InsertDoctorsResponse notification, CancellationToken cancellationToken)
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
