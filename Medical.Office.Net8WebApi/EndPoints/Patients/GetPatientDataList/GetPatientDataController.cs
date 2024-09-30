using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.GetPatientDataList;
using Medical.Office.App.UseCases.Patients.InsertPatientData;
using Medical.Office.Net8WebApi.EndPoints.Patients.InsertPatientData;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.GetPatientDataList
{

    [ApiController]
    [Route("[controller]")]
    public class GetPatientDataController : ControllerBase
    {
        private readonly ILogger<GetPatientDataController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetPatientDataController> _viewModel;

        public GetPatientDataController(ILogger<GetPatientDataController> logger, IMediator mediator, GenericViewModel<GetPatientDataController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet]
        [Route("/api/PatientData/{IDPatient}")]
        public async Task<IActionResult> Execute([FromRoute] long IDPatient)
        {
            var request = new GetPatientDataListRequest
            {
                IDPatient = IDPatient
            };

            //Otro metodo o alternativa
            //var request = new GetPatientDataListRequest();
            //request.IDPatient = IDPatient;

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
