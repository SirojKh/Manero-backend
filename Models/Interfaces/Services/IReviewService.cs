using Manero_Backend.Models.Dtos.Review;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Schemas.Review;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Models.Interfaces.Services;

public interface IReviewService : IBaseService<ReviewEntity>
{
    public Task<IActionResult> CreateAsync(ReviewSchema schema, string id);
}