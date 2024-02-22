using Manero_Backend.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Models.Interfaces.Services
{
    public interface IUserPromoCodeService : IBaseService<UserPromoCodeEntity>
    {
        public Task<IActionResult> CreateAsync(UserPromoCodeEntity entity);
        public Task<UserPromoCodeEntity> GetAsync(Guid promoCodeId, string userId);
    }
}
