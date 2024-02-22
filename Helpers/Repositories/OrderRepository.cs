using Manero_Backend.Contexts;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;

namespace Manero_Backend.Helpers.Repositories
{
    public class OrderRepository : BaseRepository<OrderEntity>, IOrderRepository
    {
        private readonly ManeroDbContext _dbContext;

        public OrderRepository(ManeroDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
