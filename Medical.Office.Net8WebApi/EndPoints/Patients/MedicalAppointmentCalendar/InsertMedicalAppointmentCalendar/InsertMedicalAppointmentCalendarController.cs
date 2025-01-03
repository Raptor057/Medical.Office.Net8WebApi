using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.InsertMedicalAppointmentCalendar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.MedicalAppointmentCalendar.InsertMedicalAppointmentCalendar
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class InsertMedicalAppointmentCalendarController : ControllerBase
    {
        private readonly ILogger<InsertMedicalAppointmentCalendarController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertMedicalAppointmentCalendarController> _viewModel;

        public InsertMedicalAppointmentCalendarController(ILogger<InsertMedicalAppointmentCalendarController> logger, IMediator mediator, GenericViewModel<InsertMedicalAppointmentCalendarController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpPost, Route("/api/InsertMedicalAppointmentCalendar")]
        public async Task<IActionResult> Execute([FromBody] InsertMedicalAppointmentCalendarRequestBody requestBody)
        {
            // Crear el DTO
            var calendarDto = new MedicalAppointmentCalendarDto(
                0,
                requestBody.IDPatient,
                "", // No se envía el nombre del paciente
                requestBody.IDDoctor,
                "", // No se envía el nombre del doctor
                requestBody.AppointmentDateTime,
                requestBody.ReasonForVisit,
                "", // No se envía el estado de la cita
                requestBody.Notes,
                DateTime.Now,// No se envía el estado de la cita
                DateTime.Now,// No se envía el estado de la cita
                DateTime.Now,// No se envía el estado de la cita
                requestBody.TypeOfAppointment
            );

            // Validar los datos
            if (!InsertMedicalAppointmentCalendarRequest.CanInsertMedicalAppointment(calendarDto, out var errors))
            {
                // Devolver errores en lugar de lanzar una excepción
                return BadRequest(_viewModel.Fail(string.Join("\n", errors)));
            }

            // Crear la solicitud correcta
            var request = InsertMedicalAppointmentCalendarRequest.InsertMedicalAppointmentCalendar(calendarDto);

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
