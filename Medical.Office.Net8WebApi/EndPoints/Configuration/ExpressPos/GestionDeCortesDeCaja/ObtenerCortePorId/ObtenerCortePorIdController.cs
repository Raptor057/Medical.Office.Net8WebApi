using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerCortePorId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeCortesDeCaja.ObtenerCortePorId
{
    [Route("[controller]")]
    [ApiController]
    public class ObtenerCortePorIdController : ControllerBase
    {
        private readonly ILogger<ObtenerCortePorIdController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<ObtenerCortePorIdController> _viewModel;

        public ObtenerCortePorIdController(ILogger<ObtenerCortePorIdController> logger, IMediator mediator, GenericViewModel<ObtenerCortePorIdController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet("/api/ObtenerCortePorId/{corteID}")]
        public async Task<IActionResult> Execute([FromRoute] int corteID)
        {
            var request = new ObtenerCortePorIdRequest(corteID);

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
