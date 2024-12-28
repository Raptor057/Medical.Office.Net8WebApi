using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.OfficeSetup.UpdateOfficeSetup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.OfficeSetup.UpdateOfficeSetup
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UpdateOfficeSetupController : ControllerBase
    {
        private readonly ILogger<UpdateOfficeSetupController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<UpdateOfficeSetupController> _viewModel;

        public UpdateOfficeSetupController(ILogger<UpdateOfficeSetupController> logger, IMediator mediator, GenericViewModel<UpdateOfficeSetupController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpPatch("/api/UpdateOfficeSetup")]
        public async Task<IActionResult> Execute([FromBody] UpdateOfficeSetupRequestBody requestBody)
        {
            if (!UpdateOfficeSetupRequest.CanInsert((new OfficeSetupDto { NameOfOffice = requestBody.NameOfOffice ?? "", Address = requestBody.Address ?? "" }), out var errors))
            {
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }

            var request = UpdateOfficeSetupRequest.Create
                (new OfficeSetupDto
                {
                    NameOfOffice = requestBody.NameOfOffice,
                    Address = requestBody.Address
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
