using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.GetNonPathologicalHistory.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.NonPathologicalHistory.GetNonPathologicalHistory
{
    public class GetNonPathologicalHistoryPresenter<T> : IPresenter<GetNonPathologicalHistoryResponse> where T : GetNonPathologicalHistoryResponse
    {
        private readonly GenericViewModel<GetNonPathologicalHistoryController> _viewModel;

        public GetNonPathologicalHistoryPresenter(GenericViewModel<GetNonPathologicalHistoryController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(GetNonPathologicalHistoryResponse notification, CancellationToken cancellationToken)
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
