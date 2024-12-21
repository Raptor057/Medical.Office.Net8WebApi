using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.UpdateNonPathologicalHistory.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.NonPathologicalHistory.UpdateNonPathologicalHistory;

public sealed class UpdateNonPathologicalHistoryPresenter<T> : IPresenter<UpdateNonPathologicalHistoryResponse>
where T : UpdateNonPathologicalHistoryResponse
{
    private readonly GenericViewModel<UpdateNonPathologicalHistoryController> _viewModel;

    public UpdateNonPathologicalHistoryPresenter(GenericViewModel<UpdateNonPathologicalHistoryController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(UpdateNonPathologicalHistoryResponse notification, CancellationToken cancellationToken)
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