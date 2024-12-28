using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.MedicalAppointmentCalendar.GetMedicalAppointmentCalendar
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GetMedicalAppointmentCalendarController : ControllerBase
    {

    }
}
