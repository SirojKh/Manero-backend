using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;

namespace Manero_Backend.Helpers.Services
{
    public class OrderStatusService : BaseService<OrderStatusEntity>, IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public OrderStatusService(IOrderStatusRepository orderStatusRepository) : base(orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }
    }
}
