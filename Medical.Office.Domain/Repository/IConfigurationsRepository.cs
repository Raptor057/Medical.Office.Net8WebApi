using Medical.Office.Domain.Entities.MedicalOffice;

namespace Medical.Office.Domain.Repository
{
    public interface IConfigurationsRepository
    {
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
        Task InsertOfficeSetupAsync(string NameOfOffice, string Address, TimeSpan OpeningTime, TimeSpan ClosingTime);

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

    }
}
