using Common.Common;

namespace Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.UpdateMedicalAppointmentCalendar.Response
{
    public record FailureUpdateMedicalAppointmentCalendarResponse(string Message) : UpdateMedicalAppointmentCalendarResponse, IFailure;

}
