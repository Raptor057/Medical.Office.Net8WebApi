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
            _logger.LogInformation($"Request recibido: FechaHora={requestBody.FechaHora}, Productos={string.Join(", ", requestBody.Productos.Select(p => $"ProductoID={p.ProductoID}, Cantidad={p.Cantidad}"))}");

            var request = new RegistrarVentaRequest(
                requestBody.FechaHora,
                //0,
                requestBody.Productos.Select(p => (p.ProductoID, p.Cantidad)));


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
