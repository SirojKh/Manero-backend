using Manero_Backend.Models.Auth;

namespace Manero_Backend.Models.Entities
{
	public class ReviewEntity : BaseEntity
	{
		public int Rating { get; set; }
		public string Comment { get; set; } = null!;

		public Guid ProductId { get; set; }
		public ProductEntity Product { get; set; }

		public string AppUserId { get; set; } = null!;
		public AppUser AppUser { get; set; }


        public bool ShouldSerializeProductId()
        {
            return ProductId == Guid.Empty ? false : true;
        }

        public bool ShouldSerializeProduct()
        {
            return Product == null ? false : true;
        }

        public bool ShouldSerializeAppUserId()
        {
            return AppUserId == null ? false : true;
        }
    }
}
