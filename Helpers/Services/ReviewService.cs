using Manero_Backend.Contexts;
using Manero_Backend.Helpers.Factory;
using Manero_Backend.Models.Auth;
using Manero_Backend.Models.Dtos.Review;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;
using Manero_Backend.Models.Schemas.Review;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manero_Backend.Helpers.Services;

public class ReviewService : BaseService<ReviewEntity>, IReviewService
{
    private readonly IProductRepository _productRepository;
    private readonly IReviewRepository _reviewRepository;
    private readonly UserManager<AppUser> _userManager;
    
    public ReviewService(IReviewRepository reviewRepository, IProductRepository productRepository, UserManager<AppUser> userManager) : base(reviewRepository)
    {
        _reviewRepository = reviewRepository;
        _productRepository = productRepository;
        _userManager = userManager;
    }

    public async Task<IActionResult> CreateAsync(ReviewSchema schema, string id)
    {
        ReviewEntity entity = schema;
        entity.AppUserId = id;

        if (await _reviewRepository.ExistsAsync(id, entity.ProductId))
            return HttpResultFactory.Conflict("");


        if(await _productRepository.GetByIdAsync(entity.ProductId) == null)
            return HttpResultFactory.BadRequest("");

        await _reviewRepository.CreateAsync(entity);

        return HttpResultFactory.Created("","");
    }
}