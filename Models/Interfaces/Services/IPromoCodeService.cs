using Manero_Backend.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Models.Interfaces.Services
{
    public interface IPromoCodeService : IBaseService<PromoCodeEntity>
    {
        public Task<IActionResult> CreateAsync(PromoCodeEntity entity);
        public Task<IActionResult> AddAsync(string code, string userId);
        public Task<IActionResult> GetAllAsync(string userId);
        public Task<IActionResult> GetValidateAsync(string code, string userId);
        public Task<PromoCodeEntity> GetValidateAsync(Guid promoCodeId);
    }
}
