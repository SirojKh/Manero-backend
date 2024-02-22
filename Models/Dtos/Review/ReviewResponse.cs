using Manero_Backend.Helpers.Factory;
using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Dtos.Review;

public class ReviewResponse
{
    public Guid Id { get; set; }
    public int StarRating { get; set; }
    public string? Description { get; set; }


    public static implicit operator ReviewResponse(ReviewEntity response)
    {
        return ReviewFactory.CreateResponse(response);
    }
}