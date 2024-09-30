using Medical.Office.App.Dtos.Users;

namespace Medical.Office.App.UseCases.Users.GetUsers.Responses
{
    public record SuccessGetUsersListResponse(UserDtoList UserDtoList):GetUsersResponse;
}
