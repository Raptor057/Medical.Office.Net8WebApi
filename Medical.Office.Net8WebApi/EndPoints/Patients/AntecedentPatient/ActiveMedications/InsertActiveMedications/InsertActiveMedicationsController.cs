using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications
{
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
            var request = new InsertActiveMedicationsRequest(1, requestBody.IDPatient, requestBody.ActiveMedicationsData, DateTime.Now);
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
