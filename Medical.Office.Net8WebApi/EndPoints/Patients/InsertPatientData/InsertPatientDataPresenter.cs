using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.InsertPatientData.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.InsertPatientData
{
    public sealed class InsertPatientDataPresenter<T> : IPresenter<InsertPatientDataResponse>
        where T : InsertPatientDataResponse
    {
        private readonly GenericViewModel<InsertPatientDataController> _viewModel;

        public InsertPatientDataPresenter(GenericViewModel<InsertPatientDataController> viewModel) 
        {
            _viewModel=viewModel;
        }

        public async Task Handle(InsertPatientDataResponse notification, CancellationToken cancellationToken)
        {
            if (notification is IFailure failure)
            {
                _viewModel.Fail(failure.Message);
                await Task.CompletedTask;
            }
            else if (notification is SuccessInsertPatientDataResponse response)
            {
                _viewModel.OK(response);
                await Task.CompletedTask;
            }
        }
    }
}
