using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.EliminarCorte;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeCortesDeCaja.EliminarCorte
{
    [Route("api/[controller]")]
    [ApiController]
    public class EliminarCorteController : ControllerBase
    {
        private readonly ILogger<EliminarCorteController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<EliminarCorteController> _viewModel;

        public EliminarCorteController(ILogger<EliminarCorteController> logger, IMediator mediator, GenericViewModel<EliminarCorteController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpDelete("EliminarCorte/{corteID}")]
        public async Task<IActionResult> Execute([FromRoute] int corteID)
        {
            var request = new EliminarCorteRequest(corteID);

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
