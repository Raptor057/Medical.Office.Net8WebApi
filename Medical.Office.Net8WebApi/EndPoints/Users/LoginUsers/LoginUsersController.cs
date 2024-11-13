using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Users;
using Medical.Office.App.UseCases.Users.LoginUsers;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Users.UsersLogin
{
    [ApiController]
    [Route("[controller]")]
    public class LoginUsersController:ControllerBase
    {
        private readonly ILogger<LoginUsersController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<LoginUsersController> _viewModel;

        public LoginUsersController(ILogger<LoginUsersController> logger, IMediator mediator, GenericViewModel<LoginUsersController> viewModel)
        {
            _logger=logger;
            _mediator=mediator;
            _viewModel=viewModel;
        }

        [HttpPost]
        [Route("/api/login")]
        public async Task<IActionResult> ExecuteLogin([FromBody] LoginUsersRequestBody requestBody)
        {

            if (!LoginUsersRequest.CanLoggin((new LoginUserDto { Usr = requestBody.Usr,Psswd = requestBody.Psswd}), out var errors)) 
            {
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }
            var Login = new LoginUserDto
            {
                Usr = requestBody.Usr,
                Psswd = requestBody.Psswd,
            };

            var request = LoginUsersRequest.Login(Login);
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
