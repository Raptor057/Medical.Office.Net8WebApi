using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.UpdateActiveMedications.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.ActiveMedications.UpdateActiveMedications;

public sealed class UpdateActiveMedicationsPresenter<T> : IPresenter<UpdateActiveMedicationsResponse>
where T : UpdateActiveMedicationsResponse
{
    private readonly GenericViewModel<UpdateActiveMedicationsController> _viewModel;

    public UpdateActiveMedicationsPresenter(GenericViewModel<UpdateActiveMedicationsController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(UpdateActiveMedicationsResponse notification, CancellationToken cancellationToken)
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
