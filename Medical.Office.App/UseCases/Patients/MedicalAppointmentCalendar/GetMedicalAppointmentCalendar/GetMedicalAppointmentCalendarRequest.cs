using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.GetMedicalAppointmentCalendar.Responses;

namespace Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.GetMedicalAppointmentCalendar
{
    public record GetMedicalAppointmentsRequest(long IDPatient,long IDDoctor) : IRequest<GetMedicalAppointmentCalendarResponse>;
}
