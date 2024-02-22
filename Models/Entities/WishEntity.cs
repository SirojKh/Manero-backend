using Manero_Backend.Models.Auth;

namespace Manero_Backend.Models.Entities
{
    public class WishEntity : BaseEntity
    {
        public string AppUserId { get; set; } = null!;
        public AppUser AppUser { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
