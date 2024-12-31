using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.GetMedicalAppointmentCalendar.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.MedicalAppointmentCalendar.GetMedicalAppointmentCalendar
{
    public sealed class GetMedicalAppointmentCalendarPresenter<T> : IPresenter<GetMedicalAppointmentCalendarResponse>
        where T : GetMedicalAppointmentCalendarResponse
    {
        private readonly GenericViewModel<GetMedicalAppointmentCalendarController> _viewModel;
        public GetMedicalAppointmentCalendarPresenter(GenericViewModel<GetMedicalAppointmentCalendarController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(GetMedicalAppointmentCalendarResponse notification, CancellationToken cancellationToken)
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
