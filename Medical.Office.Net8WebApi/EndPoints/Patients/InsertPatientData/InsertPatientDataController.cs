using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.InsertPatientData;
using Medical.Office.Net8WebApi.EndPoints.Users.RegisterUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.InsertPatientData
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class InsertPatientDataController : ControllerBase
    {
        private readonly ILogger<RegisterUsersController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertPatientDataController> _viewModel;

        public InsertPatientDataController(ILogger<RegisterUsersController> logger, IMediator mediator, GenericViewModel<InsertPatientDataController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }
        [HttpPost]
        [Route("/api/insertpatient")]
        public async Task<IActionResult> Execute([FromBody] InsertPatientDataRequestBody requestBody)
        {
            // Convertir la cadena Base64 a un arreglo de bytes
            byte[] photoBytes = string.IsNullOrWhiteSpace(requestBody.Photo) ? Array.Empty<byte>() : Convert.FromBase64String(requestBody.Photo);




            var insertPatient = new InsertPatientsDto
            (
                requestBody.Name,
                requestBody.FathersSurname,
                requestBody.MothersSurname,
                requestBody.DateOfBirth,
                requestBody.Gender,
                requestBody.Address,
                requestBody.Country,
                requestBody.City,
                requestBody.State,
                requestBody.ZipCode,
                requestBody.OutsideNumber,
                requestBody.InsideNumber,
                requestBody.PhoneNumber,
                requestBody.Email,
                requestBody.EmergencyContactName,
                requestBody.EmergencyContactPhone,
                requestBody.InsuranceProvider,
                requestBody.PolicyNumber,
                requestBody.BloodType,
                //requestBody.Photo,
                photoBytes, // Usar el arreglo de bytes convertido
                requestBody.InternalNotes
            );

            if(!InsertPatientDataRequest.CanCreatePatient(insertPatient,out var errors))
            {
                // En lugar de lanzar una excepción, devolver los errores
                return BadRequest(_viewModel.Fail(string.Join("\n", errors)));
            }
            var request = InsertPatientDataRequest.CreatePatient(insertPatient);
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
