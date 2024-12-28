using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Users.GetUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;



namespace Medical.Office.Net8WebApi.EndPoints.Users.GetUsers
{

    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class GetUsersController : ControllerBase
    {
        private readonly ILogger<GetUsersController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetUsersController> _viewModel;

        public GetUsersController(ILogger<GetUsersController> logger, IMediator mediator, GenericViewModel<GetUsersController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [SwaggerOperation(
        Summary = "Obtiene los datos de los usuarios",
        Description = "Este endpoint obtiene los datos de los usuarios basados en el ID o el nombre de usuario, si se quieren obtener toda la lista en general, se deja id = 0.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Datos del usuario obtenidos exitosamente.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error interno del servidor.")]
        [HttpGet, Authorize(Roles = "Programador,Doctor")]
        [Route("/api/UsersData")]
        public async Task<IActionResult> Execute([FromQuery] int id, [FromQuery] string usr)
        {
            var request = new GetUsersRequest
            {
                Id = id,
                Usr = usr
            };

            //Otro metodo o alternativa
            //var request = new GetUsersRequest();
            //request.Id = ID;
            //request.Usr = Usr;

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
