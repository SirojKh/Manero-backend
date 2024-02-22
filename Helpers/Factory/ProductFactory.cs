using Manero_Backend.Models.Dtos.Product;
using Manero_Backend.Models.Entities;

namespace Manero_Backend.Helpers.Factory;

public class ProductFactory
{
    public static ProductResponse CreateResponse(ProductEntity entity)
    {
        return new ProductResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            //Color = entity.Color,
            //Size = entity.Size,
            Price = entity.Price,
            //StarRating = entity.StarRating, 
            ImageUrl = entity.ImageUrl,
            //TagId = entity.TagId,
            CategoryId = entity.CategoryId,
        };
    }

    public static ProductEntity CreateEntity(ProductRequest product)
    {
        return new ProductEntity()
        {
            Name = product.Name,
            Description = product.Description,
            //Color = product.Color,
            //Size = product.Size,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
        };
    }
}