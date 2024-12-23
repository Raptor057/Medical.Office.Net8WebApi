using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerTodosLosCortes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeCortesDeCaja.ObtenerTodosLosCortes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObtenerTodosLosCortesController : ControllerBase
    {
        private readonly ILogger<ObtenerTodosLosCortesController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<ObtenerTodosLosCortesController> _viewModel;

        public ObtenerTodosLosCortesController(ILogger<ObtenerTodosLosCortesController> logger, IMediator mediator, GenericViewModel<ObtenerTodosLosCortesController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet("ObtenerTodosLosCortes")]
        public async Task<IActionResult> Execute()
        {
            var request = new ObtenerTodosLosCortesRequest();

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
