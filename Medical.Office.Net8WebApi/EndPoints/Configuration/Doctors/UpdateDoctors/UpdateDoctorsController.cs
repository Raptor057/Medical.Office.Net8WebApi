using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.Doctors.UpdateDoctors;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.Doctors.UpdateDoctors
{
    [Route("[controller]")]
    [ApiController]
    public class UpdateDoctorsController : ControllerBase
    {
        private readonly ILogger<UpdateDoctorsController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<UpdateDoctorsController> _viewModel;

        public UpdateDoctorsController(ILogger<UpdateDoctorsController> logger, IMediator mediator, GenericViewModel<UpdateDoctorsController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

       [HttpPatch("/api/updateDoctor/{IDDoctor}")]
       public async Task<IActionResult> Execute([FromRoute] long IDDoctor, [FromBody] UpdateDoctorsRequestBody requestBody)
        {
            var DoctorData = new DoctorsDto(IDDoctor, requestBody.FirstName, requestBody.LastName, requestBody.Specialty, requestBody.PhoneNumber, requestBody.Email, DateTime.UtcNow, DateTime.UtcNow);

            if (!UpdateDoctorsRequest.CanInsert(DoctorData, out var errors))
            {
                _logger.LogError($"{_viewModel.Fail(errors.ToString())}");
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }

            var request = new UpdateDoctorsRequest(DoctorData);

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
