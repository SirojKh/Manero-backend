using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Schemas.PromoCode
{
    public class PromoCodeSchema
    {
        public Guid CompanyId { get; set; }
        public decimal Discount { get; set; }
        public long ValidToUnix { get; set; }
        public string Code { get; set; } = null!;
        public static implicit operator PromoCodeEntity(PromoCodeSchema schema)
        {
            return new PromoCodeEntity()
            {
                CompanyId = schema.CompanyId,
                Discount = schema.Discount,
                ValidToUnix = schema.ValidToUnix,
                Code = schema.Code
            };
        }
    }
}
