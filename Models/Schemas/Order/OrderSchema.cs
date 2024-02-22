using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Schemas.Order
{
    public class OrderSchema
    {
        public ICollection<OrderProductSchema> OrderProducts { get; set; }
        public Guid? PromoCodeId { get; set; }
        public Guid AddressId { get; set; }
        public Guid PaymentDetailId { get; set; }
        public string Comment { get; set; }


        public static implicit operator OrderEntity(OrderSchema schema)
        {
            return new OrderEntity()
            {
                PaymentDetailId = schema.PaymentDetailId,
                AddressId = schema.AddressId,
                PromoCodeId = schema.PromoCodeId,
                Comment = schema.Comment
            };
        }
    }
}
