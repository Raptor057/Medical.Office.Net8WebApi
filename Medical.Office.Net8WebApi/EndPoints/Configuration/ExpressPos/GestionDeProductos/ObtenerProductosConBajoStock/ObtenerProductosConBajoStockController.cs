using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductosConBajoStock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.ObtenerProductosConBajoStock
{
    [Route("[controller]")]
    [ApiController]
    public class ObtenerProductosConBajoStockController : ControllerBase
    {
        private readonly ILogger<ObtenerProductosConBajoStockController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<ObtenerProductosConBajoStockController> _viewModel;

        public ObtenerProductosConBajoStockController(ILogger<ObtenerProductosConBajoStockController> logger, IMediator mediator, GenericViewModel<ObtenerProductosConBajoStockController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet("/api/ObtenerProductosConBajoStock")]
        public async Task<IActionResult> Execute([FromQuery] int LimiteStock)
        {
            var request = new ObtenerProductosConBajoStockRequest(LimiteStock);

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
