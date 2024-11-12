using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.GetAllConfigurations.Responses;
using Medical.Office.Domain.Repository;


namespace Medical.Office.App.UseCases.Configurations.GetAllConfigurations
{
    internal sealed class GetAllConfigurationsHandler : IInteractor<GetAllConfigurationsRequest, GetAllConfigurationsResponse>
    {
        private readonly IConfigurationsRepository _repository;
        private readonly IUsersRepository _users;

        public GetAllConfigurationsHandler(IConfigurationsRepository repository, IUsersRepository users)
        {
            _repository = repository;
            _users=users;

        }
        public async Task<GetAllConfigurationsResponse> Handle(GetAllConfigurationsRequest request, CancellationToken cancellationToken)
        {
            var GetOfficeSetup = await _repository.GetOfficeSetupAsync().ConfigureAwait(false);
            var GetGender = await _repository.GetGendersAsync().ConfigureAwait(false);
            var GetPositions = await _repository.GetPositionsAsync().ConfigureAwait(false);
            var GetRoles = await _repository.GetRolesAsync().ConfigureAwait(false);
            var GetSpecialities = await _repository.GetSpecialtiesAsync().ConfigureAwait(false);
            var GetUserStatuses = await _repository.GetUserStatusesAsync().ConfigureAwait(false);
            var GetCountUsers = await _users.GetUsersAsync().ConfigureAwait(false);

            var OfficeSetup = new OfficeSetupDto
            {
                NameOfOffice = GetOfficeSetup?.NameOfOffice ?? string.Empty, // Asegura que nunca sea null
                Address = GetOfficeSetup?.Address ?? string.Empty,
                OpeningTime = GetOfficeSetup?.OpeningTime ?? TimeSpan.Zero,  // O algún valor por defecto
                ClosingTime = GetOfficeSetup?.ClosingTime ?? TimeSpan.Zero
            };

            var Genders = GetGender.Select(g => new GetGendersDto{ Gender = g.Gender }).ToList();
            var Positions = GetPositions.Select(p => new PositionsDto { PositionName = p.PositionName }).ToList();
            var Roles = GetRoles.Select(r => new GetRolesDto { RolesName = r.RolesName }).ToList();
            var Specialities = GetSpecialities.Select(s => new SpecialtiesDto { Specialty = s.Specialty }).ToList();
            var UserStatuses = GetUserStatuses.Select(u => new GetUserStatuesDto { TypeUserStatuses = u.TypeUserStatuses }).ToList();
            

            var GetAllConfigurationsDto = new GetAllConfigurationsDto(
                OfficeSetup,   // Primer parámetro es GetOfficeSetupDto
                Positions,     // Segundo parámetro es IEnumerable<GetPositionsDto>
                Roles,         // Tercer parámetro es IEnumerable<GetRolesDto>
                Specialities,  // Cuarto parámetro es IEnumerable<GetSpecialtiesDto>
                Genders,       // Quinto parámetro es IEnumerable<GetGendersDto>
                UserStatuses   // Se agregan los estados de usuario
            );

            return new SuccessGetAllConfigurationsResponse(GetAllConfigurationsDto);
        }
    }
}
