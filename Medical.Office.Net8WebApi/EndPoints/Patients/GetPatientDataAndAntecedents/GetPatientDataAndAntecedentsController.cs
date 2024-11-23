using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.GetPatientDataAndAntecedents;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.GetPatientDataAndAntecedents
{
    [Route("[controller]")]
    [ApiController]
    public class GetPatientDataAndAntecedentsController : ControllerBase
    {
        private readonly ILogger<GetPatientDataAndAntecedentsController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetPatientDataAndAntecedentsController> _viewModel;

        public GetPatientDataAndAntecedentsController(ILogger<GetPatientDataAndAntecedentsController> logger, IMediator mediator, GenericViewModel<GetPatientDataAndAntecedentsController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }
        [HttpGet,Route("/api/GetPatientDataAndAntecedents/{IDPatient}")]
        public async Task<IActionResult> Execute([FromRoute] long IDPatient)
        {
            var request = new GetPatientDataAndAntecedentsRequest(IDPatient);

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
