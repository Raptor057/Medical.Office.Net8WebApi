using Medical.Office.App.Dtos.Users;

namespace Medical.Office.App.UseCases.Users.GetUsers.Responses
{
    public record SuccesGetUsersByIDResponse(UserDto  UserDto):GetUsersResponse;
}
