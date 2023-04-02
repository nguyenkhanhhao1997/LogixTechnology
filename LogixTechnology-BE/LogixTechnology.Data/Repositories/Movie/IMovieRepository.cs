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

        /// <summary>
        /// CheckExistMovie
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task<bool> CheckExistMovie(int movieId);
    }
}
