using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.InsertPathologicalBackground.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PathologicalBackground.InsertPathologicalBackground
{
    public class InsertPathologicalBackgroundPresenter<T> : IPresenter<InsertPathologicalBackgroundResponse> where T : InsertPathologicalBackgroundResponse
    {
        private readonly GenericViewModel<InsertPathologicalBackgroundController> _viewModel;

        public InsertPathologicalBackgroundPresenter(GenericViewModel<InsertPathologicalBackgroundController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(InsertPathologicalBackgroundResponse notification, CancellationToken cancellationToken)
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
