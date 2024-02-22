using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Schemas.Order;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Models.Interfaces.Services
{
    public interface IOrderService : IBaseService<OrderEntity>
    {
        public Task<IActionResult> CreateAsync(OrderSchema schema, string userId);
    }
}
