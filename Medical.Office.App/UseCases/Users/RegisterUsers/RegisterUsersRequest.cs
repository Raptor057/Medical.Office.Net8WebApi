using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Users;
using Medical.Office.App.UseCases.Users.RegisterUsers.Responses;


namespace Medical.Office.App.UseCases.Users.RegisterUsers
{
    public sealed class RegisterUsersRequest : IRequest<RegisterUsersResponse>
    {
        public RegisterUsersDto RegisterUsersDto { get; }

        public RegisterUsersRequest(RegisterUsersDto registerUsersDto)
        {
            // Validar Usr
            if (string.IsNullOrWhiteSpace(registerUsersDto.Usr))
            {
                throw new ArgumentException("El nombre de usuario no puede estar vacío.", nameof(registerUsersDto.Usr));
            }

            // Validar Psswd
            if (string.IsNullOrWhiteSpace(registerUsersDto.Psswd) || registerUsersDto.Psswd.Length < 8)
            {
                throw new ArgumentException("La contraseña es obligatoria y debe tener al menos 8 caracteres.", nameof(registerUsersDto.Psswd));
            }

            // Validar Name
            if (string.IsNullOrWhiteSpace(registerUsersDto.Name))
            {
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(registerUsersDto.Name));
            }

            // Validar Lastname
            if (string.IsNullOrWhiteSpace(registerUsersDto.Lastname))
            {
                throw new ArgumentException("El apellido no puede estar vacío.", nameof(registerUsersDto.Lastname));
            }

            // Validar Role
            if (string.IsNullOrWhiteSpace(registerUsersDto.Role))
            {
                throw new ArgumentException("El rol es obligatorio.", nameof(registerUsersDto.Role));
            }

            // Validar Position
            if (string.IsNullOrWhiteSpace(registerUsersDto.Position))
            {
                throw new ArgumentException("La posición es obligatoria.", nameof(registerUsersDto.Position));
            }

            // Validar Specialtie
            if (string.IsNullOrWhiteSpace(registerUsersDto.Specialtie))
            {
                throw new ArgumentException("La especialidad es obligatoria.", nameof(registerUsersDto.Specialtie));
            }

            // Asignar el DTO después de validar
            RegisterUsersDto = registerUsersDto;
        }
    }

    //public sealed record RegisterUsersRequest(RegisterUsersDto registerUsersDto) : IResultRequest<RegisterUsersResponse>;
    //public sealed class RegisterUsersRequest : IResultRequest<RegisterUsersResponse>
    //{
    //    public static bool CanCreate(RegisterUsersDto registerUsersDto, out ErrorList errors)
    //    {
    //        errors = new();

    //        if (string.IsNullOrWhiteSpace(registerUsersDto.Usr))
    //        {
    //            errors.Add("El nombre de usuario es obligatorio pero se encuentra en blanco.");
    //        }

    //        if (string.IsNullOrWhiteSpace(registerUsersDto.Psswd))
    //        {
    //            errors.Add("La contraseña es obligatoria pero se encuentra en blanco.");
    //        }
    //        if (string.IsNullOrWhiteSpace(registerUsersDto.Name))
    //        {
    //            errors.Add("El nombre es obligatorio pero se encuentra en blanco.");
    //        }
    //        if (string.IsNullOrWhiteSpace(registerUsersDto.Lastname))
    //        {
    //            errors.Add("El apellido es obligatorio pero se encuentra en blanco.");
    //        }
    //        if (string.IsNullOrWhiteSpace(registerUsersDto.Position))
    //        {
    //            errors.Add("La posision es obligatorio pero se encuentra en blanco.");
    //        }
    //        if (string.IsNullOrWhiteSpace(registerUsersDto.Role))
    //        {
    //            errors.Add("El rol es obligatorio pero se encuentra en blanco.");
    //        }
    //        if (string.IsNullOrWhiteSpace(registerUsersDto.Specialtie))
    //        {
    //            errors.Add("La especialidad es obligatorio pero se encuentra en blanco.");
    //        }

    //        return errors.IsEmpty;
    //    }

    //    // Método para crear la instancia de RegisterUsersRequest
    //    public static RegisterUsersRequest Create(RegisterUsersDto registerUsersDto)
    //    {
    //        // Llama al método CanCreate para validar el DTO antes de crear la instancia
    //        if (!CanCreate(registerUsersDto, out var errors))
    //        {
    //            // Si hay errores, lanza una excepción con los mensajes de error
    //            throw new InvalidOperationException(errors.Select(e => $"- {e}").Aggregate((a, b) => $"{a}\n{b}"));
    //        }

    //        // Si las validaciones pasaron, crea una nueva instancia de RegisterUsersRequest
    //        return new(registerUsersDto);
    //    }

    //    // Constructor privado para forzar el uso de Create
    //    private RegisterUsersRequest(RegisterUsersDto registerUsersDto)
    //    {
    //        RegisterUsersDto = registerUsersDto;
    //    }

    //    // Propiedad para acceder al DTO
    //    public RegisterUsersDto RegisterUsersDto { get; }

    //}

}
