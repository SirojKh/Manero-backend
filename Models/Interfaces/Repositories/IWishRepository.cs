using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Interfaces.Repositories
{
    public interface IWishRepository : IBaseRepository<WishEntity>
    {
        public Task<WishEntity> GetAsync(Guid productId, string userId);
        public Task DeleteAsync(WishEntity entity);
        public Task<bool> ExistsAsync(Guid productId, string userId);
    }
}
