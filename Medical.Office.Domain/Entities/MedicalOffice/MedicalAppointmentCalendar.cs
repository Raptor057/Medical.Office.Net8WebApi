namespace Medical.Office.Domain.Entities.MedicalOffice
{
    public class MedicalAppointmentCalendar
    {
        public long Id { get; set; }

        public long IDPatient { get; set; }

        public long IDDoctor { get; set; }

        public DateTime? AppointmentDateTime { get; set; }

        public string? ReasonForVisit { get; set; }

        public string? AppointmentStatus { get; set; }

        public string? Notes { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? TypeOfAppointment { get; set; }

    }

}
