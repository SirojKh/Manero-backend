using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Interfaces.Repositories
{
    public interface IAddressRepository : IBaseRepository<AddressEntity>
    {
        public Task DeleteAsync(AddressEntity entity);
        public Task<AddressEntity> GetAsync(Guid addressId, string userId);
        public Task<ICollection<AddressEntity>> GetUserAddressesAsync(string userId);
    }
}
