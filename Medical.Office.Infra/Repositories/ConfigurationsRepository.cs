using Medical.Office.Domain.Entities.MedicalOffice;
using Medical.Office.Domain.Repository;
using Medical.Office.Infra.DataSources;

namespace Medical.Office.Infra.Repositories
{
    public class ConfigurationsRepository : IConfigurationsRepository
    {
        private readonly MedicalOfficeSqlLocalDB _db;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public ConfigurationsRepository(MedicalOfficeSqlLocalDB db)
        {
            _db = db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Genders>> GetGendersAsync()
        {
            //var GetGenders = await _db.GetGenders().ConfigureAwait(false);
            //if (GetGenders == null || GetGenders.Count() == 0) 
            //{
            //    await _db.StartInsertGenders().ConfigureAwait(false);
            //    return await _db.GetGenders().ConfigureAwait(false);
            //}
            return await _db.GetGenders().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Positions>> GetPositionsAsync()
        {
            //var GetStartPositions = await _db.GetPositions().ConfigureAwait(false);
            //if (GetStartPositions == null || GetStartPositions.Count() == 0) 
            //{
            //    await _db.StartInsertPositions().ConfigureAwait(false);
            //    return await _db.GetPositions().ConfigureAwait(false);
            //}
            return await _db.GetPositions().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Roles>> GetRolesAsync()
        {
            //var GetStartRoles = await _db.GetRoles().ConfigureAwait(false);
            //if (GetStartRoles == null || GetStartRoles.Count() == 0)
            //{
            //    await _db.StartInsertRoles().ConfigureAwait(false);
            //    return await _db.GetRoles().ConfigureAwait(false);
            //}
            return await _db.GetRoles().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Specialties>> GetSpecialtiesAsync()
        {
            //var GetStartSpecialities = await _db.GetSpecialties().ConfigureAwait(false);
            //if (GetStartSpecialities == null || GetStartSpecialities.Count() == 0)
            //{
            //    await _db.StartInsertSpecialties().ConfigureAwait(false);
            //    return await _db.GetSpecialties().ConfigureAwait(false);
            //}
            return await _db.GetSpecialties().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserStatuses>> GetUserStatusesAsync()
        {
            //var GetStartUserStatuses = await _db.GetUserStatuses().ConfigureAwait(false);
            //if(GetStartUserStatuses == null || GetStartUserStatuses.Count() == 0)
            //{
            //    await _db.StartInsertUserStatuses().ConfigureAwait(false);
            //    return await _db.GetUserStatuses().ConfigureAwait(false);
            //}
            return await _db.GetUserStatuses().ConfigureAwait(false);
        }

        public async Task<IEnumerable<LoginHistory>> GetLoginHistoryAsync()
            => await _db.GetLoginHistory().ConfigureAwait(false);


        public async Task<IEnumerable<LoginHistory>> GetLoginHistoryByParamsAsync(string Param, DateTime StartDate, DateTime EndDate)
            => await _db.GetLoginHistoryByParams(Param, StartDate, EndDate).ConfigureAwait(false);


        public async Task<IEnumerable<UsersMovements>> GetUsersMovementsAsync()
            => await _db.GetUsersMovements().ConfigureAwait(false);


        public async Task<IEnumerable<UsersMovements>> GetUsersMovementsByParamsAsync(string Param, DateTime StartDate, DateTime EndDate)
            => await _db.GetUsersMovementsByParams(Param,StartDate,EndDate).ConfigureAwait(false);


        public async Task InsertLoginHistoryAsync(string Usr, string UsrName, string? Token)
            => await _db.InsertLoginHistory(Usr, UsrName, Token).ConfigureAwait(false);


        public async Task InsertUsersMovementsAsync(string Usr, string UsrName, string UsrRole, string UsrMovement, string? Token)
            => await _db.InsertUsersMovements(Usr,UsrName, UsrRole, UsrMovement, Token).ConfigureAwait(false);

        public async Task<OfficeSetup> GetOfficeSetupAsync()
            => await _db.GetOfficeSetup().ConfigureAwait(false);

        public async Task InsertOfficeSetupAsync(string NameOfOffice, string Address, TimeSpan OpeningTime, TimeSpan ClosingTime)
            => await _db.InsertOfficeSetup(NameOfOffice, Address, OpeningTime, ClosingTime).ConfigureAwait(true);

        public async Task InsertPositionsAsync(string PositionName)
            => await _db.InsertPositions(PositionName).ConfigureAwait(false);

        public async Task InsertSpecialtiesAsync(string Specialty)
            => await _db.InsertSpecialties(Specialty).ConfigureAwait(false);
    }
}
