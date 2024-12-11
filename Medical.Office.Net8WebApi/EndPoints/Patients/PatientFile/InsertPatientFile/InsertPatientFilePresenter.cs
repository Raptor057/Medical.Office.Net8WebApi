using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.FilesPatients.InsertPatientFile.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.PatientFile.InsertPatientFile
{
    public sealed class InsertPatientFilePresenter<T> : IPresenter<InsertPatientFileResponse>
        where T : InsertPatientFileResponse
    {
        private readonly GenericViewModel<InsertPatientFileController> _viewModel;

        public InsertPatientFilePresenter(GenericViewModel<InsertPatientFileController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(InsertPatientFileResponse notification, CancellationToken cancellationToken)
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
