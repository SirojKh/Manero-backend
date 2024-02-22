using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;

namespace Manero_Backend.Helpers.Repositories
{
    public class SizeRepository : BaseRepository<SizeEntity>, ISizeRepository
    {
        private readonly ManeroDbContext _context;

        public SizeRepository(ManeroDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
