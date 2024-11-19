using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes
{
    [Route("[controller]")]
    [ApiController]
    public class InsertMedicalHistoryNotesController : ControllerBase
    {
        private readonly ILogger<InsertMedicalHistoryNotesController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertMedicalHistoryNotesController> _viewModel;

        public InsertMedicalHistoryNotesController(ILogger<InsertMedicalHistoryNotesController> logger, IMediator mediator, GenericViewModel<InsertMedicalHistoryNotesController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;   
        }

        [HttpPost, Route("/api/InsertMedicalHistoryNotes")]
        public async Task<IActionResult> Execute([FromBody] InsertMedicalHistoryNotesRequestBody requestBody)
        {
            var request = new InsertMedicalHistoryNotesRequest(
                requestBody.IDPatient,
                requestBody.MedicalHistoryNotesData
                );

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
