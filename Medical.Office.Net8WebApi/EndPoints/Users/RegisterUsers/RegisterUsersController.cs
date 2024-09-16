using MediatR;
using Common.Common.CleanArch;
using Microsoft.AspNetCore.Mvc;
using Medical.Office.App.UseCases.Users.RegisterUsers;
using Medical.Office.App.Dtos.Users;

namespace Medical.Office.Net8WebApi.EndPoints.Users.RegisterUsers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class RegisterUsersController : ControllerBase
    {
        private readonly ILogger<RegisterUsersController> _logger;
        private readonly ResultViewModel<RegisterUsersController> _viewModel;
        private readonly IMediator _mediator;

        public RegisterUsersController(ILogger<RegisterUsersController> logger, ResultViewModel<RegisterUsersController> viewModel, IMediator mediator)
        {
            _logger=logger;
            _viewModel=viewModel;
            _mediator=mediator;
        }

        [HttpPost]
        [Route("/api/RegisterUsers")]
        public async Task<IActionResult> RegisterUsers([FromBody] RegisterUsersRequestBody requestBody)
        {
            //// Crear un DTO a partir del requestBody
            var registerUsersDto = new RegisterUsersDto
            {
                Usr = requestBody.Usr,
                Psswd = requestBody.Psswd,
                Name = requestBody.Name,
                Lastname = requestBody.Lastname,
                Role = requestBody.Role,
                Position = requestBody.Position,
                Specialtie = requestBody.Specialtie
            };

            //// Validar el DTO usando CanCreate
            //if (!RegisterUsersRequest.CanCreate(registerUsersDto, out var errors))
            //{
            //    //return StatusCode(400, _viewModel.Fail(errors.ToString()));
            //    return StatusCode(400, _viewModel.Fail(string.Join(", ", errors)));
            //}

            //// Crear la solicitud usando el DTO
            //var request = RegisterUsersRequest.Create(registerUsersDto);

            var request = new RegisterUsersRequest(registerUsersDto);
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
