namespace Manero_Backend.Models.Schemas.Order
{
    public class OrderProductSchema
    {
        public Guid ProductId { get; set; }
        public Guid ColorId { get; set; }
        public Guid SizeId { get; set; }
        public int Quantity { get; set; }

        
    }
}
