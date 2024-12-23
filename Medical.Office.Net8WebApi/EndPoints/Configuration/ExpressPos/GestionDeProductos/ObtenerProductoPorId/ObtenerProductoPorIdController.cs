using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductoPorId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.ObtenerProductoPorId
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObtenerProductoPorIdController : ControllerBase
    {
        private readonly ILogger<ObtenerProductoPorIdController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<ObtenerProductoPorIdController> _viewModel;

        public ObtenerProductoPorIdController(ILogger<ObtenerProductoPorIdController> logger, IMediator mediator, GenericViewModel<ObtenerProductoPorIdController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet("ObtenerProductoPorId/{ProductoID}")]
        public async Task<IActionResult> Execute([FromRoute] int ProductoID)
        {
            var request = new ObtenerProductoPorIdRequest(ProductoID);

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
