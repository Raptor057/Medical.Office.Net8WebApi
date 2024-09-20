using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Users;
using Medical.Office.Domain.Repository;
using Medical.Office.App.UseCases.Users.RegisterUsers.Responses;


namespace Medical.Office.App.UseCases.Users.RegisterUsers
{
    internal sealed class RegisterUsersHandler : IInteractor<RegisterUsersRequest, RegisterUsersResponse>
    {
        private readonly IUsersRepository _users;
        private readonly IConfigurationsRepository _configurations;

        public RegisterUsersHandler(IUsersRepository users, IConfigurationsRepository configurations)
        {
            _users=users;
            _configurations=configurations;
        }

        public async Task<RegisterUsersResponse> Handle(RegisterUsersRequest request, CancellationToken cancellationToken)
        {
            var userExists = await _users.GetDataUserByUsrAsync(request.User.ToLower().ToString()).ConfigureAwait(false);

            if (userExists != null)
            {
                return new FailureRegisterUsersResponse("El usuario ya existe");
            }
            
            var roles = await _configurations.GetRolesAsync().ConfigureAwait(false);
            var positions = await _configurations.GetPositionsAsync().ConfigureAwait(false);
            var specialties = await _configurations.GetSpecialtiesAsync().ConfigureAwait(false);

            if (!roles.Any(p => p.RolesName == request.Role))
            {
                return new FailureRegisterUsersResponse("El rol del nuevo usuario no se encuentra en la lista de roles");
            }
            if (!positions.Any(p => p.PositionName == request.Position))
            {
                return new FailureRegisterUsersResponse("La posicion del nuevo usuario no se encuentra en la lista de posicions");
            }
            if (!specialties.Any(p => p.Specialty == request.Specialtie))
            {
                return new FailureRegisterUsersResponse("La especialidad del nuevo usuario no se encuentra en la lista de especialidades");
            }

            await _users.RegisterUsersAsync(request.User, request.Passwd, request.Name, request.Lastname, request.Role, request.Position, request.Specialtie);

            var registerUsersDto = new RegisterUsersDto
            {
                Usr=request.User,
                Psswd = request.Passwd,
                Name = request.Name,
                Lastname = request.Lastname,
                Role = request.Role,
                Position = request.Position,
                Specialtie = request.Specialtie
            };
            var successRegisterUsersDto = new SuccessRegisterUsersDto
            {
                Usr=registerUsersDto.Usr,
                Name=registerUsersDto.Name,
                Lastname=registerUsersDto.Lastname,
                Role=registerUsersDto.Role,
                Position=registerUsersDto.Position,
                Specialtie = registerUsersDto.Specialtie
            };

            return new SuccessRegisterUsersResponse(successRegisterUsersDto);
        }
    }
}
