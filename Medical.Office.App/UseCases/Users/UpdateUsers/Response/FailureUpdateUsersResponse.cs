using Common.Common;

namespace Medical.Office.App.UseCases.Users.UpdateUsers.Response;

public record FailureUpdateUsersResponse(string Message): UpdateUsersResponse, IFailure;