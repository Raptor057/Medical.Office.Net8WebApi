using Common.Common;
using Medical.Office.App.Dtos.Patients;

namespace Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.UpdateMedicalAppointmentCalendar.Response
{
    public record SuccessUpdateMedicalAppointmentCalendarResponse(MedicalAppointmentCalendarDto MedicalAppointment) : UpdateMedicalAppointmentCalendarResponse, ISuccess;
}
