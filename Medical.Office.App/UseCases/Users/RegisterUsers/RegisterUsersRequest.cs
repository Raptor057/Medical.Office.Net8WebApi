using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Users;

namespace Medical.Office.App.UseCases.Users.RegisterUsers
{
    public sealed record RegisterUsersRequest(RegisterUsersDto registerUsersDto) : IResultRequest<RegisterUsersResponse>;
}
