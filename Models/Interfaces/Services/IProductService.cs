using Manero_Backend.Models.Dtos.Category;
using Manero_Backend.Models.Dtos.Product;
using Manero_Backend.Models.Dtos.Review;
using Manero_Backend.Models.Dtos.Tag;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Schemas.Product;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Models.Interfaces.Services;

public interface IProductService: IBaseService<ProductEntity> 
{
    public Task<IActionResult> GetByOptions(IEnumerable<ProductOptionSchema> schema, string userId);
    public Task<IActionResult> GetByGuid(Guid guid, string userId);
    public Task<IActionResult> CreateAsync(ProductSchema schema);
    public Task<IActionResult> SearchAsync(string condition, string userId);

    public Task<decimal> CalcTotalPrice(List<Guid> productIds, Guid companyId, decimal discount);

    public Task<IActionResult> GetAllDevAsync();
    public Task FillDataAsync();
}