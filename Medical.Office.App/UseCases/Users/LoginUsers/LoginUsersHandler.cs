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

        public LoginUsersHandler(IUsersRepository users, IConfigurationsRepository configurations , IConfigurationRoot config)
        {
            _users=users;
            _configurations=configurations;
            SecretKey = config.GetValue<string>("ApiAuthenticationSettings:SecretKey");
        }

        public async Task<LoginUsersResponse> Handle(LoginUsersRequest request, CancellationToken cancellationToken)
        {

            var UserLogin = await _users.LoginUserAsync(request.User,request.Password).ConfigureAwait(false);
            if (UserLogin == null) 
            {
                return new FailureLoginUsersResponse("Usuario no encontrado o credenciales equivocadas");
            }

            //Aquí existe el usuario entonces podemos procesar el login
            var manejadoToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey); //Se declara el key o token como byte
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(//new Claim[]{new Claim(ClaimTypes.Name, userLoginResponseDto.User.Usr.ToString()),new Claim(ClaimTypes.Role, userLoginResponseDto.User.Role)}
                [
                    new Claim(ClaimTypes.Name, UserLogin.Usr.ToString()),
                    new Claim(ClaimTypes.Role, UserLogin.Role)
                ]),
                Expires = DateTime.UtcNow.AddDays(7),//Aqui se define cuanto tiempo durara la Key activa.
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = manejadoToken.CreateToken(tokenDescriptor);

            //Aqui se declara la variable que sera la respuesta, declarando el UserLogin y el LoginData
            var Token = manejadoToken.WriteToken(token);
            var userLoginResponseDto = new UserLoginResponseDto(
            new LoginDataUserDto(
                UserLogin.Usr,
                UserLogin.Name,
                UserLogin.Lastname,
                UserLogin.Role,
                UserLogin.Position,
                UserLogin.Specialtie), UserLogin.Role,Token);

            await _configurations.InsertLoginHistoryAsync(UserLogin.Usr,UserLogin.Name, Token).ConfigureAwait(false); //Registra el historial de inicio se sesion
            return new SuccessLoginUsersResponse(userLoginResponseDto);
        }
    }
}
