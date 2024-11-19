using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.InsertNonPathologicalHistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.NonPathologicalHistory.InsertNonPathologicalHistory
{
    [Route("[controller]")]
    [ApiController]
    public class InsertNonPathologicalHistoryController : ControllerBase
    {
        private readonly ILogger<InsertNonPathologicalHistoryController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertNonPathologicalHistoryController> _viewModel;

        public InsertNonPathologicalHistoryController(ILogger<InsertNonPathologicalHistoryController> logger, IMediator mediator, GenericViewModel<InsertNonPathologicalHistoryController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpPost, Route("/api/InsertNonPathologicalHistory")]
        public async Task<IActionResult> Execute([FromBody] InsertNonPathologicalHistoryRequestBody requestBody)
        {
            var request = new InsertNonPathologicalHistoryRequest(
                requestBody.IDPatient,
                requestBody.PhysicalActivity,
                requestBody.Smoking,
                requestBody.Alcoholism,
                requestBody.SubstanceAbuse,
                requestBody.SubstanceAbuseData,
                requestBody.RecentVaccination,
                requestBody.RecentVaccinationData,
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
