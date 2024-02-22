using Manero_Backend.Helpers.Factory;
using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Dtos.Category;

public class CategoryRequest
{
    public string Name { get; set; } = null!;
    
    public static implicit operator CategoryEntity(CategoryRequest category)
    {
        return CategoryFactory.CreateEntity(category);
    }
}