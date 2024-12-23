using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.EliminarProducto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.EliminarProducto
{
    [Route("[controller]")]
    [ApiController]
    public class EliminarProductoController : ControllerBase
    {
        private readonly ILogger<EliminarProductoController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<EliminarProductoController> _viewModel;

        public EliminarProductoController(ILogger<EliminarProductoController> logger, IMediator mediator, GenericViewModel<EliminarProductoController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpDelete("/api/EliminarProducto/{ProductoID}")]
        public async Task<IActionResult> Execute([FromRoute] int ProductoID)
        {
            var request = new EliminarProductoRequest(ProductoID);

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
