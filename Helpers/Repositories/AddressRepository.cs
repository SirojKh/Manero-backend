using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Manero_Backend.Helpers.Repositories
{
    public class AddressRepository : BaseRepository<AddressEntity>, IAddressRepository
    {
        private readonly ManeroDbContext _context;

        public AddressRepository(ManeroDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteAsync(AddressEntity entity)
        {
            _context.Addresses.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<AddressEntity> GetAsync(Guid addressId, string userId)
        {
            return await _context.Addresses.Where(x => x.AppUserId == userId && x.Id == addressId).FirstOrDefaultAsync();
        }

        public async Task<ICollection<AddressEntity>> GetUserAddressesAsync(string userId)
        {
            return await _context.Addresses.Where(x => x.AppUserId == userId).ToListAsync();
        }
    }
}
