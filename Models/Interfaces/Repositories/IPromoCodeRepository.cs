using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Interfaces.Repositories
{
    public interface IPromoCodeRepository : IBaseRepository<PromoCodeEntity>
    {
        public Task<ICollection<PromoCodeEntity>> GetAllAsync(string userId);
        public Task<PromoCodeEntity> GetAsync(string code);
    }
}
