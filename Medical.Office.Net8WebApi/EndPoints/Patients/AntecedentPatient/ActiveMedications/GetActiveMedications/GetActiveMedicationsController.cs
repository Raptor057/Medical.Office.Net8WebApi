using Azure.Core;
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.GetActiveMedications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.ActiveMedications.GetActiveMedications
{    
    [ApiController]
    [Route("[controller]")]
    public class GetActiveMedicationsController : ControllerBase
    {
        private readonly ILogger<GetActiveMedicationsController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetActiveMedicationsController> _viewModel;

        public GetActiveMedicationsController(ILogger<GetActiveMedicationsController>logger, IMediator mediator, GenericViewModel<GetActiveMedicationsController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpGet]
        [Route("/api/getactivemedications/{PatientID}")]
        public async Task<IActionResult> Execute([FromRoute] long PatientID)
        {
            var request = new GetActiveMedicationsRequest();

            request.PatientID = PatientID;

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
