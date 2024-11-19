using Azure.Core;
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.GetPatientAllergies;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PatientAllergies.GetPatientAllergies
{
    [Route("[controller]")]
    [ApiController]
    public class GetPatientAllergiesController : ControllerBase
    {
        private readonly ILogger<GetPatientAllergiesController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetPatientAllergiesController> _viewModel;

        public GetPatientAllergiesController(ILogger<GetPatientAllergiesController> logger, IMediator mediator, GenericViewModel<GetPatientAllergiesController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpGet, Route("/api/GetPatientAllergies/{PatientID}")]
        public async Task<IActionResult> Execute([FromRoute] long PatientID)
        {

            var request = new GetPatientAllergiesRequest(PatientID);

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
