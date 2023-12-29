

using System.Linq.Expressions;

namespace DataAccessLayer.Services.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        public Task DeleteAsync(string id);

        public Task UpdateAsync(T entity);

        public Task<List<T>> GetAllAsync();

        public Task<List<T>> GetFilteredResultAsync(Expression<Func<T, bool>> predicate);

        public Task<T> GetByIdAsync(string id);

        public Task CreateAsync(T entity);
    }
}
