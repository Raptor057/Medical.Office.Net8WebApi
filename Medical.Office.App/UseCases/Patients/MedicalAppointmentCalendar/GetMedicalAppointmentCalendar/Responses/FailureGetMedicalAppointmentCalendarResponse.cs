using Common.Common;

namespace Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.GetMedicalAppointmentCalendar.Responses
{
    public record FailureGetMedicalAppointmentCalendarResponse(string Message):GetMedicalAppointmentCalendarResponse, IFailure; 
}
