using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes
{
    public class InsertMedicalHistoryNotesPresenter<T> : IPresenter<InsertMedicalHistoryNotesResponse> where T : InsertMedicalHistoryNotesResponse
    {
        private readonly GenericViewModel<InsertMedicalHistoryNotesController> _viewModel;

        public InsertMedicalHistoryNotesPresenter(GenericViewModel<InsertMedicalHistoryNotesController> viewModel) 
        {
            _viewModel=viewModel;
        }

        public Task Handle(InsertMedicalHistoryNotesResponse notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
