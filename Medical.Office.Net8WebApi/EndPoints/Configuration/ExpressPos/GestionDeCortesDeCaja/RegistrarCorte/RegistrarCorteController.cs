using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.RegistrarCorte;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeCortesDeCaja.RegistrarCorte
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrarCorteController : ControllerBase
    {
        private readonly ILogger<RegistrarCorteController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<RegistrarCorteController> _viewModel;

        public RegistrarCorteController(ILogger<RegistrarCorteController> logger, IMediator mediator, GenericViewModel<RegistrarCorteController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpPost("/api/RegistrarCorte")]
        public async Task<IActionResult> Execute([FromBody] RegistrarCorteRequestBody requestBody)
        {
            var request = new RegistrarCorteRequest(requestBody.FechaHora, requestBody.TotalVendido, requestBody.TotalVentas);

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
