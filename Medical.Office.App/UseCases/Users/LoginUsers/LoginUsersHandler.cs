//using Common.Common.CleanArch;
//using Medical.Office.App.Dtos.Users;
//using Medical.Office.App.UseCases.Users.LoginUsers.Responses;
//using Medical.Office.Domain.Repository;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace Medical.Office.App.UseCases.Users.LoginUsers
//{
//    internal sealed class LoginUsersHandler : IInteractor<LoginUsersRequest, LoginUsersResponse>
//    {
//        private readonly IUsersRepository _users;
//        private readonly IConfigurationsRepository _configurations;
//        private string SecretKey;

//        public LoginUsersHandler(IUsersRepository users, IConfigurationsRepository configurations , IConfigurationRoot config)
//        {
//            _users=users;
//            _configurations=configurations;
//            SecretKey = config.GetValue<string>("ApiAuthenticationSettings:SecretKey");
//        }

//        public async Task<LoginUsersResponse> Handle(LoginUsersRequest request, CancellationToken cancellationToken)
//        {

//            var UserLogin = await _users.LoginUserAsync(request.User,request.Password).ConfigureAwait(false);
//            if (UserLogin == null) 
//            {
//                return new FailureLoginUsersResponse("Usuario no encontrado o credenciales equivocadas");
//            }

//            var GetLastTokenByUrs = await _users.GetLoginHistoryByUsrAsync(request.User).ConfigureAwait(false);

//            // Validar si existe un token previo y verificar su validez
//            if (!string.IsNullOrEmpty(GetLastTokenByUrs.UsrToken))
//            {
//                var isValid = ValidateToken(GetLastTokenByUrs.UsrToken, SecretKey);
//                if (isValid)
//                {
//                    return new SuccessLoginUsersResponse(new UserLoginResponseDto(
//                        new LoginDataUserDto(
//                            UserLogin.Usr,
//                            UserLogin.Name,
//                            UserLogin.Lastname,
//                            UserLogin.Role,
//                            UserLogin.Position,
//                            UserLogin.Specialtie),
//                        UserLogin.Role,
//                        GetLastTokenByUrs.UsrToken
//                    ));
//                }
//            }

//            //Aquí existe el usuario entonces podemos procesar el login
//            var manejadoToken = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(SecretKey); //Se declara el key o token como byte
//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(//new Claim[]{new Claim(ClaimTypes.Name, userLoginResponseDto.User.Usr.ToString()),new Claim(ClaimTypes.Role, userLoginResponseDto.User.Role)}
//                [
//                    new Claim(ClaimTypes.Name, UserLogin.Usr.ToString()),
//                    new Claim(ClaimTypes.Role, UserLogin.Role)
//                ]),
//                Expires = DateTime.UtcNow.AddDays(1),//Aqui se define cuanto tiempo durara la Key activa.
//                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };
//            var token = manejadoToken.CreateToken(tokenDescriptor);

//            //Aqui se declara la variable que sera la respuesta, declarando el UserLogin y el LoginData
//            var Token = manejadoToken.WriteToken(token);

//            var userLoginResponseDto = new UserLoginResponseDto(
//            new LoginDataUserDto(
//                UserLogin.Usr,
//                UserLogin.Name,
//                UserLogin.Lastname,
//                UserLogin.Role,
//                UserLogin.Position,
//                UserLogin.Specialtie), UserLogin.Role,Token);

//            await _configurations.InsertLoginHistoryAsync(UserLogin.Usr,UserLogin.Name, Token).ConfigureAwait(false); //Registra el historial de inicio se sesion
//            return new SuccessLoginUsersResponse(userLoginResponseDto);
//        }
//        // Método para validar el token
//        private bool ValidateToken(string token, string secretKey)
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(secretKey);
//            try
//            {
//                tokenHandler.ValidateToken(token, new TokenValidationParameters
//                {
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(key),
//                    ValidateIssuer = false, // Configurar según sea necesario
//                    ValidateAudience = false, // Configurar según sea necesario
//                    ClockSkew = TimeSpan.Zero // Opcional: evita permitir un margen de error en el tiempo
//                }, out SecurityToken validatedToken);

//                return true; // Si no lanza excepción, el token es válido
//            }
//            catch
//            {
//                return false; // Token inválido
//            }
//        }
//    }
//}

