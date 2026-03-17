using Microsoft.AspNetCore.Mvc;

namespace LogixTechnology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Article Controller");
        }
    }
}
