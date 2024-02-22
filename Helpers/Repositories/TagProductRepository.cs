using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Manero_Backend.Helpers.Repositories
{
    public class TagProductRepository : BaseRepository<TagProductEntity>, ITagProductRepository
    {
        private readonly ManeroDbContext _context;
        public TagProductRepository(ManeroDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task AddRangedAsync(ICollection<TagProductEntity> entities)
        {
            await _context.TagProducts.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }
    }
}
