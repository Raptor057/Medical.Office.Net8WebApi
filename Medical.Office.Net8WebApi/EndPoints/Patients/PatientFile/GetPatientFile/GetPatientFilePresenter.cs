using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.FilesPatients.GetPatientFile.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.PatientFile.GetPatientFile
{
    public class GetPatientFilePresenter<T> : IPresenter<GetPatientFileResponse>
        where T : GetPatientFileResponse
    {
        private readonly GenericViewModel<GetPatientFileController> _viewModel;

        public GetPatientFilePresenter(GenericViewModel<GetPatientFileController> viewModel)
        {
            _viewModel = viewModel;
        }

        public async Task Handle(GetPatientFileResponse notification, CancellationToken cancellationToken)
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
