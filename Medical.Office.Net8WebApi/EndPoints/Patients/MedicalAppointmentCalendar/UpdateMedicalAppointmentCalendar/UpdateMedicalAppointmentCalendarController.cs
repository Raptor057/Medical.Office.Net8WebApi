using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.UpdateMedicalAppointmentCalendar;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.MedicalAppointmentCalendar.UpdateMedicalAppointmentCalendar
{
    [Route("[controller]")]
    [ApiController]
    public class UpdateMedicalAppointmentCalendarController : ControllerBase
    {
        private readonly ILogger<UpdateMedicalAppointmentCalendarController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<UpdateMedicalAppointmentCalendarController> _viewModel;

        public UpdateMedicalAppointmentCalendarController(ILogger<UpdateMedicalAppointmentCalendarController> logger,
            IMediator mediator, GenericViewModel<UpdateMedicalAppointmentCalendarController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpPatch, Route("/api/UpdateMedicalAppointmentCalendar/{Id}")]
        public async Task<IActionResult> Execute([FromRoute] long Id,
            [FromBody] UpdateMedicalAppointmentCalendarRequestBody requestBody)
        {
            // Crear el DTO
            var calendarDto = new MedicalAppointmentCalendarDto(
                Id,
                0,
                requestBody.IDDoctor,
                requestBody.AppointmentDateTime,
                requestBody.ReasonForVisit,
                "",
                requestBody.Notes,
                DateTime.Now, 
                DateTime.Now, 
                DateTime.Now, 
                requestBody.TypeOfAppointment
            );

            // Crear la solicitud correcta
            var request = new UpdateMedicalAppointmentCalendarRequest(calendarDto);


            try
            {
                // Enviar la solicitud al mediador
                var response = await _mediator.Send(request).ConfigureAwait(false);

                // Verificar la respuesta y devolver el resultado adecuado
                return _viewModel.IsSuccess ? Ok(response) : StatusCode(500, _viewModel);
            }
            catch (Exception ex)
            {
                var innerEx = ex;
                while (innerEx.InnerException != null) innerEx = innerEx.InnerException!;
                return StatusCode(500, _viewModel.Fail(innerEx.Message));
            }
        }
    }
}
