using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Interfaces.Repositories;

public interface IReviewRepository: IBaseRepository<ReviewEntity>
{
    public Task<bool> ExistsAsync(string userId, Guid productId);

}