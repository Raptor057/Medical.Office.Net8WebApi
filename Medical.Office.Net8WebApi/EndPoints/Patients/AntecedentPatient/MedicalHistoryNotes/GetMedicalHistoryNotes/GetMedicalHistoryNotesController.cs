using Azure.Core;
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.GetMedicalHistoryNotes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.MedicalHistoryNotes.GetMedicalHistoryNotes
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class GetMedicalHistoryNotesController : ControllerBase
    {
        private readonly ILogger<GetMedicalHistoryNotesController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetMedicalHistoryNotesController> _viewModel;

        public GetMedicalHistoryNotesController(ILogger<GetMedicalHistoryNotesController> logger, IMediator mediator, GenericViewModel<GetMedicalHistoryNotesController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }
        [HttpGet,Route("/api/getmedicalhistorynotes/{PatientID}")]
        public async Task<IActionResult> Execute([FromRoute] long PatientID)
        {

            var request = new GetMedicalHistoryNotesRequest(PatientID);

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
