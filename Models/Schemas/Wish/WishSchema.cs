using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Schemas.Wish
{
    public class WishSchema
    {
        public Guid ProductId { get; set; }

        public static implicit operator WishEntity(WishSchema schema)
        {
            return new WishEntity()
            {
                ProductId = schema.ProductId
            };
        }

        public static implicit operator Guid(WishSchema schema)
        {
            return schema.ProductId;
        }
    }
}
