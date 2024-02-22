using Manero_Backend.Helpers.Factory;
using Manero_Backend.Models.Auth;
using Manero_Backend.Models.Dtos.Authentication;
using System.ComponentModel.DataAnnotations;

namespace Manero_Backend.Models.Schemas.Authentication
{
    public class RegisterSchema
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
        public string Password { get; set; } = string.Empty;

        public static implicit operator AppUser(RegisterSchema schema) => IdentityFactory.Create(schema);
    }
}
