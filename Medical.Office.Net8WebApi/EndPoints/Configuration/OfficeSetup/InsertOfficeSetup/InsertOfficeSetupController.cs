using Azure.Core;
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.OfficeSetup.InsertOfficeSetup;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.OfficeSetup.InsertOfficeSetup
{
    [ApiController]
    [Route("[controller]")]
    public class InsertOfficeSetupController : ControllerBase
    {
        private readonly ILogger<InsertOfficeSetupController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertOfficeSetupController> _viewModel;

        public InsertOfficeSetupController(ILogger<InsertOfficeSetupController> logger, IMediator mediator, GenericViewModel<InsertOfficeSetupController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpPost]
        [Route("/api/insertofficesetup")]
        public async Task<IActionResult> Execute([FromBody] InsertOfficeSetupRequestBody requestBody)
        {
            if(!InsertOfficeSetupRequest.CanInsert((new OfficeSetupDto {NameOfOffice = requestBody.NameOfOffice ?? "" ,Address = requestBody.Address ?? ""}),out var errors))
            {
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }
            var request = InsertOfficeSetupRequest.Create
                (new OfficeSetupDto
                {
                    NameOfOffice = requestBody.NameOfOffice,
                    Address=requestBody.Address
                });
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
