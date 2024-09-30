using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Users;
using Medical.Office.App.UseCases.Users.GetUsers.Responses;
using Medical.Office.Domain.Repository;
using System.Data;

namespace Medical.Office.App.UseCases.Users.GetUsers
{
    internal sealed class GetUsersHandler : IInteractor<GetUsersRequest, GetUsersResponse>
    {
        private readonly IUsersRepository _users;

        public GetUsersHandler(IUsersRepository users)
        {
            _users=users;
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new FailureGetUsersResponse("La variable [ID] es null");
            }
            else if (request.Id == 0 && string.IsNullOrWhiteSpace(request.Usr))
            {
                var userslist = await _users.GetUsersAsync().ConfigureAwait(false);
                if (userslist == null) 
                {
                    return new FailureGetUsersResponse("No se encontraron usuarios");
                }
                var UserListDto = userslist.Select(p => new UserDto(
                    p.Id,
                    p.Usr,
                    p.Name,
                    p.Lastname,
                    p.Role,
                    p.Position,
                    p.Status,
                    p.Specialtie,
                    p.TimeSnap
                    )).ToList();
                return new SuccessGetUsersListResponse(new UserDtoList(UserListDto));
            }
            else if (request.Id == 0 && !string.IsNullOrWhiteSpace(request.Usr))
            {
                var userslist = await _users.GetDataUserByUsrListAsync(request.Usr).ConfigureAwait(false);
                if (userslist == null)
                {
                    return new FailureGetUsersResponse("No se encontraron usuarios");
                }
                var UserListDto = userslist.Select(p => new UserDto(
                    p.Id,
                    p.Usr,
                    p.Name,
                    p.Lastname,
                    p.Role,
                    p.Position,
                    p.Status,
                    p.Specialtie,
                    p.TimeSnap
                    )).ToList();
                return new SuccessGetUsersListResponse(new UserDtoList(UserListDto));
            }
            else if (request.Id > 0 && string.IsNullOrWhiteSpace(request.Usr))
            {
                var user = await _users.GetDataUserByIdAsync(request.Id).ConfigureAwait(false);
                if (user == null)
                {
                    return new FailureGetUsersResponse("No se encontraron usuarios");
                }
                    var UserDto = new UserDto(
                    user.Id,
                    user.Usr,
                    user.Name,
                    user.Lastname,
                    user.Role,
                    user.Position,
                    user.Status,
                    user.Specialtie,
                    user.TimeSnap);
                return new SuccesGetUsersByIDResponse(UserDto);

            }
            else if (request.Id > 0 && !string.IsNullOrWhiteSpace(request.Usr))
            {
                return new FailureGetUsersResponse("ocurrio un error busca solo por ID o por Usr, no puedes poner un numero de usuario y a la vez un usuario, no seas animal.");
            }
            else 
            {
                return new FailureGetUsersResponse("ocurrio un error inesperado");
            }
        }
    }
}
