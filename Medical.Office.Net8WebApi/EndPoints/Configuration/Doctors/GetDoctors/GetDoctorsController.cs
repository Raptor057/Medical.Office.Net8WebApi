using Azure.Core;
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Configurations.Doctors.GetDoctors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.Doctors.GetDoctors
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class GetDoctorsController : ControllerBase
    {
        private readonly ILogger<GetDoctorsController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetDoctorsController> _viewModel;

        public GetDoctorsController(ILogger<GetDoctorsController> logger, IMediator mediator, GenericViewModel<GetDoctorsController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpGet("/api/GetDoctors/{IDDoctor}")]
        public async Task<IActionResult> Execute([FromRoute] long IDDoctor)
        {
            var request = new GetDoctorsRequest(IDDoctor);

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
