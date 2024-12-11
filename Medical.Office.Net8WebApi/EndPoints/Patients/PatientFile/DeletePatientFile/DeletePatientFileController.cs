using Azure.Core;
using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.FilesPatients.DeletePatientFile;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.PatientFile.DeletePatientFile
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeletePatientFileController : ControllerBase
    {
        private readonly ILogger<DeletePatientFileController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<DeletePatientFileController> _viewModel;

        public DeletePatientFileController(ILogger<DeletePatientFileController> logger, IMediator mediator, GenericViewModel<DeletePatientFileController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }


        [HttpDelete("DeletePatientFile/{IDPatient}/{FileID}")]
        public async Task<IActionResult> Execute([FromRoute] long IDPatient, long FileID)
        {
            var request = new DeletePatientFileRequest(IDPatient,FileID);
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
