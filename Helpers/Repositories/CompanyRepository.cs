using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;

namespace Manero_Backend.Helpers.Repositories
{
    public class CompanyRepository : BaseRepository<CompanyEntity>, ICompanyRepository
    {
        private readonly ManeroDbContext _context;

        public CompanyRepository(ManeroDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
