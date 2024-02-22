using Manero_Backend.Models.Auth;
using Manero_Backend.Models.Dtos.Authentication;
using Manero_Backend.Models.Schemas.Authentication;

namespace Manero_Backend.Helpers.Factory;

public class IdentityFactory
{
    public static AppUser Create(RegisterSchema schema)
    {
        return new()
        {
            FirstName = schema.FirstName,
            LastName = schema.LastName,
            Email = schema.Email,
            UserName = schema.Email
        };
    }
}