using LogixTechnology.Data.Models;
using LogixTechnology.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LogixTechnology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var articles = await _articleRepository.GetAll();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await _articleRepository.GetById(id);
            if (article == null) return NotFound();
            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Article article)
        {
            var result = await _articleRepository.Add(article);
            if (!result) return BadRequest();
            return CreatedAtAction(nameof(GetById), new { id = article.ArticleId }, article);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Article article)
        {
            if (id != article.ArticleId) return BadRequest();
            var result = await _articleRepository.Update(article);
            if (!result) return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _articleRepository.Delete(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
