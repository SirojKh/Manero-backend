namespace Manero_Backend.Models.Schemas.PaymentDetail
{
    public class PaymentDetailDeleteSchema
    {
        public Guid PaymentDetailId { get; set; }

        public static implicit operator Guid(PaymentDetailDeleteSchema schema)
        {
            return schema.PaymentDetailId;
        }
    }
}
