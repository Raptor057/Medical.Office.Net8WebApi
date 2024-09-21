using Common.Common;

namespace Medical.Office.App.UseCases.Users.LoginUsers.Responses
{
    public record FailureLoginUsersResponse(string Message): LoginUsersResponse, IFailure;
}
