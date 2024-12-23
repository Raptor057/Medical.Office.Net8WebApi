using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerResumenDeCortesPorDia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GeneracionDeReportes.ObtenerResumenDeCortesPorDia
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObtenerResumenDeCortesPorDiaController : ControllerBase
    {
        private readonly ILogger<ObtenerResumenDeCortesPorDiaController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<ObtenerResumenDeCortesPorDiaController> _viewModel;

        public ObtenerResumenDeCortesPorDiaController(ILogger<ObtenerResumenDeCortesPorDiaController> logger, IMediator mediator, GenericViewModel<ObtenerResumenDeCortesPorDiaController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet("ObtenerResumenDeCortesPorDia")]
        public async Task<IActionResult> Execute([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            var request = new ObtenerResumenDeCortesPorDiaRequest(fechaInicio, fechaFin);

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
