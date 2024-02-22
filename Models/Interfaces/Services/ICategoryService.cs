using Manero_Backend.Models.Dtos.Category;
using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Interfaces.Services;

public interface ICategoryService : IBaseService<CategoryEntity> 
{
    public Task<bool> ExistsAsync(Guid categoryId);

    public Task<CategoryEntity> GetOrCreateAsync(CategoryRequest entityCategory);
}