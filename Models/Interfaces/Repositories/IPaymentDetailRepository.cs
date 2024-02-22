using Manero_Backend.Models.Entities;
using System.Linq.Expressions;

namespace Manero_Backend.Models.Interfaces.Repositories
{
    public interface IPaymentDetailRepository : IBaseRepository<PaymentDetailEntity>
    {
        public Task<PaymentDetailEntity> GetAsync(Guid paymentDetailId, string userId);
        public Task<ICollection<PaymentDetailEntity>> GetUserPaymentDetailsAsync(string userId);
  
    }
}
