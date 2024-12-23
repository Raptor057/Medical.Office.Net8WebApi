using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerTodosLosProductos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.ObtenerTodosLosProductos
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObtenerTodosLosProductosController : ControllerBase
    {
        private readonly ILogger<ObtenerTodosLosProductosController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<ObtenerTodosLosProductosController> _viewModel;

        public ObtenerTodosLosProductosController(ILogger<ObtenerTodosLosProductosController> logger, IMediator mediator, GenericViewModel<ObtenerTodosLosProductosController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet("ObtenerTodosLosProductos")]
        public async Task<IActionResult> Execute()
        {
            var request = new ObtenerTodosLosProductosRequest();

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
