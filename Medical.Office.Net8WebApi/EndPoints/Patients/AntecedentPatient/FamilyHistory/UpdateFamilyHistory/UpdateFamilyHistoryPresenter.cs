using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.UpdateFamilyHistory;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.FamilyHistory.UpdateFamilyHistory;

public sealed class UpdateFamilyHistoryPresenter<T> : IPresenter<UpdateFamilyHistoryResponse>
where T : UpdateFamilyHistoryResponse
{
    private readonly GenericViewModel<UpdateFamilyHistoryController> _viewModel;

    public UpdateFamilyHistoryPresenter(GenericViewModel<UpdateFamilyHistoryController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(UpdateFamilyHistoryResponse notification, CancellationToken cancellationToken)
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
