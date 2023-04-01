using LogixTechnology.Data.Models;
using LogixTechnology.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogixTechnology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// IMovieRepository
        /// </summary>
        public IMovieRepository _movieRepository { get; set; }

        /// <summary>
        /// IMovieRepository
        /// </summary>
        public IUserActivityRepositores _userActivityRepositores { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="movieRepository"></param>
        /// <param name="userActivityRepositores"></param>
        public HomeController(IMovieRepository movieRepository, IUserActivityRepositores userActivityRepositores)
        {
            this._movieRepository = movieRepository;
            this._userActivityRepositores = userActivityRepositores;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getall")]
        public async Task<IEnumerable<MovieOutput>> GetAll(GetMoviesInput movieInput)
        {
            var filesPath = Directory.GetCurrentDirectory();
            var listMovie = await this._movieRepository.GetAll(movieInput);
            var moviesResult = listMovie.Select(s => new MovieOutput
            {
                MovieId = s.MovieId,
                Title = s.Title,
                Image = filesPath + s.Image,
                LikeNumber = this._userActivityRepositores.CountLike(s.MovieId).Result,
                DisLikeNumber = this._userActivityRepositores.CountDisLike(s.MovieId).Result,
                UserReact = this._userActivityRepositores.GetUserReact(movieInput.UserID, s.MovieId).Result
            }).ToList();
            return moviesResult;
        }

        /// <summary>
        /// ReactMovie
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("reactmovie")]
        public async Task<IActionResult> ReactMovie(UserActivityInput input)
        {
            var result = await this._userActivityRepositores.ReactMovie(input);
            if (result == null) 
            {
                return Ok("failed");
            }
            return Ok("success");
        }
     }
}
