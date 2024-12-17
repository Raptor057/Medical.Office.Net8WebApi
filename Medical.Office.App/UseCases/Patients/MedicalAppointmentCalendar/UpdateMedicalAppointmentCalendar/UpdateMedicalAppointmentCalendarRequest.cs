using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.UpdateMedicalAppointmentCalendar.Response;

namespace Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.UpdateMedicalAppointmentCalendar
{
    public record UpdateMedicalAppointmentCalendarRequest(MedicalAppointmentCalendarDto MedicalAppointment) : IRequest<UpdateMedicalAppointmentCalendarResponse>;
}
