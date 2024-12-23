using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ActualizarStock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.ActualizarStock
{
    [Route("[controller]")]
    [ApiController]
    public class ActualizarStockController : ControllerBase
    {
        private readonly ILogger<ActualizarStockController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<ActualizarStockController> _viewModel;

        public ActualizarStockController(ILogger<ActualizarStockController> logger, IMediator mediator, GenericViewModel<ActualizarStockController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpPatch("/api/ActualizarStock/{ProductoID}")]
        public async Task<IActionResult> Execute([FromRoute] int ProductoID, [FromBody] ActualizarStockRequestBody requestBody)
        {
            var request = new ActualizarStockRequest(ProductoID, requestBody.NuevoStock);

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
