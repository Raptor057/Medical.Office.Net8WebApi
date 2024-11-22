using Common.Common;

namespace Medical.Office.App.UseCases.Patients.InsertMedicalAppointmentCalendar.Response
{
    public record FailureInsertMedicalAppointmentCalendarResponse(string Message): InsertMedicalAppointmentCalendarResponse, IFailure;
}
