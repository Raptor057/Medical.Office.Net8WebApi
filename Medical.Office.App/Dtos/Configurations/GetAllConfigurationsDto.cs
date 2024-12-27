namespace Medical.Office.App.Dtos.Configurations
{
    public record GetAllConfigurationsDto(OfficeSetupDto OfficeSetup, TodaysWorkingHoursDto TodaysWorkingHours,WeeklyWorkingHoursDto WeeklyWorkingHours, IEnumerable<PositionsDto> Positions, IEnumerable<GetRolesDto> Roles, IEnumerable<SpecialtiesDto> Specialties, IEnumerable<GetGendersDto> Genders, IEnumerable<GetUserStatuesDto> UserStatues, IEnumerable<TypeOfAppointmentDto> TypeOfAppointments);
}
