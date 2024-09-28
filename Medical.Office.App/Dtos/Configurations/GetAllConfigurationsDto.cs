namespace Medical.Office.App.Dtos.Configurations
{
    public record GetAllConfigurationsDto(GetOfficeSetupDto GetOfficeSetupDto, IEnumerable<GetPositionsDto> GetPositionsDto, IEnumerable<GetRolesDto> GetRolesDto, IEnumerable<GetSpecialtiesDto> GetSpecialtiesDto, IEnumerable<GetGendersDto> GetGendersDto/*, IEnumerable<GetUserStatuesDto> GetUserStatuesDto*/);
}
