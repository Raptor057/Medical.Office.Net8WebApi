using Medical.Office.Domain.DataSources.Entities.MedicalOffice;
using Medical.Office.Domain.Entities.MedicalOffice;

namespace Medical.Office.Infra.DataSources
{
    /// <summary>
    /// 
    /// </summary>
    public class MedicalOfficeSqlLocalDB
    {
        private readonly ConfigurationSqlDbConnection<MedicalOfficeSqlLocalDB> _con;

        public MedicalOfficeSqlLocalDB(ConfigurationSqlDbConnection<MedicalOfficeSqlLocalDB> con)
        {
            _con=con;   
        }

        #region Configuracion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task <IEnumerable<UserStatuses>> GetUserStatuses()
            => await _con.QueryAsync<UserStatuses>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[UserStatuses]").ConfigureAwait(false);

        public async Task StartInsertUserStatuses()
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[UserStatuses] (TypeUserStatuses) VALUES ('Activo'),('Inactivo');").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Roles>> GetRoles()
            => await _con.QueryAsync<Roles>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Roles]").ConfigureAwait(false);

        public async Task StartInsertRoles()
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Roles] (RolesName) VALUES ('Programador'),('Doctor'),('Enfermera'),('Secretaria'),('Asistente');").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Positions>> GetPositions()
            => await _con.QueryAsync<Positions>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Positions]").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public async Task StartInsertPositions()
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Positions] (PositionName) VALUES ('Programador');").ConfigureAwait(false);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public async Task InsertPositions(string position)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Positions] (PositionName) VALUES (@position);", new { position }).ConfigureAwait(false);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task <IEnumerable<Specialties>> GetSpecialties()
            => await _con.QueryAsync<Specialties>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Specialties]").ConfigureAwait (false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task StartInsertSpecialties()
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Specialties] (Specialty) VALUES ('Desarollador');").ConfigureAwait(false);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="specialtie"></param>
        /// <returns></returns>
        public async Task InsertSpecialties(string specialtie)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Specialties] (Specialty) VALUES (@specialtie);", new { specialtie }).ConfigureAwait(false);

        #endregion

        #region Users
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Users> GetGetDataUserById(int Id)=>
            await _con.QuerySingleAsync<Users>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Id = @Id;", new {Id}).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <returns></returns>
        public async Task<Users> GetDataUserByUsr(string Usr) =>
            await _con.QuerySingleAsync<Users>("SELECT top 1 * FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Usr = @Usr;", new { Usr }).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Users>> GetUsers() =>
            await _con.QueryAsync<Users>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Users];", new { }).ConfigureAwait(false);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <param name="Psswd"></param>
        /// <returns></returns>
        public async Task<Users> LoginUser(string Usr, string Psswd) =>
            await _con.QuerySingleAsync<Users>("SELECT TOP (1) * FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Usr = @Usr AND Psswd = @Psswd;", new {Usr, Psswd }).ConfigureAwait(false);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <param name="Psswd"></param>
        /// <param name="Name"></param>
        /// <param name="Lastname"></param>
        /// <param name="Role"></param>
        /// <param name="Position"></param>
        /// <param name="Status"></param>
        /// <param name="Specialtie"></param>
        /// <returns></returns>
        public async Task<Users> RegisterUsers(string Usr, string Psswd, string Name, string Lastname, string Role, string Position, string Specialtie) =>
            await _con.QuerySingleAsync<Users>("INSERT INTO [dbo].[Users] " +
                "([Usr], [Psswd] ,[Name] ,[Lastname] ,[Role] ,[Position],[Specialtie]) " +
                "VALUES(@Usr, @Psswd, @Name, @Lastname, @Role, @Position, @Specialtie);", new { Usr, Psswd, Name, Lastname, Role, Position, Specialtie }).ConfigureAwait(false);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LoginHistory>> GetLoginHistory()
            => await _con.QueryAsync<LoginHistory>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] ORDER BY DateTimeSnap DESC;").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Param"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<LoginHistory>> GetLoginHistoryByParams(string Param, DateTime StartDate, DateTime EndDate)
            => await _con.QueryAsync<LoginHistory>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] " +
                "WHERE (Usr LIKE @Param OR UsrName LIKE @Param) " +
                "AND (@StartDate IS NULL OR @EndDate IS NULL OR DateTimeSnap BETWEEN @StartDate AND @EndDate) " +
                "ORDER BY DateTimeSnap ASC;", new { Param = $"%{Param}%", StartDate,EndDate }).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <param name="UsrName"></param>
        /// <param name="Token"></param>
        /// <returns></returns>
        public async Task InsertLoginHistory(string Usr, string UsrName, string Token)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] " +
                "(Usr,UsrName,UsrToken) " +
                "VALUES(@Usr,@UsrName,@Token);", new {Usr,UsrName,Token}).ConfigureAwait(false);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UsersMovements>> GetUsersMovements()
            => await _con.QueryAsync<UsersMovements>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[UsersMovements];").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Param"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UsersMovements>> GetUsersMovementsByParams(string Param, DateTime StartDate, DateTime EndDate)
            => await _con.QueryAsync<UsersMovements>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] " +
                "WHERE (Usr LIKE @Param OR UsrName LIKE @Param) " +
                "AND (@StartDate IS NULL OR @EndDate IS NULL OR DateTimeSnap BETWEEN @StartDate AND @EndDate) " +
                "ORDER BY DateTimeSnap ASC", new { Param = $"%{Param}%", StartDate,EndDate}).ConfigureAwait (false);

        public async Task InsertUsersMovements(string Usr, string UsrName,string UsrRole,string UsrMovement, string? Token)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[UsersMovements] " +
                "(Usr,UsrName,UsrRole,UsrMovement,UsrToken) " +
                "VALUES (@Usr,@UsrName,@UsrRole,@UsrMovement,@Token);", new {Usr,UsrName,UsrRole,UsrMovement,Token }).ConfigureAwait(false);
        #endregion


    }
}
