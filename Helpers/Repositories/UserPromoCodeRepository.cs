using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;

namespace Manero_Backend.Helpers.Repositories
{
    public class UserPromoCodeRepository : BaseRepository<UserPromoCodeEntity>, IUserPromoCodeRepository
    {
        private readonly ManeroDbContext _context;

        public UserPromoCodeRepository(ManeroDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
