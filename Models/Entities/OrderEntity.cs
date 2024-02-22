using Manero_Backend.Models.Auth;

namespace Manero_Backend.Models.Entities
{
    public class OrderEntity : BaseEntity
    {
        public string AppUserId { get; set; } = null!;
        public AppUser AppUser { get; set; }

        public Guid PaymentDetailId { get; set; }

        public PaymentDetailEntity PaymentDetail { get; set; }

        public Guid AddressId { get; set; }
        public AddressEntity Address { get; set; }
        public Guid? PromoCodeId { get; set; }
        public PromoCodeEntity PromoCode { get; set; }

        public decimal TotalPrice { get; set; }
        public string? Comment { get; set; }

        public bool Cancelled { get; set; }
        public string? CancelledMessage { get; set; }


        public ICollection<OrderProductEntity> OrderProducts { get; set; } //M:M
        public ICollection<OrderStatusEntity> OrderStatuses { get; set; } //M:M men jag tycer det är m:1
        
    }
}
