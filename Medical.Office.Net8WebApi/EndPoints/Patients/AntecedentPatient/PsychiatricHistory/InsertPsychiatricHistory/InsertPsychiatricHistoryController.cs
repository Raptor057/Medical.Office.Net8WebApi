using Azure.Core;
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.InsertPsychiatricHistory;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PsychiatricHistory.InsertPsychiatricHistory
{
    [Route("[controller]")]
    [ApiController]
    public class InsertPsychiatricHistoryController : ControllerBase
    {
        private readonly ILogger<InsertPsychiatricHistoryController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertPsychiatricHistoryController> _viewModel;

        public InsertPsychiatricHistoryController(ILogger<InsertPsychiatricHistoryController> logger, IMediator mediator, GenericViewModel<InsertPsychiatricHistoryController> viewModel)
        {
            _logger= logger;
            _mediator = mediator;
            _viewModel = viewModel;

        }

        [HttpPost, Route("/api/insertpsychiatricHistory")]
        public async Task<IActionResult> Execute([FromBody] InsertPsychiatricHistoryRequestBody requestBody)
        {
            var request = new InsertPsychiatricHistoryRequest(
                requestBody.IDPatient,
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
                requestBody.FrustrationManagement);

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
