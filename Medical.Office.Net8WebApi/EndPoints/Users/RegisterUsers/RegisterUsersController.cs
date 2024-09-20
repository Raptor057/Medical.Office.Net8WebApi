using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Users;
using Medical.Office.App.UseCases.Users.RegisterUsers;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Users.RegisterUsers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterUsersController : ControllerBase
    {
        private readonly ILogger<RegisterUsersController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<RegisterUsersController> _viewModel;
        public RegisterUsersController(ILogger<RegisterUsersController> logger, IMediator mediator, GenericViewModel<RegisterUsersController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }
        [HttpPost]
        [Route("/api/registerusers")]
        public async Task<IActionResult> ExecuteRegisterUsers([FromBody] RegisterUsersRequestBody requestBody)
        {
            var RegisterUsers = new RegisterUsersDto
            {
                Usr = requestBody.Usr,
                Psswd = requestBody.Psswd,
                Name = requestBody.Name,
                Lastname = requestBody.Lastname,
                Role = requestBody.Role,
                Position = requestBody.Position,
                Specialtie = requestBody.Specialtie
            };
            if (!RegisterUsersRequest.CanCreate(RegisterUsers, out var errors))
            {
                // En lugar de lanzar una excepción, devolver los errores
                return BadRequest(_viewModel.Fail(string.Join("\n", errors)));
            }
            var request = RegisterUsersRequest.Create(RegisterUsers);
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
