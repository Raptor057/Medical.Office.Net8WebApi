using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.UpdateMedicalHistoryNotes.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.MedicalHistoryNotes.UpdateMedicalHistoryNotes;

public sealed class UpdateMedicalHistoryNotesPresenter<T> : IPresenter<UpdateMedicalHistoryNotesResponse>
where T : UpdateMedicalHistoryNotesResponse
{
    private readonly GenericViewModel<UpdateMedicalHistoryNotesController> _viewModel;

    public UpdateMedicalHistoryNotesPresenter(GenericViewModel<UpdateMedicalHistoryNotesController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(UpdateMedicalHistoryNotesResponse notification, CancellationToken cancellationToken)
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