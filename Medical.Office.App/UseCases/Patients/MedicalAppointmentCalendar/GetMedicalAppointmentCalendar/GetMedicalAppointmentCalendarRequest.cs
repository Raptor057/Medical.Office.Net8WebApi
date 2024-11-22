using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.GetMedicalAppointmentCalendar.Responses;

namespace Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.GetMedicalAppointmentCalendar
{
    public record GetMedicalAppointmentsRequest(
        long IDPatient,
        long IDDoctor,
        DateTime? AppointmentDateTime,
        string? ReasonForVisit,
        string? AppointmentStatus,
        string? Notes,
        string? TypeOfAppointment) : IRequest<GetMedicalAppointmentCalendarResponse>
    {
        public GetMedicalAppointmentsRequest(long IDPatient, long IDDoctor)
            : this(IDPatient, IDDoctor, null, null, null, null, null)
        { }
    }
}
