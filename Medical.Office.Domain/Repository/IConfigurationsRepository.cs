using Medical.Office.Domain.Entities.MedicalOffice;

namespace Medical.Office.Domain.Repository
{
    public interface IConfigurationsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TypeOfAppointment>> GetTypeOfAppointmentsListAsync();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeOfAppointment"></param>
        /// <returns></returns>
        Task InsertTypeOfAppointmentAsync(string typeOfAppointment);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<OfficeSetup> GetOfficeSetupAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NameOfOffice"></param>
        /// <param name="Address"></param>
        /// <param name="OpeningTime"></param>
        /// <param name="ClosingTime"></param>
        /// <returns></returns>
        Task InsertOfficeSetupAsync(string NameOfOffice, string Address);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Positions>>GetPositionsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PositionName"></param>
        /// <returns></returns>
        Task InsertPositionsAsync(string PositionName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Roles>> GetRolesAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Genders>> GetGendersAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Specialties>> GetSpecialtiesAsync();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Specialty"></param>
        /// <returns></returns>
        Task InsertSpecialtiesAsync(string Specialty);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserStatuses>> GetUserStatusesAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LoginHistory>> GetLoginHistoryAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Param"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        Task<IEnumerable<LoginHistory>> GetLoginHistoryByParamsAsync(string? Param, DateTime StartDate, DateTime EndDate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <param name="UsrName"></param>
        /// <param name="Token"></param>
        /// <returns></returns>
        Task InsertLoginHistoryAsync(string Usr, string UsrName, string? Token);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UsersMovements>> GetUsersMovementsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Param"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        Task<IEnumerable<UsersMovements>> GetUsersMovementsByParamsAsync(string? Param, DateTime StartDate, DateTime EndDate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <param name="UsrName"></param>
        /// <param name="UsrRole"></param>
        /// <param name="UsrMovement"></param>
        /// <param name="Token"></param>
        /// <returns></returns>
        Task InsertUsersMovementsAsync(string Usr, string UsrName, string UsrRole, string UsrMovement, string? Token);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<LaboralDays> GetTodaysWorkScheduleAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LaboralDays>> GetWorkScheduleAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="officeSetup"></param>
        /// <returns></returns>
        Task UpdateOfficeSetupAsync(string NameOfOffice, string Address);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="laboralDays"></param>
        /// <returns></returns>
        Task UpdateWorkScheduleAsync(LaboralDays laboralDays);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task <IEnumerable<Doctors>> GetDoctorsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDDoctor"></param>
        /// <returns></returns>
        Task<Doctors> GetDoctorAsync(long IDDoctor);

        Task InsertDoctorAsync(string FirstName ,string LastName ,string Specialty ,string PhoneNumber ,string Email);
        Task DeleteDoctorAsync(long IDDoctor);
        Task UpdateDoctorAsync(long id, string FirstName, string LastName, string Specialty, string PhoneNumber, string Email);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LaboralDays>> GetLaboralDaysListAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<LaboralDays> GetLaboralDayByIdAsync(int Id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Laboral"></param>
        /// <param name="OpeningTime"></param>
        /// <param name="ClosingTime"></param>
        /// <returns></returns>
        Task UpdateLaboralDaysByIdAsync(int Id, bool Laboral, TimeSpan OpeningTime, TimeSpan ClosingTime);

    }
}
