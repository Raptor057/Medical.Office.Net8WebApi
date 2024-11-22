using Common.Common;
using Medical.Office.App.Dtos.Patients;

namespace Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.GetMedicalAppointmentCalendar.Responses
{
    public record SuccessGetListMedicalAppointmentCalendarByIDPatientResponse(IEnumerable<MedicalAppointmentCalendarDto> Calendar) : GetMedicalAppointmentCalendarResponse, ISuccess;
}
