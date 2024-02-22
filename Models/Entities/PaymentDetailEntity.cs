using Manero_Backend.Models.Auth;
using Manero_Backend.Models.Dtos.PaymentDetail;

namespace Manero_Backend.Models.Entities
{
    public class PaymentDetailEntity : BaseEntity
    {
        public string CardName { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public string Cvv { get; set; } = null!;
        public string ExpDate { get; set; } = null!;

        public string AppUserId { get; set; } = null!;
        public AppUser AppUser { get; set; } = null!;
        public ICollection<OrderEntity> Orders { get; set; }

        public static implicit operator PaymentDetailDto(PaymentDetailEntity entity)
        {
            return new PaymentDetailDto()
            {
                Id = entity.Id,    
                CardName = entity.CardName,
                CardNumber = entity.CardNumber,
                Cvv = entity.Cvv,
                ExpDate = entity.ExpDate
            };
        }

    }
}
