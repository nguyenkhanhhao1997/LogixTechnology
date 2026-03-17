using LogixTechnology.Data.Models;

namespace LogixTechnology.Data.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAll();
        Task<Article> GetById(int id);
        Task<bool> Add(Article article);
        Task<bool> Update(Article article);
        Task<bool> Delete(int id);
    }
}
