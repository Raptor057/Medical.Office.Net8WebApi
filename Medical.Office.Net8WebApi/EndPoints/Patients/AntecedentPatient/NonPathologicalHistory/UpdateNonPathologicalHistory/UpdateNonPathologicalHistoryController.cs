using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.NonPathologicalHistory;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.UpdateNonPathologicalHistory;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.NonPathologicalHistory.UpdateNonPathologicalHistory
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateNonPathologicalHistoryController : ControllerBase
    {
        private readonly ILogger<UpdateNonPathologicalHistoryController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<UpdateNonPathologicalHistoryController> _viewModel;

        public UpdateNonPathologicalHistoryController(ILogger<UpdateNonPathologicalHistoryController> logger, IMediator mediator, GenericViewModel<UpdateNonPathologicalHistoryController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpPatch, Route("/api/UpdateNonPathologicalHistory/{IdPatient}")]
        public async Task<IActionResult> Execute([FromRoute] long IdPatient, [FromBody] UpdateNonPathologicalHistoryRequestBody requestBody)
        {
            var request = new UpdateNonPathologicalHistoryRequest(new NonPathologicalHistoryDto(
                0, // Assuming Id is generated elsewhere
                IdPatient,
                requestBody.PhysicalActivity,
                requestBody.Smoking,
                requestBody.Alcoholism,
                requestBody.SubstanceAbuse,
                requestBody.SubstanceAbuseData,
                requestBody.RecentVaccination,
                requestBody.RecentVaccinationData,
                requestBody.Others,
                requestBody.OthersData,
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