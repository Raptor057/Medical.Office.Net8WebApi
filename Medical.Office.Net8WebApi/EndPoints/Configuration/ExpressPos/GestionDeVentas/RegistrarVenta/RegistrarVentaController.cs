using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.RegistrarVenta.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeVentas.RegistrarVenta
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrarVentaController : ControllerBase
    {
        private readonly ILogger<RegistrarVentaController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<RegistrarVentaController> _viewModel;

        public RegistrarVentaController(ILogger<RegistrarVentaController> logger, IMediator mediator, GenericViewModel<RegistrarVentaController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpPost("/api/RegistrarVenta")]
        public async Task<IActionResult> Execute([FromBody] RegistrarVentaRequestBody requestBody)
        {
            _logger.LogDebug("Request recibido: {@RequestBody}", requestBody);

            if (requestBody == null || !requestBody.Productos.Any())
            {
                _logger.LogWarning("El cuerpo de la solicitud es inválido.");
                return BadRequest("El cuerpo de la solicitud es inválido.");
            }

            try
            {
                var request = new RegistrarVentaRequest(
                    requestBody.FechaHora,
                    requestBody.Productos.Select(p => (p.ProductoID, p.Cantidad)));

                _ = await _mediator.Send(request).ConfigureAwait(false);
                return _viewModel.IsSuccess ? Ok(_viewModel) : StatusCode(500, _viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar la venta.");
                return StatusCode(500, _viewModel.Fail("Error interno."));
            }
        }
    }
}
