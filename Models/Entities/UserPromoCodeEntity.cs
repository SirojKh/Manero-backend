using Manero_Backend.Models.Auth;

namespace Manero_Backend.Models.Entities
{
    public class UserPromoCodeEntity : BaseEntity
    {
        public string AppUserId { get; set; } = null!;
        public AppUser AppUser { get; set; }
        public Guid PromoCodeId { get; set; }
        public PromoCodeEntity PromoCode { get; set; }

        public bool Used { get; set; }
    }
}
