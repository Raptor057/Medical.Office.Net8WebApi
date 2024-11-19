using Azure.Core;
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.InsertPatientAllergies;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PatientAllergies.InsertPatientAllergies
{
    [Route("[controller]")]
    [ApiController]
    public class InsertPatientAllergiesController : ControllerBase
    {
        private readonly ILogger<InsertPatientAllergiesController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertPatientAllergiesController> _viewModel;

        public InsertPatientAllergiesController(ILogger<InsertPatientAllergiesController> logger, IMediator mediator, GenericViewModel<InsertPatientAllergiesController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpPost, Route("/api/InsertPatientAllergies")]
        public async Task<IActionResult> Execute([FromBody] InsertPatientAllergiesRequestBody requestBody)
        {

            var request = new InsertPatientAllergiesRequest(
                requestBody.IDPatient,
                requestBody.Allergies);

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
