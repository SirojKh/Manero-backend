using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Manero_Backend.Helpers.Repositories
{
    public class ProductSizeRepository : BaseRepository<ProductSizeEntity>, IProductSizeRepository
    {
        private readonly ManeroDbContext _context;
        public ProductSizeRepository(ManeroDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

    }
}
