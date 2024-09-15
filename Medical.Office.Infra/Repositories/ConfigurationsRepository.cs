using Medical.Office.Domain.DataSources.Entities.MedicalOffice;
using Medical.Office.Domain.Repository;
using Medical.Office.Infra.DataSources;

namespace Medical.Office.Infra.Repositories
{
    public class ConfigurationsRepository : IConfigurationsRepository
    {
        private readonly MedicalOfficeSqlLocalDB _db;

        public ConfigurationsRepository(MedicalOfficeSqlLocalDB db)
        {
            _db = db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Positions>> GetPositionsAsync()
        {
            var GetStartPositions = await _db.GetPositions().ConfigureAwait(false);
            if (GetStartPositions == null) 
            {
                await _db.StartInsertPositions().ConfigureAwait(false);
            }
            return await _db.GetPositions().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Roles>> GetRolesAsync()
        {
            var GetStartRoles = await _db.GetRoles().ConfigureAwait(false);
            if (GetStartRoles == null)
            {
                await _db.StartInsertRoles().ConfigureAwait(false);
            }
            return await _db.GetRoles().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Specialties>> GetSpecialtiesAsync()
        {
            var GetStartSpecialities = await _db.GetSpecialties().ConfigureAwait(false);
            if (GetStartSpecialities == null)
            {
                await _db.StartInsertSpecialties().ConfigureAwait(false);
            }
            return await _db.GetSpecialties().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserStatuses>> GetUserStatusesAsync()
        {
            var GetStartUserStatuses = await _db.GetUserStatuses().ConfigureAwait(false);
            if(GetStartUserStatuses == null)
            {
                await _db.StartInsertUserStatuses().ConfigureAwait(false);
            }
            return await _db.GetUserStatuses().ConfigureAwait(false);
        }
    }
}
