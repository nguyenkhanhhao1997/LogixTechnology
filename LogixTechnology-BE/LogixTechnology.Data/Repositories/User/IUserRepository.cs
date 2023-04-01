using LogixTechnology.Data.Models;

namespace LogixTechnology.Data.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>status</returns>
        Task<bool> Register(UserInput userInput);

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>status</returns>
        Task<User> GetUser(UserInput userInput);
    }
}
