namespace Medical.Office.App.Dtos.Users
{
    public class LoginDataUserDto
    {
        public string Usr { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Role { get; set; }

        public string Position { get; set; }

        public string Specialtie { get; set; }
        // Constructor
        public LoginDataUserDto(string usr, string name, string lastname, string role, string position, string specialtie)
        {
            Usr = usr;
            Name = name;
            Lastname = lastname;
            Role = role;
            Position = position;
            Specialtie = specialtie;
        }
    }
}