//----------------------------------------
//V 2
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Users;
using Medical.Office.App.UseCases.Users.LoginUsers.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Medical.Office.App.UseCases.Users.LoginUsers
{
    internal sealed class LoginUsersHandler : IInteractor<LoginUsersRequest, LoginUsersResponse>
    {
        private readonly IUsersRepository _users;
        private readonly IConfigurationsRepository _configurations;
        private string SecretKey;

        public LoginUsersHandler(IUsersRepository users, IConfigurationsRepository configurations, IConfigurationRoot config)
        {
            _users = users ?? throw new ArgumentNullException(nameof(users));
            _configurations = configurations ?? throw new ArgumentNullException(nameof(configurations));
            SecretKey = config.GetValue<string>("ApiAuthenticationSettings:SecretKey")
                        ?? throw new ArgumentNullException("ApiAuthenticationSettings:SecretKey");
        }

        //public async Task<LoginUsersResponse> Handle(LoginUsersRequest request, CancellationToken cancellationToken)
        //{
        //    var UserLogin = await _users.LoginUserAsync(request.User, request.Password).ConfigureAwait(false);
        //    if (UserLogin == null)
        //    {
        //        return new FailureLoginUsersResponse("Usuario no encontrado o credenciales equivocadas");
        //    }

        //    var GetLastTokenByUrs = await _users.GetLoginHistoryByUsrAsync(request.User).ConfigureAwait(false);

        //    // Validar si existe un token previo y verificar su validez
        //    if (!string.IsNullOrEmpty(GetLastTokenByUrs.UsrToken))
        //    {
        //        if (ValidateToken(GetLastTokenByUrs.UsrToken, SecretKey))
        //        {
        //            return new SuccessLoginUsersResponse(new UserLoginResponseDto(
        //                new LoginDataUserDto(
        //                    UserLogin.Usr,
        //                    UserLogin.Name,
        //                    UserLogin.Lastname,
        //                    UserLogin.Role,
        //                    UserLogin.Position,
        //                    UserLogin.Specialtie),
        //                UserLogin.Role,
        //                GetLastTokenByUrs.UsrToken
        //            ));
        //        }
        //    }

        //    // Generar un nuevo token
        //    var Token = GenerateToken(UserLogin);

        //    // Registrar el historial del login
        //    await _configurations.InsertLoginHistoryAsync(UserLogin.Usr, UserLogin.Name, Token).ConfigureAwait(false);

        //    return new SuccessLoginUsersResponse(new UserLoginResponseDto(
        //        new LoginDataUserDto(
        //            UserLogin.Usr,
        //            UserLogin.Name,
        //            UserLogin.Lastname,
        //            UserLogin.Role,
        //            UserLogin.Position,
        //            UserLogin.Specialtie),
        //        UserLogin.Role,
        //        Token
        //    ));
        //}
        public async Task<LoginUsersResponse> Handle(LoginUsersRequest request, CancellationToken cancellationToken)
        {
            // Validar las credenciales del usuario
            var UserLogin = await _users.LoginUserAsync(request.User, request.Password).ConfigureAwait(false);
            if (UserLogin == null)
            {
                return new FailureLoginUsersResponse("Usuario no encontrado o credenciales equivocadas");
            }

            // Obtener historial de login del usuario
            var GetLastTokenByUrs = await _users.GetLoginHistoryByUsrAsync(request.User).ConfigureAwait(false);

            // Validar si hay un historial de login y si el token es válido
            if (GetLastTokenByUrs != null && !string.IsNullOrEmpty(GetLastTokenByUrs.UsrToken))
            {
                if (ValidateToken(GetLastTokenByUrs.UsrToken, SecretKey))
                {
                    return new SuccessLoginUsersResponse(new UserLoginResponseDto(
                        new LoginDataUserDto(
                            UserLogin.Usr,
                            UserLogin.Name,
                            UserLogin.Lastname,
                            UserLogin.Role,
                            UserLogin.Position,
                            UserLogin.Specialtie),
                        UserLogin.Role,
                        GetLastTokenByUrs.UsrToken
                    ));
                }
            }

            // Si no hay token previo válido, generar un nuevo token
            var Token = GenerateToken(UserLogin);

            // Registrar el nuevo historial de login
            await _configurations.InsertLoginHistoryAsync(UserLogin.Usr, UserLogin.Name, Token).ConfigureAwait(false);

            return new SuccessLoginUsersResponse(new UserLoginResponseDto(
                new LoginDataUserDto(
                    UserLogin.Usr,
                    UserLogin.Name,
                    UserLogin.Lastname,
                    UserLogin.Role,
                    UserLogin.Position,
                    UserLogin.Specialtie),
                UserLogin.Role,
                Token
            ));
        }


        // Método para validar el token
        private bool ValidateToken(string token, string secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return true; // Token válido
            }
            catch
            {
                return false; // Token inválido
            }
        }

        // Método para generar el token JWT
        private string GenerateToken(dynamic UserLogin)
        {
            var manejadoToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, UserLogin.Usr.ToString()),
                    new Claim(ClaimTypes.Role, UserLogin.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = manejadoToken.CreateToken(tokenDescriptor);
            return manejadoToken.WriteToken(token);
        }
    }
}
