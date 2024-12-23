using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.AgregarProducto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.ActualizarProducto
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgregarProductoController : ControllerBase
    {
        private readonly ILogger<AgregarProductoController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<AgregarProductoController> _viewModel;

        public AgregarProductoController(ILogger<AgregarProductoController> logger, IMediator mediator,
            GenericViewModel<AgregarProductoController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpPost("AgregarProducto")]
        public async Task<IActionResult> Execute([FromBody] AgregarProductoRequestBody requestBody)
        {
            var request = new AgregarProductoRequest(requestBody.Nombre, requestBody.Precio, requestBody.Stock);

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