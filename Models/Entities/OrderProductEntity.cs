namespace Manero_Backend.Models.Entities
{
    public class OrderProductEntity : BaseEntity
    {
        public Guid OrderId { get; set; }
        public OrderEntity Order { get; set; }

        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public Guid SizeId { get; set; }
        public SizeEntity Size { get; set; }

        public Guid ColorId { get; set; }
        public ColorEntity Color { get; set; }

        public int Quantity { get; set; }
    }
}
