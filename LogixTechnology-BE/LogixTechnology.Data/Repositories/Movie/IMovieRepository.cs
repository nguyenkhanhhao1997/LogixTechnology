using LogixTechnology.Data.Models;

namespace LogixTechnology.Data.Repositories
{
    public interface IMovieRepository
    {
        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns>status</returns>
        Task<IEnumerable<Movie>> GetAll();
    }
}
