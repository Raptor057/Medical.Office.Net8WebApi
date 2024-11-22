using Common.Common;
using Medical.Office.App.Dtos.Patients;

namespace Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.GetMedicalAppointmentCalendar.Responses
{
    public record SuccessGetLastMedicalAppointmentCalendarByIDPatientResponse(MedicalAppointmentCalendarDto Calendar) : GetMedicalAppointmentCalendarResponse, ISuccess;
    
}
