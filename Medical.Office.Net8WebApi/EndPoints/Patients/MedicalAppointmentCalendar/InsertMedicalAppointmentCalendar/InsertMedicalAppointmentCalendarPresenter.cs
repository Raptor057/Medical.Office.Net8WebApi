using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.InsertMedicalAppointmentCalendar.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.MedicalAppointmentCalendar.InsertMedicalAppointmentCalendar
{
    public sealed class InsertMedicalAppointmentCalendarPresenter<T> : IPresenter<InsertMedicalAppointmentCalendarResponse>
        where T : InsertMedicalAppointmentCalendarResponse
    {
        private readonly GenericViewModel<InsertMedicalAppointmentCalendarController> _viewModel;

        public InsertMedicalAppointmentCalendarPresenter(GenericViewModel<InsertMedicalAppointmentCalendarController> viewModel)
        {
            
            _viewModel=viewModel;
        }
        public async Task Handle(InsertMedicalAppointmentCalendarResponse notification, CancellationToken cancellationToken)
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
