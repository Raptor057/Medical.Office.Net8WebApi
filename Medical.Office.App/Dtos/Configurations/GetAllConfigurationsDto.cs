namespace Medical.Office.App.Dtos.Configurations
{
    public record GetAllConfigurationsDto(OfficeSetupDto OfficeSetupDto, IEnumerable<PositionsDto> GetPositionsDto, IEnumerable<GetRolesDto> GetRolesDto, IEnumerable<SpecialtiesDto> GetSpecialtiesDto, IEnumerable<GetGendersDto> GetGendersDto, IEnumerable<GetUserStatuesDto> GetUserStatuesDto);
}
