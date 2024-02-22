namespace Manero_Backend.Models.Entities
{
    public class ProductColorEntity : BaseEntity
    {
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public Guid ColorId { get; set; }
        public ColorEntity Color { get; set; }
    }
}
