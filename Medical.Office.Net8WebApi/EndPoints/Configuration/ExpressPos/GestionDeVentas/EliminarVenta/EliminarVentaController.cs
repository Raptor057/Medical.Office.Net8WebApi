using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.EliminarVenta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeVentas.EliminarVenta
{
    [Route("[controller]")]
    [ApiController]
    public class EliminarVentaController : ControllerBase
    {
        private readonly ILogger<EliminarVentaController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<EliminarVentaController> _viewModel;

        public EliminarVentaController(ILogger<EliminarVentaController> logger, IMediator mediator, GenericViewModel<EliminarVentaController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpDelete("/api/EliminarVenta/{VentaID}")]
        public async Task<IActionResult> Execute([FromRoute] int VentaID)
        {
            var request = new EliminarVentaRequest(VentaID);

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
