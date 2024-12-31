using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.UpdateMedicalAppointmentCalendar.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.MedicalAppointmentCalendar.UpdateMedicalAppointmentCalendar;

public class UpdateMedicalAppointmentCalendarPresenter<T> : IPresenter<UpdateMedicalAppointmentCalendarResponse>
where T : UpdateMedicalAppointmentCalendarResponse
{
    private readonly GenericViewModel<UpdateMedicalAppointmentCalendarController> _viewModel;

    public UpdateMedicalAppointmentCalendarPresenter(GenericViewModel<UpdateMedicalAppointmentCalendarController> viewModel)
    {
        _viewModel=viewModel;
    }
    public async Task Handle(UpdateMedicalAppointmentCalendarResponse notification, CancellationToken cancellationToken)
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
