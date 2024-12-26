using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PatientAllergies;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.UpdatePatientAllergies;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PatientAllergies.UpdatePatientAllergies
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatePatientAllergiesController : ControllerBase
    {
        private readonly ILogger<UpdatePatientAllergiesController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<UpdatePatientAllergiesController> _viewModel;

        public UpdatePatientAllergiesController(ILogger<UpdatePatientAllergiesController> logger, IMediator mediator, GenericViewModel<UpdatePatientAllergiesController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpPatch, Route("/api/UpdatePatientAllergies/{IdPatient}")]
        public async Task<IActionResult> Execute([FromRoute] long IdPatient, [FromBody] UpdatePatientAllergiesRequestBody requestBody)
        {
            var request = new UpdatePatientAllergiesRequest(new PatientAllergiesDto(
                0, // Assuming Id is generated elsewhere
                IdPatient,
                requestBody.Allergies,
                DateTime.UtcNow // Assigning DateTimeSnap in the backend
            ));

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