using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.GetPatientAllergies.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PatientAllergies.GetPatientAllergies
{
    public class GetPatientAllergiesPresenter<T>: IPresenter<GetPatientAllergiesResponse> where T : GetPatientAllergiesResponse
    {
        private readonly GenericViewModel<GetPatientAllergiesController> _viewModel;

        public GetPatientAllergiesPresenter(GenericViewModel<GetPatientAllergiesController> viewModel)
        {
            _viewModel=viewModel;
        }

        public async Task Handle(GetPatientAllergiesResponse notification, CancellationToken cancellationToken)
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
