using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Users;
using Medical.Office.App.UseCases.Users.UpdateUsers.Response;

namespace Medical.Office.App.UseCases.Users.UpdateUsers;

public sealed class UpdateUsersRequest : IRequest<UpdateUsersResponse>
{
      /// <summary>
        /// 
        /// </summary>
        /// <param name="registerUsersDto"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static bool CanCreate(UpdateUsersDto registerUsersDto, out ErrorList errors)
        {
            errors = new();
            ValidateUsrId(registerUsersDto.Id, errors);
            ValidateUsr(registerUsersDto.Usr, errors);
            ValidatePassword(registerUsersDto.Psswd, errors);
            ValidateName(registerUsersDto.Name, errors);
            ValidateLastname(registerUsersDto.Lastname, errors);
            ValidatePosition(registerUsersDto.Position, errors);
            ValidateRole(registerUsersDto.Role, errors);
            ValidateSpecialtie(registerUsersDto.Specialtie, errors);
            return errors.IsEmpty;
        }

        private static void ValidateUsrId(long Id, ErrorList errors)
        {
            if (string.IsNullOrWhiteSpace(Id.ToString()))
            {
                errors.Add("El usuario es obligatorio");
            }
            if(Id <= 0)
            {
                errors.Add("El Id de usuario no es valido");
            }
        }
        private static void ValidateUsr(string usr, ErrorList errors)
        {
            if (string.IsNullOrWhiteSpace(usr))
            {
                errors.Add("El usuario es obligatorio");
            }
            if(usr.Length > 20)
            {
                errors.Add("El usuario no puede tener mas de 20 caracteres");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="psswd"></param>
        /// <param name="errors"></param>
        private static void ValidatePassword(string psswd, ErrorList errors)
        {
            if (string.IsNullOrWhiteSpace(psswd))
            {
                errors.Add("La contraseña es obligatoria");
            }
            if (psswd.Length < 8)
            {
                errors.Add("La contraseña debe de ser de al menos 8 caracteres o más");
            }
            if(!Regex.IsMatch(psswd, @"^(?=.*[A-Z])(?=.*[\W_])(?=.*\d).+$"))
            {
                errors.Add("La contraseña debe contener al menos una letra mayúscula, un carácter especial y un número");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="errors"></param>
        private static void ValidateName(string name, ErrorList errors)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add("El nombre es obligatorio");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastname"></param>
        /// <param name="errors"></param>
        private static void ValidateLastname(string lastname, ErrorList errors)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                errors.Add("El apellido es obligatorio");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="errors"></param>
        private static void ValidatePosition(string position, ErrorList errors)
        {
            if (string.IsNullOrWhiteSpace(position))
            {
                errors.Add("La posicion es obligatoria");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <param name="errors"></param>
        private static void ValidateRole(string role, ErrorList errors)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                errors.Add("El rol es obligatorio");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specialtie"></param>
        /// <param name="errors"></param>
        private static void ValidateSpecialtie(string specialtie, ErrorList errors)
        {
            if (string.IsNullOrWhiteSpace(specialtie))
            {
                errors.Add("La especialidad es obligatoria");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerUsersDto"></param>
        /// <returns></returns>
        public static UpdateUsersRequest Create(UpdateUsersDto registerUsersDto)
        {
            if (!CanCreate(registerUsersDto, out var errors)) throw errors.AsException();
            return new UpdateUsersRequest(registerUsersDto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToHexString(hashedBytes);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enteredPassword"></param>
        /// <param name="storedHash"></param>
        /// <returns></returns>
        private static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
                var enteredHash = Convert.ToHexString(hashedBytes);
                return enteredHash.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerUsersDto"></param>
        private UpdateUsersRequest(UpdateUsersDto registerUsersDto)
        {
            Id = registerUsersDto.Id;
            User = registerUsersDto.Usr;
            //Passwd = registerUsersDto.Psswd;
            Passwd = HashPassword(registerUsersDto.Psswd);  // Cifrar la contraseña
            Name = registerUsersDto.Name;
            Lastname = registerUsersDto.Lastname;
            Position = registerUsersDto.Position;
            Role = registerUsersDto.Role;
            Specialtie = registerUsersDto.Specialtie;   
        }

        public long Id { get; }
        public string User { get; }

        public string Passwd { get; }

        public string Name { get; }

        public string Lastname { get; }

        public string Position { get; }

        public string Role { get; }

        public string Specialtie { get; }
}