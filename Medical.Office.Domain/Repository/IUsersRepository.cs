using Medical.Office.Domain.DataSources.Entities.MedicalOffice;

namespace Medical.Office.Domain.Repository
{
    public interface IUsersRepository
    {
        /// <summary>
        /// Register New User
        /// </summary>
        /// <param name="Usr"></param>
        /// <param name="Psswd"></param>
        /// <returns></returns>
        Task RegisterUsersAsync(string Usr, string Psswd);

        /// <summary>
        /// Login User
        /// </summary>
        /// <returns></returns>
        Task LoginUserAsync(string Usr, string Psswd);

        /// <summary>
        /// Get All's Users
        /// </summary>
        /// <returns></returns>
        Task<Users> GetUsersAsync();

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
        Task<Users> GetDataUserByIdAsync(string Id);
    }
}
