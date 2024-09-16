//using Common.Common;
//using Common.Common.CleanArch;
//using XSystem.Security.Cryptography;
//using System.Text.RegularExpressions;
//using Medical.Office.Domain.Repository;
//using Medical.Office.App.IMapper;
//using Microsoft.Extensions.Logging;

//namespace Medical.Office.App.UseCases.Users.RegisterUsers
//{
//    internal class RegisterUsersHandler
//        : ResultInteractorBase<RegisterUsersRequest, RegisterUsersResponse>
//    {
//        private readonly IUsersRepository _usersRepository;
//        private readonly IConfigurationsRepositoryMapper _mapper;
//        private readonly IConfigurationsRepository _repository;
//        private readonly ILogger<RegisterUsersHandler> _logger;

//        public RegisterUsersHandler(ILogger<RegisterUsersHandler> logger,IUsersRepository usersRepository, IConfigurationsRepositoryMapper mapper, IConfigurationsRepository repository)
//        {
//            _usersRepository = usersRepository;
//            _mapper= mapper;
//            _repository= repository;
//            _logger=logger;
//        }

//        public override async Task<Result<RegisterUsersResponse>> Handle(RegisterUsersRequest request, CancellationToken cancellationToken)
//        {

//            ////GetConfigurations
//            //var GetRolesDto = await _mapper.GetRolesDtoAsync().ConfigureAwait(false);
//            //var GetPositionDto = await _mapper.GetPositionsDtoAsync().ConfigureAwait(false);
//            //var GetSpecialtiesDto = await _mapper.GetSpecialtiesDtoAsync().ConfigureAwait(false);

//            //if (!GetRolesDto.Any(p => p.RolesName == request.RegisterUsersDto.Role))
//            //{
//            //    //return Result.Fail<RegisterUsersResponse>("El rol del nuevo usuario no se encuentra en la lista de roles");
//            //    throw new InvalidOperationException("El rol del nuevo usuario no se encuentra en la lista de roles");
//            //}

//            //if (!GetPositionDto.Any(p => p.PositionName == request.RegisterUsersDto.Position))
//            //{
//            //    //return Result.Fail<RegisterUsersResponse>("La posición del nuevo usuario no se encuentra en la lista de posiciones");
//            //    throw new InvalidOperationException("La posición del nuevo usuario no se encuentra en la lista de posiciones");
//            //}

//            //if (!GetSpecialtiesDto.Any(p => p.Specialty == request.RegisterUsersDto.Specialtie))
//            //{
//            //    //return Result.Fail<RegisterUsersResponse>("La especialidad del nuevo usuario no se encuentra en la lista de especialidades");
//            //    throw new InvalidOperationException("La especialidad del nuevo usuario no se encuentra en la lista de especialidades");
//            //}

//            //GetConfigurations
//            var GetRoles = await _repository.GetRolesAsync().ConfigureAwait(false);
//            var GetPosition = await _repository.GetPositionsAsync().ConfigureAwait(false);
//            var GetSpecialties = await _repository.GetSpecialtiesAsync().ConfigureAwait(false);
//            _ = await _repository.GetUserStatusesAsync().ConfigureAwait(false);

//            if (!GetRoles.Any(p => p.RolesName == request.RegisterUsersDto.Role))
//            {
//                //return Result.Fail<RegisterUsersResponse>("El rol del nuevo usuario no se encuentra en la lista de roles");
//                throw new InvalidOperationException("El rol del nuevo usuario no se encuentra en la lista de roles");
//            }

//            if (!GetPosition.Any(p => p.PositionName == request.RegisterUsersDto.Position))
//            {
//                //return Result.Fail<RegisterUsersResponse>("La posición del nuevo usuario no se encuentra en la lista de posiciones");
//                throw new InvalidOperationException("La posición del nuevo usuario no se encuentra en la lista de posiciones");
//            }

//            if (!GetSpecialties.Any(p => p.Specialty == request.RegisterUsersDto.Specialtie))
//            {
//                //return Result.Fail<RegisterUsersResponse>("La especialidad del nuevo usuario no se encuentra en la lista de especialidades");
//                throw new InvalidOperationException("La especialidad del nuevo usuario no se encuentra en la lista de especialidades");
//            }

//            // Verifica si el usuario es único
//            var userExists = await _usersRepository.GetDataUserByUsrAsync(request.RegisterUsersDto.Usr.ToLower().ToString()).ConfigureAwait(false);

//            //if (userExists != null)
//            //{

