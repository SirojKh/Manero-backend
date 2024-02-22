using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;

namespace Manero_Backend.Helpers.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
    {
        private readonly ManeroDbContext _context;


        public CategoryRepository(ManeroDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

    }
}
