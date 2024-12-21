using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.UpdatePsychiatricHistory.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PsychiatricHistory.UpdatePsychiatricHistory;

public sealed class UpdatePsychiatricHistoryPresenter<T> : IPresenter<UpdatePsychiatricHistoryResponse>
where T : UpdatePsychiatricHistoryResponse
{
    private readonly GenericViewModel<UpdatePsychiatricHistoryController> _viewModel;

    public UpdatePsychiatricHistoryPresenter(GenericViewModel<UpdatePsychiatricHistoryController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(UpdatePsychiatricHistoryResponse notification, CancellationToken cancellationToken)
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