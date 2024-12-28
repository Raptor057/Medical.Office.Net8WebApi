using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class InsertActiveMedicationsController : ControllerBase
    {
        private readonly ILogger<InsertActiveMedicationsController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertActiveMedicationsController> _viewModel;

        public InsertActiveMedicationsController(ILogger<InsertActiveMedicationsController> logger, IMediator mediator, GenericViewModel<InsertActiveMedicationsController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpPost]
        [Route("/api/insertactivemedications")]
        public async Task<IActionResult> Execute([FromBody] InsertActiveMedicationsRequestBody requestBody)
        {
                var activeMedicationsDto = new ActiveMedicationsDto(
                Id: 1, // Proporciona el valor adecuado para Id
                IDPatient: requestBody.IDPatient,
                ActiveMedicationsData: requestBody.ActiveMedicationsData,
                DateTimeSnap: DateTime.UtcNow);

            if (!InsertActiveMedicationsRequest.CanInsert(activeMedicationsDto, out var errors))
            {
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }
            var request = new InsertActiveMedicationsRequest(1, requestBody.IDPatient, requestBody.ActiveMedicationsData, DateTime.UtcNow);
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
