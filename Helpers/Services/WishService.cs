using Manero_Backend.Helpers.Factory;
using Manero_Backend.Helpers.Repositories;
using Manero_Backend.Models.Dtos.Product;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;
using Manero_Backend.Models.Schemas.Product;
using Manero_Backend.Models.Schemas.Wish;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Helpers.Services
{
    public class WishService : BaseService<WishEntity>,IWishService
    {
        private readonly IWishRepository _wishRepository;
        private readonly IProductRepository _productRepository;
        public WishService(IWishRepository wishRepository, IProductRepository productRepository) : base(wishRepository)
        {
            _wishRepository = wishRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> AddAsync(WishSchema schema, string userId)
        {
            WishEntity entity = schema;
            entity.AppUserId = userId;

            if (await _wishRepository.ExistsAsync(entity.ProductId, entity.AppUserId))
                return HttpResultFactory.Conflict("");

            if (!await _productRepository.ExistsAsync(entity.ProductId))
                return HttpResultFactory.BadRequest("");

            await _wishRepository.CreateAsync(entity);

            return HttpResultFactory.Created("", "");
        }

        public async Task<IActionResult> GetAllAsync(string userId)
        {

          
            return HttpResultFactory.Ok((await _productRepository.GetWishListAsync(userId)).Select(x => 
            {
                var productMinDto = (ProductMinDto)x;
                productMinDto.Liked = true;
                return productMinDto;
            }));
        }

        public async Task<IActionResult> RemoveAsync(Guid productId, string userId)
        {
            WishEntity entity = await _wishRepository.GetAsync(productId, userId);
            if(entity == null)
                return HttpResultFactory.NotFound("");

            await _wishRepository.RemoveAsync(entity);

            return HttpResultFactory.NoContent();
        }

        public async Task<bool> ExistsAsync(Guid productId, string userId)
        {
            return await _wishRepository.ExistsAsync(productId, userId);
        }
    }
}
