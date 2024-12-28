using Azure.Core;
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.InsertPathologicalBackground;
using Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.NonPathologicalHistory.InsertNonPathologicalHistory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PathologicalBackground.InsertPathologicalBackground
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class InsertPathologicalBackgroundController : ControllerBase
    {
        private readonly ILogger<InsertNonPathologicalHistoryController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertPathologicalBackgroundController> _viewModel;

        public InsertPathologicalBackgroundController(ILogger<InsertNonPathologicalHistoryController> logger, IMediator mediator, GenericViewModel<InsertPathologicalBackgroundController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpPost, Route("/api/InsertPathologicalBackground")]
        public async Task<IActionResult> Execute([FromBody] InsertPathologicalBackgroundRequestBody requestBody)
        {
            var request = new InsertPathologicalBackgroundRequest(
                requestBody.IDPatient,
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
                requestBody.Others);

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
