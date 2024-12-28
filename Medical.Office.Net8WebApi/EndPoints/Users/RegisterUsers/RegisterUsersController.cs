using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Users;
using Medical.Office.App.UseCases.Users.RegisterUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Medical.Office.Net8WebApi.EndPoints.Users.RegisterUsers
{
    [ApiController]
    [Authorize]
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


        [SwaggerOperation(
        Summary = "Crear usuarios",
        Description = "Este endpoint crea usuarios, aqui solo tiene permisos el Doctor y el programador")]
        
        [SwaggerResponse(StatusCodes.Status200OK, "El login del usuario se realizo exitosamente.")]
       
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "El código HTTP “401 Unauthorized Access” es un error del lado del cliente. " +
        "Indica que el servidor del sitio web envía una respuesta de encabezado “WWW-Authenticate” al visitante con un desafío. Dado que el visitante no ha proporcionado credenciales válidas, se deniega el acceso y se carga la página de error.")]

        [SwaggerResponse(StatusCodes.Status403Forbidden, "Error 403 Forbidden es un mensaje que indica que el servidor deniega la acción solicitada, página web o servicio. " +
        "En otras palabras, el servidor ha podido ser contactado, y ha recibido una petición válida, pero ha denegado el acceso a la acción que se solicita.")]
        
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error interno del servidor.")]
        
        [HttpPost, Authorize(Roles = "Programador,Doctor")]
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
