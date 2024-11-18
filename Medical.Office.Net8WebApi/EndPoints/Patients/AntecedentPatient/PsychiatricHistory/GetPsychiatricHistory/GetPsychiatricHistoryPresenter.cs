using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.GetPsychiatricHistory.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PsychiatricHistory.GetPsychiatricHistory
{
    public class GetPsychiatricHistoryPresenter<T> : IPresenter<GetPsychiatricHistoryResponse> where T : GetPsychiatricHistoryResponse
    {
        private readonly GenericViewModel<GetPsychiatricHistoryController> _viewModel;

        public GetPsychiatricHistoryPresenter(GenericViewModel<GetPsychiatricHistoryController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(GetPsychiatricHistoryResponse notification, CancellationToken cancellationToken)
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
