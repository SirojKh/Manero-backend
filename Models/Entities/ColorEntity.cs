using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Manero_Backend.Models.Entities
{
    public class ColorEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Hex { get; set; } = null!;

        public ICollection<OrderProductEntity> OrderProducts { get; set; } //M:1
        public ICollection<ProductColorEntity> ProductColors { get; set; } //M:M

        public bool ShouldSerializeOrderProducts()
        {
            return OrderProducts == null ? false : true;
        }
        public bool ShouldSerializeProductColors()
        {
            return ProductColors == null ? false : true;
        }
    }
}