//            //    throw new InvalidOperationException("El ususario ya existe");
//            //}
//            if (userExists != null)
//            {
//                //    // Devuelve un error si el usuario ya existe
//                //    //return Result.Fail<RegisterUsersResponse>("El ususario ya existe");
//                throw new InvalidOperationException("El usuario ya existe");
//            }
//            if (request.RegisterUsersDto.Psswd.Trim().Length < 8)
//            {
//                //return Result.Fail<RegisterUsersResponse>("La contraseña no puede ser menor a 8 caracteres");
//                throw new InvalidOperationException("La contraseña no puede ser menor a 8 caracteres");
//            }
//            // Verifica si la contraseña contiene al menos una mayúscula, un carácter especial y un número
//            if (!Regex.IsMatch(request.RegisterUsersDto.Psswd, @"^(?=.*[A-Z])(?=.*[\W_])(?=.*\d).+$"))
//            {
//                //return Result.Fail<RegisterUsersResponse>("La contraseña debe contener al menos una letra mayúscula, un carácter especial y un número");
//                throw new InvalidOperationException("La contraseña debe contener al menos una letra mayúscula, un carácter especial y un número");
//            }


//            // Lógica para registrar el usuario (aquí falta tu implementación)
//            var passwordEncrypted = Getmd5(request.RegisterUsersDto.Psswd.Trim());
//            await _usersRepository.RegisterUsersAsync(request.RegisterUsersDto.Usr.Trim().ToLower(), 
//                passwordEncrypted, 
//                request.RegisterUsersDto.Name, 
//                request.RegisterUsersDto.Lastname, 
//                request.RegisterUsersDto.Role, 
//                request.RegisterUsersDto.Position, 
//                request.RegisterUsersDto.Specialtie);
//            Guid userId = Guid.NewGuid();
//            return OK(new RegisterUsersResponse(userId, "Usuario Creado exitosamente"));
//        }

//        //Método para encriptar contraseña con MD5 se usa tanto en el Acceso como en el Registro
//        public static string Getmd5(string valor)
//        {
//            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
//            byte[] data = System.Text.Encoding.UTF8.GetBytes(valor);
//            data = x.ComputeHash(data);
//            string resp = "";
//            for (int i = 0; i < data.Length; i++)
//                resp += data[i].ToString("x2").ToLower();
//            return resp;
//        }
//    }
//}
using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Users.RegisterUsers.Responses;

//using Common.Common;
//using Common.Common.CleanArch;
//using XSystem.Security.Cryptography;
//using System.Text.RegularExpressions;
//using Medical.Office.Domain.Repository;
//using Medical.Office.App.IMapper;
//using Microsoft.Extensions.Logging;

//namespace Medical.Office.App.UseCases.Users.RegisterUsers
//{
//    internal class RegisterUsersHandler
//        : ResultInteractorBase<RegisterUsersRequest, RegisterUsersResponse>
//    {
//        private readonly IUsersRepository _usersRepository;
//        private readonly IConfigurationsRepositoryMapper _mapper;
//        private readonly IConfigurationsRepository _repository;
//        private readonly ILogger<RegisterUsersHandler> _logger;

//        public RegisterUsersHandler(ILogger<RegisterUsersHandler> logger,IUsersRepository usersRepository, IConfigurationsRepositoryMapper mapper, IConfigurationsRepository repository)
//        {
//            _usersRepository = usersRepository;
//            _mapper= mapper;
//            _repository= repository;
//            _logger=logger;
//        }

//        public override async Task<Result<RegisterUsersResponse>> Handle(RegisterUsersRequest request, CancellationToken cancellationToken)
//        {

//            ////GetConfigurations
//            //var GetRolesDto = await _mapper.GetRolesDtoAsync().ConfigureAwait(false);
//            //var GetPositionDto = await _mapper.GetPositionsDtoAsync().ConfigureAwait(false);
//            //var GetSpecialtiesDto = await _mapper.GetSpecialtiesDtoAsync().ConfigureAwait(false);

//            //if (!GetRolesDto.Any(p => p.RolesName == request.RegisterUsersDto.Role))
//            //{
//            //    //return Result.Fail<RegisterUsersResponse>("El rol del nuevo usuario no se encuentra en la lista de roles");
//            //    throw new InvalidOperationException("El rol del nuevo usuario no se encuentra en la lista de roles");
//            //}

//            //if (!GetPositionDto.Any(p => p.PositionName == request.RegisterUsersDto.Position))
//            //{
//            //    //return Result.Fail<RegisterUsersResponse>("La posición del nuevo usuario no se encuentra en la lista de posiciones");
//            //    throw new InvalidOperationException("La posición del nuevo usuario no se encuentra en la lista de posiciones");
//            //}

//            //if (!GetSpecialtiesDto.Any(p => p.Specialty == request.RegisterUsersDto.Specialtie))
//            //{
//            //    //return Result.Fail<RegisterUsersResponse>("La especialidad del nuevo usuario no se encuentra en la lista de especialidades");
//            //    throw new InvalidOperationException("La especialidad del nuevo usuario no se encuentra en la lista de especialidades");
//            //}

