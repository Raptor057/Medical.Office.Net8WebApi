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

        public async Task<Users> GetDataUserByIdAsync(int Id)
            => await _db.GetGetDataUserById(Id).ConfigureAwait(false);

        public async Task<Users> GetDataUserByUsrAsync(string Usr)
        => await _db.GetDataUserByUsr(Usr).ConfigureAwait(false);

        public async Task<Users> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task LoginUserAsync(string Usr, string Psswd)
            => await _db.LoginUser(Usr, Psswd).ConfigureAwait(false);

        public async Task RegisterUsersAsync(string Usr, string Psswd, string Name, string Lastname, string Role, string Position, string Status, string Specialtie)
            => await _db.RegisterUsers(Usr,Psswd,Name,Lastname,Role,Position,Status,Specialtie).ConfigureAwait(false);
    }
}
