using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Manero_Backend.Helpers.Repositories;

public class ReviewRepository : BaseRepository<ReviewEntity>, IReviewRepository
{
    private readonly ManeroDbContext _context;
    
    public ReviewRepository(ManeroDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }

    public async Task<bool> ExistsAsync(string userId, Guid productId)
    {
        return await _context.Reviews.Where(r => r.AppUserId == userId && r.ProductId == productId).FirstOrDefaultAsync() != null ? true : false;
    }
}