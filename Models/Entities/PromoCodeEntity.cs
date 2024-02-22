using Manero_Backend.Models.Dtos.PromoCode;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero_Backend.Models.Entities
{
    public class PromoCodeEntity : BaseEntity
    {
        [ForeignKey("CompanyId")]
        public Guid CompanyId { get; set; }
        public CompanyEntity Company { get; set; }
        public decimal Discount { get; set; }
        public long ValidToUnix { get; set; }
        public string Code { get; set; } = null!;

        public ICollection<UserPromoCodeEntity> UserPromoCodes { get; set; } //M:M
        public ICollection<OrderEntity> Orders { get; set; } //M:1

        public static implicit operator PromoCodeDto(PromoCodeEntity entity)
        {
            return new PromoCodeDto()
            {
                Id = entity.Id,
                Company = new CompanyEntity() { Id = entity.Company.Id, Name = entity.Company.Name },
                Discount = entity.Discount,
                ValidToUnix = entity.ValidToUnix,
                Code = entity.Code,
                Used = entity.UserPromoCodes != null ? entity.UserPromoCodes.Where(x => x.PromoCodeId == entity.Id).First().Used : false
            };
        }
    }
}
