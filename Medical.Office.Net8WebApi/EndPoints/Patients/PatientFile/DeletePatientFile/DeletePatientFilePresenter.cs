using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.FilesPatients.DeletePatientFile.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.PatientFile.DeletePatientFile
{
    public class DeletePatientFilePresenter<T> : IPresenter<DeletePatientFileResponse>
        where T : DeletePatientFileResponse
    {
        private readonly GenericViewModel<DeletePatientFileController> _viewModel;

        public DeletePatientFilePresenter(GenericViewModel<DeletePatientFileController> viewModel)
        {
            _viewModel= viewModel;
        }
        public async Task Handle(DeletePatientFileResponse notification, CancellationToken cancellationToken)
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
