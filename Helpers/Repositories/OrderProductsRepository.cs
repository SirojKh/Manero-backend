using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;

namespace Manero_Backend.Helpers.Repositories
{
    public class OrderProductsRepository : BaseRepository<OrderProductEntity>, IOrderProductsRepository
    {
        private readonly ManeroDbContext _context;

        public OrderProductsRepository(ManeroDbContext context) : base(context) 
        {
            _context = context;
        }
    }
}
