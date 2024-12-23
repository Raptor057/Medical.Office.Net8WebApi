using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ActualizarProducto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.ActualizarProducto
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualizarProductoController : ControllerBase
    {
        private readonly ILogger<ActualizarProductoController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<ActualizarProductoController> _viewModel;

        public ActualizarProductoController(ILogger<ActualizarProductoController> logger, IMediator mediator, GenericViewModel<ActualizarProductoController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpPut("ActualizarProducto/{ProductoID}")]
        public async Task<IActionResult> Execute([FromRoute] int ProductoID, [FromBody] ActualizarProductoRequestBody requestBody)
        {
            var request = new ActualizarProductoRequest(ProductoID, requestBody.Nombre, requestBody.Precio, requestBody.Stock);

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
