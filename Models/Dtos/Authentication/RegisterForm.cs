using System.ComponentModel.DataAnnotations;
using Manero_Backend.Helpers.Factory;
using Manero_Backend.Models.Auth;

namespace Manero_Backend.Models.Dtos.Authentication;

public class RegisterForm
{
    [Microsoft.Build.Framework.Required]
    public string FirstName { get; set; } = string.Empty;
    
    [Microsoft.Build.Framework.Required]
    public string LastName { get; set; } = string.Empty;
    
    [Microsoft.Build.Framework.Required]
    [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = string.Empty;
    
    [Microsoft.Build.Framework.Required]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
    public string Password { get; set; } = string.Empty;
    
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = string.Empty;

    //public static implicit operator AppUser(RegisterForm registrationForm) => IdentityFactory.Create(registrationForm); 
}