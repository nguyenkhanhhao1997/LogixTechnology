using LogixTechnology.Constant;
using LogixTechnology.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LogixTechnology.Data.Repositories
{
    public class UserActivityRepositores : IUserActivityRepositores
    {
        /// <summary>
        /// EFDataContext
        /// </summary>
        public EFDataContext _db;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="db"></param>
        public UserActivityRepositores(EFDataContext db) {
            this._db = db;
        }

        /// <summary>
        /// CountLike
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public async Task<int> CountLike(int movieId)
        {
            return await this._db.UserActivites.Where(s => s.MovieId == movieId && s.Action == (int)UserReact.Like).CountAsync();
        }

        /// <summary>
        /// CountDisLike
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public async Task<int> CountDisLike(int movieId)
        {
            return await this._db.UserActivites.Where(s => s.MovieId == movieId && s.Action == (int)UserReact.Dislike).CountAsync();
        }

        /// <summary>
        /// GetUserReact
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public async Task<int> GetUserReact (int userId, int movieId) 
        {
            var active = await this._db.UserActivites.Where(s => s.MovieId == movieId && s.UserId == userId).FirstOrDefaultAsync();
            if (active != null)
            {
                return active.Action;
            }
            return 0;
        }

        /// <summary>
        /// ReactMovie
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<UserActivity> ReactMovie(UserActivityInput input)
        {
            var existData = await this._db.UserActivites.Where(s => s.MovieId == input.MovieId && s.UserId == input.UserId).FirstOrDefaultAsync();
            if (existData != null)
            {
                existData.Action = input.Action;
                this._db.UserActivites.Update(existData);
                await this._db.SaveChangesAsync();
                return existData;

            }
            else
            {
                var userActivity = new UserActivity
                {
                    UserId = input.UserId,
                    MovieId = input.MovieId,
                    Action = input.Action
                };
                this._db.UserActivites.Add(userActivity);
                await this._db.SaveChangesAsync();
                return userActivity;
            }
        }
    }
}
