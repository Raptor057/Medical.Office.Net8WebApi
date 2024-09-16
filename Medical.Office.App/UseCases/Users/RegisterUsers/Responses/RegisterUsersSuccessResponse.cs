using Medical.Office.App.Dtos.Users;

namespace Medical.Office.App.UseCases.Users.RegisterUsers.Responses
{
    public sealed record RegisterUsersSuccessResponse(RegisterUsersDto registerUsersDto) : RegisterUsersResponse;
}
