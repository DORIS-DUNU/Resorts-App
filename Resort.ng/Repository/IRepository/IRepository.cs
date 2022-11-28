using Resort.ng.Model;
using System.Linq.Expressions;

namespace Resort.ng.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<Resorts, bool>> filter = null);

        Task<T> GetAsync(Expression<Func<Resorts, bool>>? filter = null, bool tracked = true);
        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task RemoveAsync(T entity);

        Task SaveAsync();
    }
}
