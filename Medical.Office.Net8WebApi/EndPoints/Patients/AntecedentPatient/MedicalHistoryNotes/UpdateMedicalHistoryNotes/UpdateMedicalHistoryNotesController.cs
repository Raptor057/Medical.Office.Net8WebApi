using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.MedicalHistoryNotes;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.UpdateMedicalHistoryNotes;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.MedicalHistoryNotes.UpdateMedicalHistoryNotes
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateMedicalHistoryNotesController : ControllerBase
    {
        private readonly ILogger<UpdateMedicalHistoryNotesController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<UpdateMedicalHistoryNotesController> _viewModel;

        public UpdateMedicalHistoryNotesController(ILogger<UpdateMedicalHistoryNotesController> logger, IMediator mediator, GenericViewModel<UpdateMedicalHistoryNotesController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpPatch, Route("/api/UpdateMedicalHistoryNotes/{IdPatient}")]
        public async Task<IActionResult> Execute([FromRoute] long IdPatient, [FromBody] UpdateMedicalHistoryNotesRequestBody requestBody)
        {
            var request = new UpdateMedicalHistoryNotesRequest(new MedicalHistoryNotesDto(
                0, // Assuming Id is generated elsewhere
                IdPatient,
                requestBody.Notes,
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