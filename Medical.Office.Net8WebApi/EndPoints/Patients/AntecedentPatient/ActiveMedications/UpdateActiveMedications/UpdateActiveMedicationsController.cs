using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.UpdateActiveMedications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.ActiveMedications.UpdateActiveMedications
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateActiveMedicationsController : ControllerBase
    {
        private readonly ILogger<UpdateActiveMedicationsController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<UpdateActiveMedicationsController> _viewModel;
        
        public UpdateActiveMedicationsController(ILogger<UpdateActiveMedicationsController> logger, IMediator mediator, GenericViewModel<UpdateActiveMedicationsController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }
        [HttpPatch, Route("/api/UpdateActiveMedications/{IdPatient}")]
        public async Task<IActionResult> Execute([FromRoute] long IdPatient, [FromBody] UpdateActiveMedicationsRequestBody requestBody)
        {
            var request = new UpdateActiveMedicationsRequest(new ActiveMedicationsDto(0,IdPatient,requestBody.ActiveMedicationsData,DateTime.UtcNow));
            
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
