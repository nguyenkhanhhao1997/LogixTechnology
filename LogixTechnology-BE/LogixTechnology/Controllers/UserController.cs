using LogixTechnology.Constant;
using LogixTechnology.Data.Models;
using LogixTechnology.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LogixTechnology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        /// <summary>
        /// IUserRepository
        /// </summary>
        public readonly IUserRepository _userRepository;

        /// <summary>
        /// IConfiguration
        /// </summary>
        public readonly IConfiguration _configuration;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="configuration"></param>
        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            this._userRepository = userRepository;
            this._configuration = configuration;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<UserOutput> Login(UserInput userInput)
        {
            var result = new UserOutput();
            if (string.IsNullOrEmpty(userInput.UserName) || string.IsNullOrEmpty(userInput.Password))
            {
                return result;
            }    
            var user = await this._userRepository.GetUser(userInput);
            if (user != null)
            {
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("UserName", user.UserName),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[LogixTechnologyConstant.JwtKey]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration[LogixTechnologyConstant.JwtIssuer],
                    _configuration[LogixTechnologyConstant.JwtAudience],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                var tokenHandler = new JwtSecurityTokenHandler();
                result.UserID = user.UserId; 
                result.UserName = user.UserName;
                result.Token = tokenHandler.WriteToken(token);
            }
            return result;
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserInput userInput)
        {
            if (string.IsNullOrEmpty(userInput.UserName) || string.IsNullOrEmpty(userInput.Password))
            {
                return Ok("failed");
            }
            var result = await this._userRepository.Register(userInput);
            if (!result)
            {
                return Ok("failed");
            }
            return Ok("success");
        }
    }
}
