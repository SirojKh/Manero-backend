namespace Manero_Backend.Models.Schemas.PromoCode
{
    public class PromoCodeGetSchema
    {
        public string Code { get; set; } = null!;

        public static implicit operator string(PromoCodeGetSchema schema)
        {
            return schema.Code;
        }
    }
}
