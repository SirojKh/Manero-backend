using Manero_Backend.Models.Auth;
using Manero_Backend.Models.Dtos.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero_Backend.Models.Entities;

public class ProductEntity : BaseEntity
{
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	
	[Column(TypeName = "decimal(18,2)")]
	public decimal Price { get; set; }
	public string? ImageUrl { get; set; }

    public Guid CategoryId { get; set; }
    public CategoryEntity Category { get; set; }

	public Guid CompanyId { get; set; }
	public CompanyEntity Company { get; set; }

	public ICollection<OrderProductEntity> OrderProducts { get; set; } //M:M
	public ICollection<TagProductEntity> TagProducts { get; set; } //M:M
	public ICollection<ReviewEntity> Reviews { get; set; } //M:M
	public ICollection<WishEntity> WishList { get; set; } //M:M
	public ICollection<ProductColorEntity> ProductColors { get; set; } //M:M
	public ICollection<ProductSizeEntity> ProductSizes { get; set; } //M:M

	public static implicit operator ProductMinDto(ProductEntity entity)
	{
		return new ProductMinDto()
		{
			Id = entity.Id,
			Name = entity.Name,
			Rating = entity.Reviews.Count != 0 ? entity.Reviews.Sum(r => r.Rating) / entity.Reviews.Count : 0,
			ReviewCount = entity.Reviews.Count,
			ImageUrl = entity.ImageUrl,
			Price = entity.Price,
            Company = new CompanyEntity() { Id = entity.Company.Id, Name = entity.Company.Name },
            Tags = entity.TagProducts.Select(x => new TagEntity() { Id = x.Tag.Id, Name = x.Tag.Name }).ToList(),
			Category = entity.Category,
			Colors = entity.ProductColors.Select(x => new ColorEntity() { Id = x.Color.Id, Name = x.Color.Name, Hex = x.Color.Hex }).ToList(),
			Sizes = entity.ProductSizes.Select(x => new SizeEntity() { Id = x.Size.Id, Name = x.Size.Name }).ToList()
		};
	}

	public static implicit operator ProductDto(ProductEntity entity) 
	{
		return new ProductDto()
		{
			Id = entity.Id,
			Name = entity.Name,
			Description = entity.Description,
			Price = entity.Price,
			ImageUrl = entity.ImageUrl,
			Category = entity.Category,
			Company = new CompanyEntity() { Id = entity.Company.Id, Name = entity.Company.Name },
			Rating = entity.Reviews.Count != 0 ? entity.Reviews.Sum(r => r.Rating) / entity.Reviews.Count : 0,
			ReviewCount = entity.Reviews.Count,
			Colors = entity.ProductColors.Select(x => new ColorEntity() { Id = x.Color.Id, Name = x.Color.Name, Hex = x.Color.Hex }).ToList(),
			Sizes = entity.ProductSizes.Select(x => new SizeEntity() { Id = x.Size.Id, Name = x.Size.Name }).ToList(),
			Tags = entity.TagProducts.Select(x => new TagEntity() { Id = x.Tag.Id, Name = x.Tag.Name }).ToList(),
			Reviews = entity.Reviews.Select(x => new { Id = x.Id, Rating = x.Rating, RatedBy = new { FirstName = x.AppUser.FirstName, LastName = x.AppUser.LastName, Comment = x.Comment } })
        };
	}
}
