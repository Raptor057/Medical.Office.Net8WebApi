using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.GetMedicalAppointmentCalendar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.MedicalAppointmentCalendar.GetMedicalAppointmentCalendar
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class GetMedicalAppointmentCalendarController : ControllerBase
    {
        private readonly ILogger<GetMedicalAppointmentCalendarController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetMedicalAppointmentCalendarController> _viewModel;
        public GetMedicalAppointmentCalendarController(ILogger<GetMedicalAppointmentCalendarController> logger, IMediator mediator, GenericViewModel<GetMedicalAppointmentCalendarController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet, Route("/api/GetMedicalAppointmentCalendar/{IdPatient}/{IdDoctor}")]
        public async Task<IActionResult> Execute([FromRoute] long IdPatient, long IdDoctor)
        {
            // Crear la solicitud correcta
            var request = new GetMedicalAppointmentsRequest(IdPatient, IdDoctor);

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
