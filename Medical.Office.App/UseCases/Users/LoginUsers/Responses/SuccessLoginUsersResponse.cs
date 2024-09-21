using Medical.Office.App.Dtos.Users;

namespace Medical.Office.App.UseCases.Users.LoginUsers.Responses
{
    //public record SuccessLoginUsersResponse(LoginDataUserDto Login, string Message, string Token) : LoginUsersResponse;
    public record SuccessLoginUsersResponse(UserLoginResponseDto UserLoginResponseDto) : LoginUsersResponse;
}
