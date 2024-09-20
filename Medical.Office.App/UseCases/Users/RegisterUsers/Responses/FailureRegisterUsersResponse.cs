using Common.Common;

namespace Medical.Office.App.UseCases.Users.RegisterUsers.Responses
{
    public record FailureRegisterUsersResponse(string Message) : RegisterUsersResponse, IFailure;
}
