using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.GetNonPathologicalHistory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.NonPathologicalHistory.GetNonPathologicalHistory
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GetNonPathologicalHistoryController : ControllerBase
    {
        private readonly ILogger<GetNonPathologicalHistoryController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetNonPathologicalHistoryController> _viewModel;

        public GetNonPathologicalHistoryController(ILogger<GetNonPathologicalHistoryController> logger, IMediator mediator, GenericViewModel<GetNonPathologicalHistoryController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpGet, Route("/api/GetNonPathologicalHistory/{PatientID}")]
        public async Task<IActionResult> Execute([FromRoute] long PatientID) 
        {

            var request = new GetNonPathologicalHistoryRequest(PatientID);

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
