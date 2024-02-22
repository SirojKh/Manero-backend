using Manero_Backend.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero_Backend.Models.Dtos.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public int ReviewCount { get; set; }
        public int Rating { get; set; }

        public bool Liked { get; set; }

        public CategoryEntity Category { get; set; } = null!;
        public CompanyEntity Company { get; set; } = null!;

        public IEnumerable<object> Reviews { get; set; } = null!;
        public IEnumerable<TagEntity> Tags { get; set; } = null!;
        public IEnumerable<ColorEntity> Colors { get; set; } = null!;
        public IEnumerable<SizeEntity> Sizes { get; set; } = null!;
    }
}
