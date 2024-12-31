namespace Medical.Office.Net8WebApi.EndPoints.Patients.MedicalAppointmentCalendar.UpdateMedicalAppointmentCalendar;

public class UpdateMedicalAppointmentCalendarRequestBody
{
    public long IDDoctor { get; set; }

    public DateTime AppointmentDateTime { get; set; }

    public string ReasonForVisit { get; set; }

    public string Notes { get; set; }
        
    public string TypeOfAppointment { get; set; }
}