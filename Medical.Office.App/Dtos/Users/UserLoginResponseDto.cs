namespace Medical.Office.App.Dtos.Users
{
    public class UserLoginResponseDto
    {
        public LoginDataUserDto User { get; set; }
        public string Role { get; set; }
        
        public string Token { get; set; }
        
        public string? WelcomeMessageIsSuccess { get; set; }
        

        // Constructor
        public UserLoginResponseDto(LoginDataUserDto user, string role, string token, string? welcomeMessageIsSuccess)
        {
            User = user;
            Role = role;
            Token = token;
            WelcomeMessageIsSuccess = welcomeMessageIsSuccess;
        }
    }
}
