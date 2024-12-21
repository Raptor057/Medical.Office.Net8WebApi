using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.UpdatePatientAllergies.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PatientAllergies.UpdatePatientAllergies;

public sealed class UpdatePatientAllergiesPresenter<T> : IPresenter<UpdatePatientAllergiesResponse>
where T : UpdatePatientAllergiesResponse
{
    private readonly GenericViewModel<UpdatePatientAllergiesController> _viewModel;

    public UpdatePatientAllergiesPresenter(GenericViewModel<UpdatePatientAllergiesController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(UpdatePatientAllergiesResponse notification, CancellationToken cancellationToken)
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