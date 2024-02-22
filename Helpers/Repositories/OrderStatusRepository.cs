using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;

namespace Manero_Backend.Helpers.Repositories
{
    public class OrderStatusRepository : BaseRepository<OrderStatusEntity>, IOrderStatusRepository
    {
        private readonly ManeroDbContext _context;

        public OrderStatusRepository(ManeroDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
