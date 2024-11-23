namespace Medical.Office.Net8WebApi.EndPoints.Patients.MedicalAppointmentCalendar.InsertMedicalAppointmentCalendar
{
    public class InsertMedicalAppointmentCalendarRequestBody
    {
        public long IDPatient { get; set; }
        public long IDDoctor { get; set; }
        public DateTime? AppointmentDateTime { get; set; }
        public string? ReasonForVisit { get; set; }
        public string? AppointmentStatus { get; set; }
        public string? Notes { get; set; }
        public string? TypeOfAppointment { get; set; }
    }
}
