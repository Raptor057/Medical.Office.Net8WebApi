using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PathologicalBackground;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.UpdatePathologicalBackground;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PathologicalBackground.UpdatePathologicalBackground
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatePathologicalBackgroundController : ControllerBase
    {
        private readonly ILogger<UpdatePathologicalBackgroundController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<UpdatePathologicalBackgroundController> _viewModel;

        public UpdatePathologicalBackgroundController(ILogger<UpdatePathologicalBackgroundController> logger, IMediator mediator, GenericViewModel<UpdatePathologicalBackgroundController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpPatch, Route("/api/UpdatePathologicalBackground/{IdPatient}")]
        public async Task<IActionResult> Execute([FromRoute] long IdPatient, [FromBody] UpdatePathologicalBackgroundRequestBody requestBody)
        {
            var request = new UpdatePathologicalBackgroundRequest(new PathologicalBackgroundDto(
                0, // Assuming Id is generated elsewhere
                IdPatient,
                requestBody.PreviousHospitalization,
                requestBody.PreviousSurgeries,
                requestBody.Diabetes,
                requestBody.ThyroidDiseases,
                requestBody.Hypertension,
                requestBody.Cardiopathies,
                requestBody.Trauma,
                requestBody.Cancer,
                requestBody.Tuberculosis,
                requestBody.Transfusions,
                requestBody.RespiratoryDiseases,
                requestBody.GastrointestinalDiseases,
                requestBody.STDs,
                requestBody.STDsData,
                requestBody.ChronicKidneyDisease,
                requestBody.Others,
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