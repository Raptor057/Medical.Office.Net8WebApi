using Azure.Core;
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Configurations.GetAllConfigurations;
using Medical.Office.Net8WebApi.EndPoints.Users.UsersLogin;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.GetAllConfigurations
{

    [ApiController]
    [Route("[controller]")]
    public sealed class GetAllConfigurationsController : ControllerBase
    {
        private readonly ILogger<LoginUsersController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetAllConfigurationsController> _viewModel;

        public GetAllConfigurationsController(ILogger<LoginUsersController> logger, IMediator mediator, GenericViewModel<GetAllConfigurationsController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet]
        [Route("/api/getallconfigurations")]
        public async Task<IActionResult> Execute()
        {
            var request = new GetAllConfigurationsRequest();
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
