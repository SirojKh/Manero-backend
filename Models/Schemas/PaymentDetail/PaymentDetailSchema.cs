using Manero_Backend.Models.Entities;

namespace Manero_Backend.Models.Schemas.PaymentDetail
{
    public class PaymentDetailSchema
    {
        public string CardName { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public string Cvv { get; set; } = null!;
        public string ExpDate { get; set; } = null!;

        public static implicit operator PaymentDetailEntity(PaymentDetailSchema schema)
        {
            return new PaymentDetailEntity()
            {
                CardName = schema.CardName,
                CardNumber = schema.CardNumber,
                Cvv = schema.Cvv,
                ExpDate = schema.ExpDate
            };
        }
    }
}
