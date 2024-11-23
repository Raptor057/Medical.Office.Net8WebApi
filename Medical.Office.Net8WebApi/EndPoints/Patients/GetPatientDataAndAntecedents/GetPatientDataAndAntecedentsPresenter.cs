using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.GetPatientDataAndAntecedents.Responses;
using Medical.Office.App.UseCases.Patients.GetPatientDataList.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.GetPatientDataAndAntecedents
{
    public sealed class GetPatientDataAndAntecedentsPresenter<T> : IPresenter<GetPatientDataAndAntecedentsResponse>
        where T : GetPatientDataAndAntecedentsResponse
    {
        private readonly GenericViewModel<GetPatientDataAndAntecedentsController> _viewModel;

        public GetPatientDataAndAntecedentsPresenter(GenericViewModel<GetPatientDataAndAntecedentsController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(GetPatientDataAndAntecedentsResponse notification, CancellationToken cancellationToken)
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
