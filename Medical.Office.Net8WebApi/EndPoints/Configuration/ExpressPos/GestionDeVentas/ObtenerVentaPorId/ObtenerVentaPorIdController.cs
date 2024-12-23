using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentaPorId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeVentas.ObtenerVentaPorId
{
    [Route("[controller]")]
    [ApiController]
    public class ObtenerVentaPorIdController : ControllerBase
    {
        private readonly ILogger<ObtenerVentaPorIdController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<ObtenerVentaPorIdController> _viewModel;

        public ObtenerVentaPorIdController(ILogger<ObtenerVentaPorIdController> logger, IMediator mediator, GenericViewModel<ObtenerVentaPorIdController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet("/api/ObtenerVentaPorId/{VentaID}")]
        public async Task<IActionResult> Execute([FromRoute] int VentaID)
        {
            var request = new ObtenerVentaPorIdRequest(VentaID);

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
