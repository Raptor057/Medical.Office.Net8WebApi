using MediatR;
using Common.Common.CleanArch;
using Microsoft.AspNetCore.Mvc;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.Doctors.InsertDoctors;
using Microsoft.AspNetCore.Authorization;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.Doctors.InsertDoctors
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class InsertDoctorsController : ControllerBase
    {
        private readonly ILogger<InsertDoctorsController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertDoctorsController> _viewModel;

        public InsertDoctorsController(ILogger<InsertDoctorsController> logger, IMediator mediator, GenericViewModel<InsertDoctorsController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpPost]
        [Route("/api/InsertDoctor")]
        public async Task<IActionResult> Execute([FromBody] InsertDoctorsRequestBody requestBody)
        {
            var DoctorData = new DoctorsDto(0, requestBody.FirstName, requestBody.LastName, requestBody.Specialty, requestBody.PhoneNumber, requestBody.Email, DateTime.UtcNow, DateTime.UtcNow);

            if(!InsertDoctorsRequest.CanInsert(DoctorData,out var errors))
            {
                _logger.LogError($"{_viewModel.Fail(errors.ToString())}");
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }

            var request = new InsertDoctorsRequest(DoctorData);

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
