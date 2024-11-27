using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.Specialties.InsertSpecialties;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.Specialties.InsertSpecialties
{
    [Route("[controller]")]
    [ApiController]
    public class InsertSpecialtiesController : ControllerBase
    {
        private readonly ILogger<InsertSpecialtiesController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertSpecialtiesController> _viewModel;

        public InsertSpecialtiesController(ILogger<InsertSpecialtiesController> logger, IMediator mediator, GenericViewModel<InsertSpecialtiesController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpPost]
        [Route("/api/insertspecialties/{Specialtie}")]
        public async Task<IActionResult> Execute([FromRoute] string Specialtie)
        {

            if (!InsertSpecialtiesRequest.CanInsert((new SpecialtiesDto { Specialty = Specialtie.Trim() ?? ""}),out var errors))
            {
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }

            var request = InsertSpecialtiesRequest.Create(new SpecialtiesDto { Specialty = Specialtie.Trim() });

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
