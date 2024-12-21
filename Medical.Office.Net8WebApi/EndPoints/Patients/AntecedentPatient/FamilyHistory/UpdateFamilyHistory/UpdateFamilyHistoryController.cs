using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.FamilyHistory;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.UpdateFamilyHistory;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.FamilyHistory.UpdateFamilyHistory
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateFamilyHistoryController : ControllerBase
    {
        private readonly ILogger<UpdateFamilyHistoryController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<UpdateFamilyHistoryController> _viewModel;

        public UpdateFamilyHistoryController(ILogger<UpdateFamilyHistoryController> logger, IMediator mediator, GenericViewModel<UpdateFamilyHistoryController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpPatch, Route("/api/UpdateFamilyHistory/{IdPatient}")]
        public async Task<IActionResult> Execute([FromRoute] long IdPatient, [FromBody] UpdateFamilyHistoryRequestBody requestBody)
        {
            var request = new UpdateFamilyHistoryRequest(new FamilyHistoryDto(
                0, // Assuming Id is generated elsewhere
                IdPatient,
                requestBody.Diabetes,
                requestBody.Cardiopathies,
                requestBody.Hypertension,
                requestBody.ThyroidDiseases,
                requestBody.ChronicKidneyDisease,
                requestBody.Others,
                requestBody.OthersData,
                DateTime.Now // Assigning DateTimeSnap in the backend
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