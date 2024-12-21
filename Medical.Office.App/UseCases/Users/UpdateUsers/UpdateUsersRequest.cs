using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Users;
using Medical.Office.App.UseCases.Users.UpdateUsers.Response;

namespace Medical.Office.App.UseCases.Users.UpdateUsers;

public record UpdateUsersRequest(UserDto User) : IRequest<UpdateUsersResponse>;