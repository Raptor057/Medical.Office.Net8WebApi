using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Users;


namespace Medical.Office.App.UseCases.Users.RegisterUsers
{
    //public sealed recoes RegisterUsersRequest(RegisterUsersDto registerUsersDto) : IResultRequest<RegisterUsersResponse>;
    public sealed class RegisterUsersRequest : IResultRequest<RegisterUsersResponse>
    {
        public static bool CanCreate(RegisterUsersDto registerUsersDto, out List<string> errors)
        {
            errors = new();

            if (string.IsNullOrWhiteSpace(registerUsersDto.Usr))
            {
                errors.Add("El nombre de usuario es obligatorio pero se encuentra en blanco.");
            }

            if (string.IsNullOrWhiteSpace(registerUsersDto.Psswd))
            {
                errors.Add("La contraseña es obligatoria pero se encuentra en blanco.");
            }
            if (string.IsNullOrWhiteSpace(registerUsersDto.Name))
            {
                errors.Add("El nombre es obligatorio pero se encuentra en blanco.");
            }
            if (string.IsNullOrWhiteSpace(registerUsersDto.Lastname))
            {
                errors.Add("El apellido es obligatorio pero se encuentra en blanco.");
            }
            if (string.IsNullOrWhiteSpace(registerUsersDto.Position))
            {
                errors.Add("La posision es obligatorio pero se encuentra en blanco.");
            }
            if (string.IsNullOrWhiteSpace(registerUsersDto.Role))
            {
                errors.Add("El rol es obligatorio pero se encuentra en blanco.");
            }
            if (string.IsNullOrWhiteSpace(registerUsersDto.Specialtie))
            {
                errors.Add("La especialidad es obligatorio pero se encuentra en blanco.");
            }

            return errors.Count == 0;
        }

        // Método para crear la instancia de RegisterUsersRequest
        public static RegisterUsersRequest Create(RegisterUsersDto registerUsersDto)
        {
            // Llama al método CanCreate para validar el DTO antes de crear la instancia
            if (!CanCreate(registerUsersDto, out var errors))
            {
                // Si hay errores, lanza una excepción con los mensajes de error
                throw new InvalidOperationException(errors.Select(e => $"- {e}").Aggregate((a, b) => $"{a}\n{b}"));
            }

            // Si las validaciones pasaron, crea una nueva instancia de RegisterUsersRequest
            return new(registerUsersDto);
        }

        // Constructor privado para forzar el uso de Create
        private RegisterUsersRequest(RegisterUsersDto registerUsersDto)
        {
            RegisterUsersDto = registerUsersDto;
        }

        // Propiedad para acceder al DTO
        public RegisterUsersDto RegisterUsersDto { get; }

    }

}
