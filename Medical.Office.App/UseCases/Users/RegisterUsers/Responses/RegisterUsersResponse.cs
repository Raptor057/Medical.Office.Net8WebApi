using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Users;

namespace Medical.Office.App.UseCases.Users.RegisterUsers.Responses
{
    //public class RegisterUsersResponse : IResponse
    //{
    //    public Guid UserId { get; set; }
    //    public string Message { get; set; }

    //    public RegisterUsersResponse(Guid userId, string message)
    //    {
    //        UserId = userId;
    //        Message = message;
    //    }
    //}
    //    public sealed record RegisterUsersResponse(string Message);
    public abstract record RegisterUsersResponse : IResponse;
}
