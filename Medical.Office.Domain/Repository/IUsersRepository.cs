using Medical.Office.Domain.DataSources.Entities.MedicalOffice;

namespace Medical.Office.Domain.Repository
{
    public interface IUsersRepository
    {

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
        Task RegisterUsersAsync(string Usr, string Psswd, string Name, string Lastname, string Role, string Position, string Specialtie);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <param name="Psswd"></param>
        /// <returns></returns>
        Task LoginUserAsync(string Usr, string Psswd);

        /// <summary>
        /// Get All's Users
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Users>> GetUsersAsync();

        /// <summary>
        /// Get data users by user
        /// </summary>
        /// <param name="Usr"></param>
        /// <returns></returns>
        Task<Users> GetDataUserByUsrAsync(string Usr);

        /// <summary>
        /// Get data users by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Users> GetDataUserByIdAsync(int Id);
    }
}
