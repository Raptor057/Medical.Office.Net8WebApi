using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.GetMedicalHistoryNotes.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.MedicalHistoryNotes.GetMedicalHistoryNotes
{
    public class GetMedicalHistoryNotesPresenter<T> : IPresenter<GetMedicalHistoryNotesResponse> where T : GetMedicalHistoryNotesResponse
    {
        private readonly GenericViewModel<GetMedicalHistoryNotesController> _viewModel;

        public GetMedicalHistoryNotesPresenter(GenericViewModel<GetMedicalHistoryNotesController> viewModel)
        {
            _viewModel=viewModel;
        }

        public async Task Handle(GetMedicalHistoryNotesResponse notification, CancellationToken cancellationToken)
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
