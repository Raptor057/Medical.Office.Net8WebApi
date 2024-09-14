using Medical.Office.Domain.DataSources.Entities.MedicalOffice;

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
        #region Users
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Users> GetGetDataUserById(int Id)=>
            await _con.QuerySingleAsync<Users>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Id = @Id", new {Id}).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <returns></returns>
        public async Task<Users> GetDataUserByUsr(string Usr) =>
            await _con.QuerySingleAsync<Users>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Usr = @Usr", new { Usr }).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Users>> GetUsers() =>
            await _con.QueryAsync<Users>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Users]", new { }).ConfigureAwait(false);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <param name="Psswd"></param>
        /// <returns></returns>
        public async Task<Users> LoginUser(string Usr, string Psswd) =>
            await _con.QuerySingleAsync<Users>("SELECT TOP (1) * FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Usr = @Usr AND Psswd = @Psswd", new {Usr, Psswd }).ConfigureAwait(false);
        
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
        public async Task<Users> RegisterUsers(string Usr, string Psswd, string Name, string Lastname, string Role, string Position, string Status, string Specialtie) =>
            await _con.QuerySingleAsync<Users>("INSERT INTO [dbo].[Users] ([Usr], [Psswd] ,[Name] ,[Lastname] ,[Role] ,[Position] ,[Status] ,[Specialtie]) VALUES(@Usr, @Psswd, @Name, @Lastname, @Role, @Position,  @Status, @Specialtie);", new { Usr, Psswd, Name, Lastname, Role, Position,  Status, Specialtie }).ConfigureAwait(false);
        #endregion

    }
}
