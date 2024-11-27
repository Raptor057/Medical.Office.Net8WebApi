using Azure.Core;
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.LaboralDays.UpdateLaboralDays;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.UpdateLaboralDays
{
    [Route("[controller]")]
    [ApiController]
    public class UpdateLaboralDaysController : ControllerBase
    {
        private readonly ILogger<UpdateLaboralDaysController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<UpdateLaboralDaysController> _viewModel;

        public UpdateLaboralDaysController(ILogger<UpdateLaboralDaysController> logger, IMediator mediator, GenericViewModel<UpdateLaboralDaysController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpPatch, Route("/api/UpdateLaboralDays/{Id}")]
        public async Task<IActionResult> Execute([FromBody] UpdateLaboralDaysRequestBody requestBody, [FromRoute] int Id)
        {
            if(!UpdateLaboralDaysRequest.CanUpdate(new LaboralDaysDto(Id,"",requestBody.Laboral, TimeSpan.Parse(requestBody.OpeningTime), TimeSpan.Parse(requestBody.ClosingTime)),out var errors))
            {
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }

            var request = UpdateLaboralDaysRequest.Update(new LaboralDaysDto(Id,"",requestBody.Laboral,TimeSpan.Parse(requestBody.OpeningTime),TimeSpan.Parse(requestBody.ClosingTime)));

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
