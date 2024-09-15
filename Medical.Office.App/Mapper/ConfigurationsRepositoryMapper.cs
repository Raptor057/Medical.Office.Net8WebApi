using Medical.Office.App.IMapper;
using Medical.Office.Domain.Repository;
using Medical.Office.App.Dtos.Configurations;


namespace Medical.Office.App.Mapper
{
    public class ConfigurationsRepositoryMapper : IConfigurationsRepositoryMapper
    {
        private readonly IConfigurationsRepository _configurationsRepository;

        public ConfigurationsRepositoryMapper(IConfigurationsRepository configurationsRepository)
        {
            _configurationsRepository= configurationsRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GetPositionsDto>> GetPositionsDtoAsync()
        {
            var GetPositions = await _configurationsRepository.GetPositionsAsync().ConfigureAwait(false);

            var GetPositionsDtoList = GetPositions.Select(p => new GetPositionsDto
            {
                PositionName = p.PositionName
            });
            return GetPositionsDtoList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GetRolesDto>> GetRolesDtoAsync()
        {
            var GetRoles = await _configurationsRepository.GetRolesAsync().ConfigureAwait(false);

            var GetRolesDtoList = GetRoles.Select(p => new GetRolesDto
            {
                RolesName = p.RolesName
            });
            return GetRolesDtoList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GetSpecialtiesDto>> GetSpecialtiesDtoAsync()
        {
            var GetSpecialties = await _configurationsRepository.GetSpecialtiesAsync().ConfigureAwait(false);

            var GetSpecialtiesDtoList = GetSpecialties.Select(p => new GetSpecialtiesDto 
            {
                Specialty=p.Specialty
            });
            return GetSpecialtiesDtoList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GetUserStatuesDto>> GetUserStatuesDtoAsync()
        {
            var GetUsersStatues = await _configurationsRepository.GetUserStatusesAsync().ConfigureAwait(false);

            var GetUsersStatuesDtoList = GetUsersStatues.Select(p => new GetUserStatuesDto
            {
                TypeUserStatuses=p.TypeUserStatuses
            });
            return GetUsersStatuesDtoList;
        }
    }
}
