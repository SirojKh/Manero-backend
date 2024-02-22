using Manero_Backend.Helpers.Factory;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Helpers.Services
{
    public class UserPromoCodeService : BaseService<UserPromoCodeEntity>, IUserPromoCodeService
    {
        private readonly IUserPromoCodeRepository _userPromoCodeRepository;

        public UserPromoCodeService(IUserPromoCodeRepository userPromoCodeRepository) : base(userPromoCodeRepository)
        {
            _userPromoCodeRepository = userPromoCodeRepository;
        }
        public async Task<IActionResult> CreateAsync(UserPromoCodeEntity entity)
        {
            if (await _userPromoCodeRepository.GetAsync(x => x.AppUserId == entity.AppUserId && x.PromoCodeId == entity.PromoCodeId) != null)
                return HttpResultFactory.Conflict();

            await _userPromoCodeRepository.CreateAsync(entity);

            return HttpResultFactory.Created("","");
        }

        public async Task<UserPromoCodeEntity> GetAsync(Guid promoCodeId, string userId)
        {
            return await _userPromoCodeRepository.GetAsync(x => x.AppUserId == userId && x.PromoCodeId == promoCodeId);
        }
        
    }
}
