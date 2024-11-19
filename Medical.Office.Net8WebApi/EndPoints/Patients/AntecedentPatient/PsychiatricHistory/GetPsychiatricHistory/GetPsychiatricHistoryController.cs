using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.GetPsychiatricHistory;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PsychiatricHistory.GetPsychiatricHistory
{
    [Route("[controller]")]
    [ApiController]
    public class GetPsychiatricHistoryController : ControllerBase
    {
        private readonly ILogger<GetPsychiatricHistoryController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetPsychiatricHistoryController> _viewModel;

        public GetPsychiatricHistoryController(ILogger<GetPsychiatricHistoryController> logger, IMediator mediator, GenericViewModel<GetPsychiatricHistoryController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpGet, Route("/api/GetPsychiatricHistory/{PatientID}")]
        public async Task<IActionResult> Execute([FromRoute] long PatientID)
        {
            var request = new GetPsychiatricHistoryRequest(PatientID);

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
