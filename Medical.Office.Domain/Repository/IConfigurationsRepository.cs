using Medical.Office.Domain.DataSources.Entities.MedicalOffice;

namespace Medical.Office.Domain.Repository
{
    public interface IConfigurationsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Positions>>GetPositionsAsync();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Roles>> GetRolesAsync();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Specialties>> GetSpecialtiesAsync();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserStatuses>> GetUserStatusesAsync();
    }
}
