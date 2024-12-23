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
        public async Task<IActionResult> Execute([FromQuery] DateTime FechaInicio, [FromQuery] DateTime FechaFin)
        {
            var request = new ObtenerVentasPorRangoRequest(FechaInicio, FechaFin);

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
