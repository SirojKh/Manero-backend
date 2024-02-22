using Manero_Backend.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace Manero_Backend.Models.Schemas.Product
{
    public class ProductSchema
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public Guid CategoryId { get; set; }
        public Guid CompanyId { get; set; }

        public ICollection<Guid> TagIds { get; set; }
        public ICollection<Guid> ColorIds { get; set; }
        public ICollection<Guid> SizeIds { get; set; }


        public static implicit operator ProductEntity(ProductSchema schema)
        {
            return new ProductEntity()
            {
                Name = schema.Name,
                Price = schema.Price,
                ImageUrl = schema.ImageUrl,
                CategoryId = schema.CategoryId,
                CompanyId = schema.CompanyId,
                Description = schema.Description
            };
        }
    }
}
