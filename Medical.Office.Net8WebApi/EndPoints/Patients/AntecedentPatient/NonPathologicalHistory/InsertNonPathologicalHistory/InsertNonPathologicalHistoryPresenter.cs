using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.InsertNonPathologicalHistory.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.NonPathologicalHistory.InsertNonPathologicalHistory
{
    public class InsertNonPathologicalHistoryPresenter<T> : IPresenter<InsertNonPathologicalHistoryResponse> where T : InsertNonPathologicalHistoryResponse
    {
        private readonly GenericViewModel<InsertNonPathologicalHistoryController> _viewModel;

        public InsertNonPathologicalHistoryPresenter(GenericViewModel<InsertNonPathologicalHistoryController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(InsertNonPathologicalHistoryResponse notification, CancellationToken cancellationToken)
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
