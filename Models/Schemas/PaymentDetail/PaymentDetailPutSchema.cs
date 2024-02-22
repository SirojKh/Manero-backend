using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Schemas.PaymentDetail
{
    public class PaymentDetailPutSchema
    {
        public Guid Id { get; set; }
        public string CardName { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public string Cvv { get; set; } = null!;
        public string ExpDate { get; set; } = null!;

        public static implicit operator PaymentDetailEntity(PaymentDetailPutSchema schema)
        {
            return new PaymentDetailEntity()
            {
                Id = schema.Id,
                CardName = schema.CardName,
                CardNumber = schema.CardNumber,
                Cvv = schema.Cvv,
                ExpDate = schema.ExpDate
            };
        }
    }
}
