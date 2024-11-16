using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.InsertFamilyHistory.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.FamilyHistory.InsertFamilyHistory
{
    public class InsertFamilyHistoryPresenter<T> : IPresenter<InsertFamilyHistoryResponse> where T : InsertFamilyHistoryResponse
    {
        private readonly GenericViewModel<InsertFamilyHistoryController> _viewModel;

        public InsertFamilyHistoryPresenter(GenericViewModel<InsertFamilyHistoryController> viewModel)
        {
            _viewModel=viewModel;
        }

        public async Task Handle(InsertFamilyHistoryResponse notification, CancellationToken cancellationToken)
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
