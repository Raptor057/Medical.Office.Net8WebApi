using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications
{
    public sealed class InsertActiveMedicationsPresenter<T> : IPresenter<InsertActiveMedicationsResponse>
        where T : InsertActiveMedicationsResponse
    {
        private readonly GenericViewModel<InsertActiveMedicationsController> _viewModel;

        public InsertActiveMedicationsPresenter(GenericViewModel<InsertActiveMedicationsController> viewModel)
        {
            _viewModel=viewModel;
        }

        public async Task Handle(InsertActiveMedicationsResponse notification, CancellationToken cancellationToken)
        {
            if (notification is IFailure failure)
            {
                _viewModel.Fail(failure.Message);
                await Task.CompletedTask;
            }
            else if (notification is SuccessInsertActiveMedicationsResponse response)
            {
                _viewModel.OK(response);
                await Task.CompletedTask;
            }
        }
    }
}
