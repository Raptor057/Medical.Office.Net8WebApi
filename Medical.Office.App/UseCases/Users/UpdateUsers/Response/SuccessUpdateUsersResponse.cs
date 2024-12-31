using Common.Common;
using Medical.Office.App.Dtos.Users;

namespace Medical.Office.App.UseCases.Users.UpdateUsers.Response;

public record SuccessUpdateUsersResponse(SuccessRegisterUsersDto SuccessUpdateUsers) : UpdateUsersResponse,ISuccess;