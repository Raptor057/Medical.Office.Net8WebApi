using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Users;
using Medical.Office.App.UseCases.Users.LoginUsers.Responses;
using System.Security.Cryptography;
using System.Text;

namespace Medical.Office.App.UseCases.Users.LoginUsers
{
    public sealed class LoginUsersRequest: IRequest<LoginUsersResponse>
    {


        public static bool CanLoggin(LoginUserDto loginUserDto, out ErrorList errors)
        {
            errors = new ();
            ValidatePassword(loginUserDto.Usr, errors);
            ValidatePassword(loginUserDto.Psswd, errors);
            return errors.IsEmpty;
        }
        public static LoginUsersRequest Login(LoginUserDto loginUserDto)
        {
            if (!CanLoggin(loginUserDto, out ErrorList errors)) throw errors.AsException();
            return new LoginUsersRequest(loginUserDto);
        }

        private static void ValidateUser(string User, ErrorList errors)
        {
            if (string.IsNullOrWhiteSpace(User))
            {
                errors.Add("El usuario es obligatorio");
            }
        }
        private static void ValidatePassword(string Password, ErrorList errors)
        {
            if (string.IsNullOrWhiteSpace(Password))
            {
                errors.Add("La contraseña es obligatoria");
            }
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToHexString(hashedBytes);
            }
        }

        private LoginUsersRequest(LoginUserDto loginUserDto)
        {
            User = loginUserDto.Usr;
            Password = HashPassword(loginUserDto.Psswd);
        }
        public string User { get; }
        public string Password { get; }
    }
}
