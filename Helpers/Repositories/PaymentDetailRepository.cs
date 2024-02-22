using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Manero_Backend.Helpers.Repositories
{
    public class PaymentDetailRepository : BaseRepository<PaymentDetailEntity>, IPaymentDetailRepository
    {
        private readonly ManeroDbContext _context;

        public PaymentDetailRepository(ManeroDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<PaymentDetailEntity> GetAsync(Guid paymentDetailId, string userId)
        {
            return await _context.PaymentDetails.Where(x => x.AppUserId == userId && x.Id == paymentDetailId).FirstOrDefaultAsync();
        }

        public async Task<ICollection<PaymentDetailEntity>> GetUserPaymentDetailsAsync(string userId)
        {
            return await _context.PaymentDetails.Where(x => x.AppUserId == userId).ToListAsync();
        }
    }
}
