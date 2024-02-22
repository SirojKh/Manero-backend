using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Schemas.Product;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Manero_Backend.Models.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<ProductEntity>
    {
        public Task FillDataAsync();
        public Task<ProductEntity> GetByGuid(Guid guid);
        public Task<List<ProductEntity>> GetByOption(ProductOptionSchema option);
        public Task<bool> ExistsAsync(Guid guid);

        public Task<List<ProductEntity>> GetWishListAsync(string userId);
        public Task<decimal> CalcTotalPrice(List<Guid> productIds, Guid companyId, decimal discount);
        public Task<List<ProductEntity>> GetAllIncludeAsync(Expression<Func<ProductEntity, bool>> predicate);

        public Task<ICollection<ProductEntity>> GetAllDevAsync();
    }
}
