using LogixTechnology.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LogixTechnology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        /// <summary>
        /// IUserRepository
        /// </summary>
        public IUserRepository _userRepository { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserInput userInput)
        {
            var checkUser = await this._userRepository.CheckUser(userInput);
            if (!checkUser)
            {
                return Ok("failed");
            }
            return Ok("success");
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserInput userInput)
        {
            var result = await this._userRepository.Register(userInput);
            if (!result)
            {
                return Ok("failed");
            }
            return Ok("success");
        }
    }
}
