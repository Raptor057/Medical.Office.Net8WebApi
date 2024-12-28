
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.FilesPatients.GetPatientFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.PatientFile.GetPatientFile
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class GetPatientFileController : ControllerBase
    {
        private readonly ILogger<GetPatientFileController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetPatientFileController> _viewModel;

        public GetPatientFileController(ILogger<GetPatientFileController> logger, IMediator mediator, GenericViewModel<GetPatientFileController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet("/api/GetPatientFile/{IDPatient}/{FileID}")]
        public async Task<IActionResult> Execute([FromRoute] long IDPatient, long FileID)
        {
            var request = new GetPatientFileRequest(IDPatient, FileID);

            try
            {
                // Enviar la solicitud al mediador
                var response = await _mediator.Send(request).ConfigureAwait(false);

                // Verificar la respuesta y devolver el resultado adecuado
                return _viewModel.IsSuccess ? Ok(response) : StatusCode(500, _viewModel);
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
