using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.GetPatientDataList.Responses;


namespace Medical.Office.Net8WebApi.EndPoints.Patients.GetPatientDataList
{
    public sealed class GetPatientDataPresenter<T> : IPresenter<GetPatientDataListResponse>
        where T : GetPatientDataListResponse
    {
        private readonly GenericViewModel<GetPatientDataController> _viewModel;

        public GetPatientDataPresenter(GenericViewModel<GetPatientDataController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(GetPatientDataListResponse notification, CancellationToken cancellationToken)
        {
            if (notification is IFailure failure)
            {
                _viewModel.Fail(failure.Message);
                await Task.CompletedTask;
            }
            else if (notification is SuccessGetPatientDataResponse response)
            {
                _viewModel.OK(response);
                await Task.CompletedTask;
            }
            else if (notification is SuccessGetPatientDataListResponse responselist)
            {
                _viewModel.OK(responselist);
                await Task.CompletedTask;
            }
        }
    }
}
