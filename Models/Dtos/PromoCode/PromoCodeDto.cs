using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Dtos.PromoCode
{
    public class PromoCodeDto
    {
        public Guid Id { get; set; }
        public CompanyEntity Company { get; set; }
        public decimal Discount { get; set; }
        public long ValidToUnix { get; set; }
        public string Code { get; set; } = null!;
        public bool Used { get; set; }


    }
}
