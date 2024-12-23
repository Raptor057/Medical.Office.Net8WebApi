using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerCortesPorRango;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeCortesDeCaja.ObtenerCortesPorRango
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObtenerCortesPorRangoController : ControllerBase
    {
        private readonly ILogger<ObtenerCortesPorRangoController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<ObtenerCortesPorRangoController> _viewModel;

        public ObtenerCortesPorRangoController(ILogger<ObtenerCortesPorRangoController> logger, IMediator mediator, GenericViewModel<ObtenerCortesPorRangoController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet("ObtenerCortesPorRango")]
        public async Task<IActionResult> Execute([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            var request = new ObtenerCortesPorRangoRequest(fechaInicio, fechaFin);

            try
            {
                _ = await _mediator.Send(request).ConfigureAwait(false);
                return _viewModel.IsSuccess ? Ok(_viewModel) : StatusCode(500, _viewModel);
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
