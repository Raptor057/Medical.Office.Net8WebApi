using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Users;
using Medical.Office.App.UseCases.Users.UpdateUsers.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Users.UpdateUsers;

public class UpdateUsersHandler : IInteractor<UpdateUsersRequest,UpdateUsersResponse>
{
    private readonly ILogger<UpdateUsersHandler> _logger;
    private readonly IUsersRepository _users;
    private readonly IConfigurationsRepository _configurations;
    public UpdateUsersHandler(ILogger<UpdateUsersHandler> logger, IUsersRepository users, IConfigurationsRepository configurations)
    {
        _logger=logger;
        _users=users;
        _configurations=configurations;
    }
    public async Task<UpdateUsersResponse> Handle(UpdateUsersRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var userExists = await _users.GetDataUserByIdAsync(request.Id).ConfigureAwait(false);

            if (userExists == null)
            {
                return new FailureUpdateUsersResponse("El usuario no existe");
            }

            var roles = await _configurations.GetRolesAsync().ConfigureAwait(false);
            var positions = await _configurations.GetPositionsAsync().ConfigureAwait(false);
            var specialties = await _configurations.GetSpecialtiesAsync().ConfigureAwait(false);

            if (!roles.Any(p => p.RolesName == request.Role))
            {
                return new FailureUpdateUsersResponse("El rol del nuevo usuario no se encuentra en la lista de roles");
            }

            if (!positions.Any(p => p.PositionName == request.Position))
            {
                return new FailureUpdateUsersResponse(
                    "La posicion del nuevo usuario no se encuentra en la lista de posicions");
            }

            if (!specialties.Any(p => p.Specialty == request.Specialtie))
            {
                return new FailureUpdateUsersResponse(
                    "La especialidad del nuevo usuario no se encuentra en la lista de especialidades");
            }

            await _users.UpdateUsersAsync(request.Id, request.User, request.Passwd, request.Name, request.Lastname,
                request.Role, request.Position, request.Specialtie);

            var UpdateUsersDto = new UpdateUsersDto
            {
                Id = request.Id,
                Usr = request.User,
                Psswd = request.Passwd,
                Name = request.Name,
                Lastname = request.Lastname,
                Role = request.Role,
                Position = request.Position,
                Specialtie = request.Specialtie
            };

            var successUpdateUsers = new SuccessRegisterUsersDto
            {

                Usr = UpdateUsersDto.Usr,
                Name = UpdateUsersDto.Name,
                Lastname = UpdateUsersDto.Lastname,
                Role = UpdateUsersDto.Role,
                Position = UpdateUsersDto.Position,
                Specialtie = UpdateUsersDto.Specialtie
            };
            return new SuccessUpdateUsersResponse(successUpdateUsers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar el usuario con ID {Id}", request.Id);
            return new FailureUpdateUsersResponse(ex.Message);
        }
    }
}