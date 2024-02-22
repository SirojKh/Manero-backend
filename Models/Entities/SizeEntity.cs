using Newtonsoft.Json;

namespace Manero_Backend.Models.Entities
{
    public class SizeEntity : BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<OrderProductEntity> OrderProducts { get; set; } //M:1
        public ICollection<ProductSizeEntity> ProductSizes { get; set; } //M:M

        public bool ShouldSerializeOrderProducts()
        {
            return OrderProducts == null ? false : true;
        }
        public bool ShouldSerializeProductSizes()
        {
            return ProductSizes == null ? false : true;
        }


    }
}
