using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.UpdatePathologicalBackground.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PathologicalBackground.UpdatePathologicalBackground;

public sealed class UpdatePathologicalBackgroundPresenter<T> : IPresenter<UpdatePathologicalBackgroundResponse>
where T : UpdatePathologicalBackgroundResponse
{
    private readonly GenericViewModel<UpdatePathologicalBackgroundController> _viewModel;

    public UpdatePathologicalBackgroundPresenter(GenericViewModel<UpdatePathologicalBackgroundController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(UpdatePathologicalBackgroundResponse notification, CancellationToken cancellationToken)
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