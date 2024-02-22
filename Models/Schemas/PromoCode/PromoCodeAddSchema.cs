namespace Manero_Backend.Models.Schemas.PromoCode
{
    public class PromoCodeAddSchema
    {
        public string Code { get; set; }

        public static implicit operator string(PromoCodeAddSchema schema)
        {
            return schema.Code;
        }
    }
}
