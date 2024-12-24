using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentasPorRango;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeVentas.ObtenerVentasPorRango
{
    [Route("[controller]")]
    [ApiController]
    public class ObtenerVentasPorRangoController : ControllerBase
    {
        private readonly ILogger<ObtenerVentasPorRangoController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<ObtenerVentasPorRangoController> _viewModel;

        public ObtenerVentasPorRangoController(ILogger<ObtenerVentasPorRangoController> logger, IMediator mediator, GenericViewModel<ObtenerVentasPorRangoController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet("/api/ObtenerVentasPorRango")]
        public async Task<IActionResult> Execute([FromQuery] string FechaInicio, [FromQuery] string FechaFin)
        {
            try
            {
                var fechaInicioParsed = DateTime.Parse(FechaInicio);
                var fechaFinParsed = DateTime.Parse(FechaFin);

                var request = new ObtenerVentasPorRangoRequest(fechaInicioParsed, fechaFinParsed);

                var response = await _mediator.Send(request).ConfigureAwait(false);
                return Ok(response);
            }
            catch (FormatException ex)
            {
                _logger.LogError(ex, "Formato de fecha inválido.");
                return BadRequest("Formato de fecha inválido. Use yyyy-MM-ddTHH:mm:ss.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error interno.");
                return StatusCode(500, "Error interno.");
            }
        }

    }
}
