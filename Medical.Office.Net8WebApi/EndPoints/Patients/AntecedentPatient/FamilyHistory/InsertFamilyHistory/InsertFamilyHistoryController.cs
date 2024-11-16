using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.InsertFamilyHistory;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.FamilyHistory.InsertFamilyHistory
{
    [Route("[controller]")]
    [ApiController]
    public class InsertFamilyHistoryController : ControllerBase
    {
        private readonly ILogger<InsertFamilyHistoryController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertFamilyHistoryController> _viewModel;

        public InsertFamilyHistoryController(ILogger<InsertFamilyHistoryController> logger, IMediator mediator, GenericViewModel<InsertFamilyHistoryController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpPost,Route("/api/insertfamilyhistory")]
        public async Task<IActionResult> Execute([FromBody] InsertFamilyHistoryRequestBody requestBody)
        {
            var request = new InsertFamilyHistoryRequest(
                requestBody.IDPatient,
                requestBody.Diabetes,
                requestBody.Cardiopathies,
                requestBody.Hypertension,
                requestBody.ThyroidDiseases,
                requestBody.ChronicKidneyDisease,
                requestBody.Others,
                requestBody.OthersData);

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
