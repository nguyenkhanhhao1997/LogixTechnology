using LogixTechnology.Data.Models;

namespace LogixTechnology.Data.Repositories
{
    public interface IMovieRepository
    {
        /// <summary>
        /// GetAll
        /// </summary>
        /// <param name="movieInput"></param>
        /// <returns>status</returns>
        Task<IEnumerable<Movie>> GetAll(GetMoviesInput movieInput);
    }
}
