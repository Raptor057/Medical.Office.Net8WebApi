using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerDetalleDeVentas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GeneracionDeReportes.ObtenerDetalleDeVentas
{
    [Route("[controller]")]
    [ApiController]
    public class ObtenerDetalleDeVentasController : ControllerBase
    {
        private readonly ILogger<ObtenerDetalleDeVentasController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<ObtenerDetalleDeVentasController> _viewModel;

        public ObtenerDetalleDeVentasController(ILogger<ObtenerDetalleDeVentasController> logger, IMediator mediator, GenericViewModel<ObtenerDetalleDeVentasController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet("/api/ObtenerDetalleDeVentas/{ventaID}")]
        public async Task<IActionResult> Execute([FromRoute] int ventaID)
        {
            var request = new ObtenerDetalleDeVentasRequest(ventaID);

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
