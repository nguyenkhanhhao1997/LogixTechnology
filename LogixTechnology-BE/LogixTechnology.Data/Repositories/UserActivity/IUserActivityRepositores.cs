using LogixTechnology.Constant;
using LogixTechnology.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogixTechnology.Data.Repositories
{
    public interface IUserActivityRepositores
    {
        /// <summary>
        /// CountLike
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <returns>int</returns>
        Task<int> CountLike(int movieId);

        /// <summary>
        /// CountDisLike
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <returns>int</returns>
        Task<int> CountDisLike(int movieId);

        /// <summary>
        /// CountDisLike
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <returns>int</returns>
        Task<int> GetUserReact(int userId, int movieId);

        /// <summary>
        /// ReactMovie
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UserActivity> ReactMovie(UserActivityInput input);
    }
}
