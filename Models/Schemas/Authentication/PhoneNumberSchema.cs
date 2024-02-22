using System.ComponentModel.DataAnnotations;

namespace Manero_Backend.Models.Schemas.Authentication
{
    public class PhoneNumberSchema
    {
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        public static implicit operator string(PhoneNumberSchema schema)
        {
            return schema.PhoneNumber;
        }
    }
}
