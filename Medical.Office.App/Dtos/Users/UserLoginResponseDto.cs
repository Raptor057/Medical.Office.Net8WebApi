namespace Medical.Office.App.Dtos.Users
{
    public class UserLoginResponseDto
    {
        //public Domain.DataSources.Entities.MedicalOffice.Users User { get; set; }
        public LoginDataUserDto User { get; set; }
        public string Role { get; set; }
        
        public string Token { get; set; }

        //public byte[] Token { get; set; }

        // Constructor
        public UserLoginResponseDto(LoginDataUserDto user, string role, string token)//byte[] token
        {
            User = user;
            Role = role;
            Token = token;
        }
    }
}
