using LogixTechnology.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LogixTechnology.Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly EFDataContext _db;

        public ArticleRepository(EFDataContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            return await _db.Articles.ToListAsync();
        }

        public async Task<Article> GetById(int id)
        {
            return await _db.Articles.FindAsync(id);
        }

        public async Task<bool> Add(Article article)
        {
            await _db.Articles.AddAsync(article);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Article article)
        {
            _db.Articles.Update(article);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var article = await _db.Articles.FindAsync(id);
            if (article == null) return false;
            _db.Articles.Remove(article);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
