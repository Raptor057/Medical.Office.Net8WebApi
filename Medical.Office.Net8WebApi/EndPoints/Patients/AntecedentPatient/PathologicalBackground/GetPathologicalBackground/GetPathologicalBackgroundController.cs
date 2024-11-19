using Azure.Core;
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.GetPathologicalBackground;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PathologicalBackground.GetPathologicalBackground
{
    [Route("[controller]")]
    [ApiController]
    public class GetPathologicalBackgroundController : ControllerBase
    {
        private readonly ILogger<GetPathologicalBackgroundController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetPathologicalBackgroundController> _viewModel;

        public GetPathologicalBackgroundController(ILogger<GetPathologicalBackgroundController> logger, IMediator mediator, GenericViewModel<GetPathologicalBackgroundController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpGet, Route("/api/GetPathologicalBackground/{PatientID}")]
        public async Task<IActionResult> Execute([FromRoute] long PatientID)
        {

            var request = new GetPathologicalBackgroundRequest(PatientID);

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
