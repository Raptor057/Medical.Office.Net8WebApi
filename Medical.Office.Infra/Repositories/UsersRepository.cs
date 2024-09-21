using Medical.Office.Domain.Repository;
using Medical.Office.Infra.DataSources;
using Medical.Office.Domain.DataSources.Entities.MedicalOffice;

namespace Medical.Office.Infra.Repositories
{
    internal class UsersRepository : IUsersRepository
    {
        private readonly MedicalOfficeSqlLocalDB _db;

        public UsersRepository(MedicalOfficeSqlLocalDB db)
        {
            _db=db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Users> GetDataUserByIdAsync(int Id)
            => await _db.GetGetDataUserById(Id).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <returns></returns>
        public async Task<Users> GetDataUserByUsrAsync(string Usr)
            => await _db.GetDataUserByUsr(Usr).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Users>> GetUsersAsync()
            => await _db.GetUsers().ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <param name="Psswd"></param>
        /// <returns></returns>
        public async Task<Users> LoginUserAsync(string Usr, string Psswd)
            => await _db.LoginUser(Usr, Psswd).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <param name="Psswd"></param>
        /// <param name="Name"></param>
        /// <param name="Lastname"></param>
        /// <param name="Role"></param>
        /// <param name="Position"></param>
        /// <param name="Specialtie"></param>
        /// <returns></returns>
        public async Task RegisterUsersAsync(string Usr, string Psswd, string Name, string Lastname, string Role, string Position, string Specialtie)
            => await _db.RegisterUsers(Usr,Psswd,Name,Lastname,Role,Position,Specialtie).ConfigureAwait(false);
    }
}
