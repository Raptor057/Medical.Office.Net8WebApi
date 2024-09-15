using Common.Common.CleanArch;

namespace Medical.Office.App.UseCases.Users.RegisterUsers
{
    public class RegisterUsersResponse : IResponse
    {
        public Guid UserId { get; set; }
        public string Message { get; set; }

        public RegisterUsersResponse(Guid userId, string message)
        {
            UserId = userId;
            Message = message;
        }
    }
}
