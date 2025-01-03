using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Users;
using Medical.Office.App.UseCases.Users.UpdateUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Users.UpdateUsers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class UpdateUsersController : ControllerBase
    {
        private readonly ILogger<UpdateUsersController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<UpdateUsersController> _viewModel;
        public UpdateUsersController(ILogger<UpdateUsersController> logger, IMediator mediator, GenericViewModel<UpdateUsersController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpPatch, Authorize(Roles = "Programador,Doctor")]
        [Route("/api/updateusers/{id}")]
        public async Task<IActionResult> ExecuteRegisterUsers([FromRoute] long id,[FromBody] UpdateUsersRequestBody requestBody)
        {
            var RegisterUsers = new UpdateUsersDto
            {
                Id = id,
                Psswd = requestBody.Psswd,
                Name = requestBody.Name,
                Lastname = requestBody.Lastname,
                Role = requestBody.Role,
                Position = requestBody.Position,
                Specialtie = requestBody.Specialtie,
                Status = requestBody.Status
            };
            if (!UpdateUsersRequest.CanCreate(RegisterUsers, out var errors))
            {
                // En lugar de lanzar una excepción, devolver los errores
                return BadRequest(_viewModel.Fail(string.Join("\n", errors)));
            }
            var request = UpdateUsersRequest.Create(RegisterUsers);
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
