using Azure.Core;
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.Positions.InsertPositions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.Positions.InsertPositions
{
    
    [ApiController]
    [Route("[controller]")]
    public class InsertPositionsController : ControllerBase
    {
        private readonly ILogger<InsertPositionsController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertPositionsController> _viewModel;

        public InsertPositionsController(ILogger<InsertPositionsController> logger, IMediator mediator, GenericViewModel<InsertPositionsController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpPost]
        [Route("/api/insertposition/{Position}")]
        public async Task<IActionResult> Execute([FromRoute] string Position)
        {
            if (!InsertPositionsRequest.CanInsert((new PositionsDto { PositionName = Position}), out var errors))
            {
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }

            var request = InsertPositionsRequest.Create(new App.Dtos.Configurations.PositionsDto { PositionName = Position});

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
