using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Manero_Backend.Helpers.Repositories
{
    public class WishRepository : BaseRepository<WishEntity>, IWishRepository
    {
        private readonly ManeroDbContext _context;

        public WishRepository(ManeroDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<WishEntity> GetAsync(Guid productId, string userId)
        {
            return await _context.WishList.Where(x => x.AppUserId == userId && x.ProductId == productId).FirstOrDefaultAsync();
        }

        public async Task<bool> ExistsAsync(Guid productId, string userId)
        {
            return await _context.WishList.Where(w => w.ProductId == productId && w.AppUserId == userId).FirstOrDefaultAsync() != null ? true : false;
        }
        
        public async Task DeleteAsync(WishEntity entity)
        {
            _context.WishList.Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}
