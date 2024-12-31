
namespace Medical.Office.App.Dtos.Patients
{
    public record MedicalAppointmentCalendarDto(

        long Id,
        long IDPatient,
        long IDDoctor,
        DateTime AppointmentDateTime,
        string ReasonForVisit,
        string AppointmentStatus,
        string Notes,
        DateTime? EndOfAppointmentDateTime,
        DateTime? CreatedAt,
        DateTime? UpdatedAt,
        string TypeOfAppointment
    );
}
