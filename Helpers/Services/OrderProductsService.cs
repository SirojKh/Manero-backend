using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;

namespace Manero_Backend.Helpers.Services
{
    public class OrderProductsService : BaseService<OrderProductEntity>, IOrderProductsService
    {
        private readonly IOrderProductsRepository _orderProductsRepository;

        public OrderProductsService(IOrderProductsRepository orderProductsRepository) : base(orderProductsRepository)
        {
            _orderProductsRepository = orderProductsRepository;
        }
    }
}
