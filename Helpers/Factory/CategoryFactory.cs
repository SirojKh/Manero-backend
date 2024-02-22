using Manero_Backend.Models.Dtos.Category;
using Manero_Backend.Models.Entities;

namespace Manero_Backend.Helpers.Factory;

public class CategoryFactory
{
    public static CategoryEntity CreateEntity(CategoryRequest category)
    {
        return new()
        {
            Name = category.Name
        };
    }
    
    public static CategoryEntity CreateEntity(CategoryResponse category)
    {
        return new()
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public static CategoryRequest CreateRequest(string entityCategory)
    {
        return new CategoryRequest()
        {
            Name = entityCategory
        };
    }

    public static CategoryResponse CreateResponse(CategoryEntity category)
    {
        return new CategoryResponse()
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}