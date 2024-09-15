using Medical.Office.App.Dtos.Configurations;

namespace Medical.Office.App.IMapper
{
    public interface IConfigurationsRepositoryMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GetPositionsDto>> GetPositionsDtoAsync();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GetRolesDto>> GetRolesDtoAsync();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GetSpecialtiesDto>> GetSpecialtiesDtoAsync();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GetUserStatuesDto>> GetUserStatuesDtoAsync();

    }
}
