using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.GetActiveMedications.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.ActiveMedications.GetActiveMedications
{
    public sealed class GetActiveMedicationsPresenter<T> : IPresenter<GetActiveMedicationsResponse> where T : GetActiveMedicationsResponse
    {
        private readonly GenericViewModel<GetActiveMedicationsController> _viewModel;

        public GetActiveMedicationsPresenter(GenericViewModel<GetActiveMedicationsController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(GetActiveMedicationsResponse notification, CancellationToken cancellationToken)
        {

            if (notification is IFailure failure)
            {
                _viewModel.Fail(failure.Message);
                await Task.CompletedTask;
            }
            else if (notification is SuccessGetActiveMedicationsResponse response) 
            {
                _viewModel.OK(response);
                await Task.CompletedTask;
            }
        }
    }
}
