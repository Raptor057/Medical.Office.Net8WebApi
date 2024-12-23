using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerVentasPorDia;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GeneracionDeReportes.ObtenerDetalleDeVentas
{
    [Route("[controller]")]
    [ApiController]
    public class ObtenerVentasPorDiaController : ControllerBase
    {
        private readonly ILogger<ObtenerVentasPorDiaController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<ObtenerVentasPorDiaController> _viewModel;

        public ObtenerVentasPorDiaController(ILogger<ObtenerVentasPorDiaController> logger, IMediator mediator, GenericViewModel<ObtenerVentasPorDiaController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet("/api/ObtenerVentasPorDia")]
        public async Task<IActionResult> Execute([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            var request = new ObtenerVentasPorDiaRequest(fechaInicio, fechaFin);

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