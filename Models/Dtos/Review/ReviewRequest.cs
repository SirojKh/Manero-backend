using Manero_Backend.Helpers.Factory;
using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Dtos.Review;

public class ReviewRequest
{
    public int StarRating { get; set; }
    public string? Description { get; set; } 
    
    public static implicit operator ReviewEntity(ReviewRequest review)
    {
    return ReviewFactory.CreateEntity(review);
    }
}