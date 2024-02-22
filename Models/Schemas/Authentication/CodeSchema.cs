using System.ComponentModel.DataAnnotations;

namespace Manero_Backend.Models.Schemas.Authentication
{
    public class CodeSchema
    {
        [MinLength(6), MaxLength(6)]
        public string Code { get; set; } = null!;

        public static implicit operator string(CodeSchema schema)
        {
            return schema.Code;
        }
    }
}
