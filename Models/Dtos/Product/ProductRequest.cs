using Manero_Backend.Helpers.Factory;
using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Dtos.Product
{
    public class ProductRequest
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string Color { get; set; } = null!;
		public string Size { get; set; } = null!;
		public decimal Price { get; set; }
		public string? ImageUrl { get; set; }
		public string Tag { get; set; } = null!;
		public string Category { get; set; } = null!;
		public static implicit operator ProductEntity(ProductRequest product)
		{
			return ProductFactory.CreateEntity(product);
		}
	}
}
