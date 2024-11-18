using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.GetPathologicalBackground.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PathologicalBackground.GetPathologicalBackground
{
    public class GetPathologicalBackgroundPresenter<T> : IPresenter<GetPathologicalBackgroundResponse> where T : GetPathologicalBackgroundResponse
    {
        private readonly GenericViewModel<GetPathologicalBackgroundController> _viewModel;

        public GetPathologicalBackgroundPresenter(GenericViewModel<GetPathologicalBackgroundController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(GetPathologicalBackgroundResponse notification, CancellationToken cancellationToken)
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
