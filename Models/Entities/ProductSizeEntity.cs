namespace Manero_Backend.Models.Entities
{
    public class ProductSizeEntity : BaseEntity
    {
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public Guid SizeId { get; set; }
        public SizeEntity Size { get; set; }
    }
}
