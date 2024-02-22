using System.Security.Claims;
using Manero_Backend.Models.Auth;

namespace Manero_Backend.Models.Interfaces.Services;

public interface IJwtToken
{
    public bool Verify(string jwt);
    public Task<string> GenerateToken(AppUser user, bool rememberMe);
    public string GetIdFromClaim(HttpContext httpContext);
}