//            //GetConfigurations
//            var GetRoles = await _repository.GetRolesAsync().ConfigureAwait(false);
//            var GetPosition = await _repository.GetPositionsAsync().ConfigureAwait(false);
//            var GetSpecialties = await _repository.GetSpecialtiesAsync().ConfigureAwait(false);
//            _ = await _repository.GetUserStatusesAsync().ConfigureAwait(false);

//            if (!GetRoles.Any(p => p.RolesName == request.RegisterUsersDto.Role))
//            {
//                //return Result.Fail<RegisterUsersResponse>("El rol del nuevo usuario no se encuentra en la lista de roles");
//                throw new InvalidOperationException("El rol del nuevo usuario no se encuentra en la lista de roles");
//            }

//            if (!GetPosition.Any(p => p.PositionName == request.RegisterUsersDto.Position))
//            {
//                //return Result.Fail<RegisterUsersResponse>("La posición del nuevo usuario no se encuentra en la lista de posiciones");
//                throw new InvalidOperationException("La posición del nuevo usuario no se encuentra en la lista de posiciones");
//            }

//            if (!GetSpecialties.Any(p => p.Specialty == request.RegisterUsersDto.Specialtie))
//            {
//                //return Result.Fail<RegisterUsersResponse>("La especialidad del nuevo usuario no se encuentra en la lista de especialidades");
//                throw new InvalidOperationException("La especialidad del nuevo usuario no se encuentra en la lista de especialidades");
//            }

//            // Verifica si el usuario es único
//            var userExists = await _usersRepository.GetDataUserByUsrAsync(request.RegisterUsersDto.Usr.ToLower().ToString()).ConfigureAwait(false);

//            //if (userExists != null)
//            //{

//            //    throw new InvalidOperationException("El ususario ya existe");
//            //}
//            if (userExists != null)
//            {
//                //    // Devuelve un error si el usuario ya existe
//                //    //return Result.Fail<RegisterUsersResponse>("El ususario ya existe");
//                throw new InvalidOperationException("El usuario ya existe");
//            }
//            if (request.RegisterUsersDto.Psswd.Trim().Length < 8)
//            {
//                //return Result.Fail<RegisterUsersResponse>("La contraseña no puede ser menor a 8 caracteres");
//                throw new InvalidOperationException("La contraseña no puede ser menor a 8 caracteres");
//            }
//            // Verifica si la contraseña contiene al menos una mayúscula, un carácter especial y un número
//            if (!Regex.IsMatch(request.RegisterUsersDto.Psswd, @"^(?=.*[A-Z])(?=.*[\W_])(?=.*\d).+$"))
//            {
//                //return Result.Fail<RegisterUsersResponse>("La contraseña debe contener al menos una letra mayúscula, un carácter especial y un número");
//                throw new InvalidOperationException("La contraseña debe contener al menos una letra mayúscula, un carácter especial y un número");
//            }


//            // Lógica para registrar el usuario (aquí falta tu implementación)
//            var passwordEncrypted = Getmd5(request.RegisterUsersDto.Psswd.Trim());
//            await _usersRepository.RegisterUsersAsync(request.RegisterUsersDto.Usr.Trim().ToLower(), 
//                passwordEncrypted, 
//                request.RegisterUsersDto.Name, 
//                request.RegisterUsersDto.Lastname, 
//                request.RegisterUsersDto.Role, 
//                request.RegisterUsersDto.Position, 
//                request.RegisterUsersDto.Specialtie);
//            Guid userId = Guid.NewGuid();
//            return OK(new RegisterUsersResponse(userId, "Usuario Creado exitosamente"));
//        }

//        //Método para encriptar contraseña con MD5 se usa tanto en el Acceso como en el Registro
//        public static string Getmd5(string valor)
//        {
//            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
//            byte[] data = System.Text.Encoding.UTF8.GetBytes(valor);
//            data = x.ComputeHash(data);
//            string resp = "";
//            for (int i = 0; i < data.Length; i++)
//                resp += data[i].ToString("x2").ToLower();
//            return resp;
//        }
//    }
//}

namespace Medical.Office.App.UseCases.Users.RegisterUsers
{

    internal sealed class RegisterUsersHandler : IInteractor<RegisterUsersRequest, RegisterUsersResponse>
    {
        public RegisterUsersHandler()
        {
            
        }
        public async Task<RegisterUsersResponse> Handle(RegisterUsersRequest request, CancellationToken cancellationToken)
        {

            return new RegisterUsersSuccessResponse(new Dtos.Users.RegisterUsersDto{ Usr = "Test", Psswd = "Test", Name = "Rogelio", Lastname = "Arriaga", Position = "Programador", Role ="Programador", Specialtie = "Software"});
            //throw new NotImplementedException();
        }
    }

}