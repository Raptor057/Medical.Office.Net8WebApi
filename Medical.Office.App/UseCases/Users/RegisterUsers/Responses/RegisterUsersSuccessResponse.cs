using Medical.Office.App.Dtos.Users;

namespace Medical.Office.App.UseCases.Users.RegisterUsers.Responses
{
    public record RegisterUsersSuccessResponse(RegisterUsersDto registerUsersDto) : RegisterUsersResponse;
}
