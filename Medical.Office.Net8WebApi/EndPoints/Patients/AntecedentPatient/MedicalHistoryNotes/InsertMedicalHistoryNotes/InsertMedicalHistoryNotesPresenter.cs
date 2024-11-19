using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.MedicalHistoryNotes;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes
{
    public class InsertMedicalHistoryNotesPresenter<T> : IPresenter<InsertMedicalHistoryNotesResponse> where T: InsertMedicalHistoryNotesResponse
    {
        private readonly GenericViewModel<InsertMedicalHistoryNotesController> _viewModel;

        public InsertMedicalHistoryNotesPresenter(GenericViewModel<InsertMedicalHistoryNotesController> viewModel)
        {
            _viewModel=viewModel;
        }


        public async Task Handle(InsertMedicalHistoryNotesResponse notification, CancellationToken cancellationToken)
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
