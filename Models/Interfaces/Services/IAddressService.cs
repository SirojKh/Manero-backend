using Manero_Backend.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Manero_Backend.Models.Interfaces.Services
{
    public interface IAddressService
    {
        public Task<IActionResult> CreateAsync(AddressEntity entity, string userId);
        public Task<IActionResult> RemoveAsync(Guid addressId, string userId);
        public Task<IActionResult> GetAllAsync(string userId);
        public Task<IActionResult> PutAsync(AddressEntity entity, string userId);
        public Task<bool> ExistsAsync(Expression<Func<AddressEntity, bool>> predicate);
    }
}
