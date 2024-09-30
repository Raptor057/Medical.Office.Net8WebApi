using Common.Common;

namespace Medical.Office.App.UseCases.Users.GetUsers.Responses
{
    public record FailureGetUsersResponse(string Message):GetUsersResponse , IFailure;
}
