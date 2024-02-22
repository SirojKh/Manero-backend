using Manero_Backend.Helpers.Factory;
using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Dtos.Category;

public class CategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    
    public static implicit operator CategoryResponse(CategoryEntity category)
    {
        return CategoryFactory.CreateResponse(category);
    }
    
    public static implicit operator CategoryEntity(CategoryResponse category)
    {
        return CategoryFactory.CreateEntity(category);
    }
}