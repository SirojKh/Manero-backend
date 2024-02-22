using Manero_Backend.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Models.Interfaces.Services
{
    public interface IPaymentDetailService : IBaseService<PaymentDetailEntity>
    {
        public Task<IActionResult> CreateAsync(PaymentDetailEntity entity, string userId);
        public Task<IActionResult> RemoveAsync(Guid paymentDetailId, string userId);
        public Task<IActionResult> GetAllAsync(string userId);
        public Task<IActionResult> PutAsync(PaymentDetailEntity entity, string userId);
    }
}
