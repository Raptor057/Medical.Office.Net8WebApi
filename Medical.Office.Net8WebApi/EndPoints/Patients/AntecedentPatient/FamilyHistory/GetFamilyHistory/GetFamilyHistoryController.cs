using Azure.Core;
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.GetFamilyHistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.FamilyHistory.GetFamilyHistory
{
    [Route("[controller]")]
    [ApiController]
    public class GetFamilyHistoryController : ControllerBase
    {
        private readonly ILogger<GetFamilyHistoryController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetFamilyHistoryController> _viewModel;

        public GetFamilyHistoryController(ILogger<GetFamilyHistoryController> logger, IMediator mediator, GenericViewModel<GetFamilyHistoryController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpGet,Route("/api/getfamilyhistory/{PatientID}")]
        public async Task<IActionResult> Execute([FromRoute] long PatientID)
        {

            var request = new GetFamilyHistoryRequest();

            request.IdPatient = PatientID;
            
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
