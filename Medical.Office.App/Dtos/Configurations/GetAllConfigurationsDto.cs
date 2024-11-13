namespace Medical.Office.App.Dtos.Configurations
{
    public record GetAllConfigurationsDto(OfficeSetupDto OfficeSetup, IEnumerable<PositionsDto> Positions, IEnumerable<GetRolesDto> Roles, IEnumerable<SpecialtiesDto> Specialties, IEnumerable<GetGendersDto> Genders, IEnumerable<GetUserStatuesDto> UserStatues);
}
