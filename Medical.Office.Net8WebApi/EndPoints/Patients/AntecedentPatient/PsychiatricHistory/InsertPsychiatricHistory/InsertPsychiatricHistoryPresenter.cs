using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.InsertPsychiatricHistory.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PsychiatricHistory.InsertPsychiatricHistory
{
    public class InsertPsychiatricHistoryPresenter<T> : IPresenter<InsertPsychiatricHistoryResponse> where T : InsertPsychiatricHistoryResponse
    {
        private readonly GenericViewModel<InsertPsychiatricHistoryController> _viewModel;

        public InsertPsychiatricHistoryPresenter(GenericViewModel<InsertPsychiatricHistoryController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(InsertPsychiatricHistoryResponse notification, CancellationToken cancellationToken)
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
