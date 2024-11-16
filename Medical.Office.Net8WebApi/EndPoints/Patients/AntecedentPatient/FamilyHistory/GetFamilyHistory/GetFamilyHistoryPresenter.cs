using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.GetFamilyHistory.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.FamilyHistory.GetFamilyHistory
{
    public class GetFamilyHistoryPresenter<T> : IPresenter<GetFamilyHistoryResponse> where T : GetFamilyHistoryResponse
    {
        private readonly GenericViewModel<GetFamilyHistoryController> _viewModel;

        public GetFamilyHistoryPresenter(GenericViewModel<GetFamilyHistoryController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(GetFamilyHistoryResponse notification, CancellationToken cancellationToken)
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
