using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PsychiatricHistory;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.UpdatePsychiatricHistory;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PsychiatricHistory.UpdatePsychiatricHistory
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatePsychiatricHistoryController : ControllerBase
    {
        private readonly ILogger<UpdatePsychiatricHistoryController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<UpdatePsychiatricHistoryController> _viewModel;

        public UpdatePsychiatricHistoryController(ILogger<UpdatePsychiatricHistoryController> logger, IMediator mediator, GenericViewModel<UpdatePsychiatricHistoryController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpPatch, Route("/api/UpdatePsychiatricHistory/{IdPatient}")]
        public async Task<IActionResult> Execute([FromRoute] long IdPatient, [FromBody] UpdatePsychiatricHistoryRequestBody requestBody)
        {
            var request = new UpdatePsychiatricHistoryRequest(new PsychiatricHistoryDto(
                0, // Assuming Id is generated elsewhere
                IdPatient,
                requestBody.FamilyHistory,
                requestBody.FamilyHistoryData,
                requestBody.AffectedAreas,
                requestBody.PastAndCurrentTreatments,
                requestBody.FamilySocialSupport,
                requestBody.FamilySocialSupportData,
                requestBody.WorkLifeAspects,
                requestBody.SocialLifeAspects,
                requestBody.AuthorityRelationship,
                requestBody.ImpulseControl,
                requestBody.FrustrationManagement,
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