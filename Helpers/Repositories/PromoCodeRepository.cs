using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manero_Backend.Helpers.Repositories
{
    public class PromoCodeRepository : BaseRepository<PromoCodeEntity>, IPromoCodeRepository
    {
        private readonly ManeroDbContext _context;

        public PromoCodeRepository(ManeroDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<PromoCodeEntity>> GetAllAsync(string userId)
        {
            return await _context.PromoCodes
                .Include(x => x.UserPromoCodes)
                .Include(x => x.Company)
                .Where(x => x.UserPromoCodes.Where(x => x.AppUserId == userId).FirstOrDefault() != null).ToListAsync();
        }

        public async Task<PromoCodeEntity> GetAsync(string code)
        {
            return await _context.PromoCodes
                .Include(x => x.UserPromoCodes)
                .Include(x => x.Company)
                .Where(x => x.Code == code).FirstOrDefaultAsync();
        }
    }
}
