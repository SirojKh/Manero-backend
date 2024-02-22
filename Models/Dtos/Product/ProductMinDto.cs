using Manero_Backend.Models.Entities;
using Newtonsoft.Json;
using System.Collections;
using System.Drawing;

namespace Manero_Backend.Models.Dtos.Product
{
    public class ProductMinDto
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int ReviewCount { get; set; }

        public bool Liked { get; set; }
        public CompanyEntity Company { get; set; } = null!;
        public IEnumerable<TagEntity> Tags { get; set; } = null!;
        public CategoryEntity Category { get; set; } = null!;
        public IEnumerable<ColorEntity> Colors { get; set; } = null!;
        public IEnumerable<SizeEntity> Sizes { get; set; } = null!;
    }
}


