using System.Linq.Expressions;

namespace Manero_Backend.Models.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> RemoveAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity?> SearchSingleAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity?>> SearchAsync(Expression<Func<TEntity, bool>> predicate);
        public Task<bool> ExistsAsync(Guid id);
        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        public Task AddRangedAsync(ICollection<TEntity> entities);
        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

        public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
