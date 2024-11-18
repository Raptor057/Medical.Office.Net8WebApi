using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.InsertPatientAllergies.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PatientAllergies.InsertPatientAllergies
{
    public class InsertPatientAllergiesPresenter<T> : IPresenter<InsertPatientAllergiesResponse> where T : InsertPatientAllergiesResponse
    {
        private readonly GenericViewModel<InsertPatientAllergiesController> _viewModel;

        public InsertPatientAllergiesPresenter(GenericViewModel<InsertPatientAllergiesController> viewModel)
        {
            _viewModel=viewModel;
        }

        public async Task Handle(InsertPatientAllergiesResponse notification, CancellationToken cancellationToken)
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
