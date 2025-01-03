
namespace Medical.Office.App.Dtos.Patients
{
    public record MedicalAppointmentCalendarDto(

        long Id,
        long IDPatient,
        string patientName,
        long IDDoctor,
        string doctorName,
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
