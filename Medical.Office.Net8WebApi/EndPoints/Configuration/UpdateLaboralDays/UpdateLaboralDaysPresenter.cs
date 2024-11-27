using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Configurations.LaboralDays.UpdateLaboralDays.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.UpdateLaboralDays
{
    public sealed class UpdateLaboralDaysPresenter<T> : IPresenter<UpdateLaboralDaysResponse>
        where T : UpdateLaboralDaysResponse
    {
        private readonly GenericViewModel<UpdateLaboralDaysController> _viewModel;

        public UpdateLaboralDaysPresenter(GenericViewModel<UpdateLaboralDaysController> viewModel)
        {
            _viewModel=viewModel;
        }

        public async Task Handle(UpdateLaboralDaysResponse notification, CancellationToken cancellationToken)
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
