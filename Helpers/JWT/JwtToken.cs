using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using Manero_Backend.Models.Auth;
using Manero_Backend.Models.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Manero_Backend.Helpers.JWT;

public class JwtToken : IJwtToken
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<AppUser> _userManager;


    public JwtToken(IConfiguration configuration, UserManager<AppUser> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<string> GenerateToken(AppUser user, bool rememberMe)
    {
        
        var identity = await GenerateClaimsIdentity(user);
        var expires = DateTime.UtcNow.AddDays(1);
        if (rememberMe)
            expires = DateTime.UtcNow.AddMonths(3);
        
        //var expires = DateTime.UtcNow.AddSeconds(1);
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _configuration.GetSection("TokenValidation").GetValue<string>("Issuer")!,
            Audience = _configuration.GetSection("TokenValidation").GetValue<string>("Audience")!,
            Subject = identity,
            Expires = expires,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration.GetSection("TokenValidation").GetValue<string>("SecretKey")!)),
                SecurityAlgorithms.HmacSha512Signature    
            )
        };

        return tokenHandler.WriteToken(tokenHandler.CreateToken(securityTokenDescriptor));
    }
    
    public async Task<ClaimsIdentity> GenerateClaimsIdentity(AppUser identityUser)
    {
        var claimsIdentity = new ClaimsIdentity(new []
        {
            new Claim("id", identityUser.Id.ToString()),
            new Claim(ClaimTypes.Name, identityUser.Email!),
            new Claim(ClaimTypes.Role, (await _userManager.GetRolesAsync(identityUser))[0])
        });

        return claimsIdentity;
    }
    
    public string GetEmailFromClaim(HttpContext httpContext)
    {
        // Get the JWT bearer token from the authorization header
        var authHeader = httpContext.Request.Headers["Authorization"].ToString();
        var token = authHeader.Substring("Bearer ".Length).Trim();

        // Decode the JWT token
        var jwtHandler = new JwtSecurityTokenHandler();
        var jwtToken = jwtHandler.ReadJwtToken(token);

        // Get the email claim from the JWT token
        var emailClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;

        return emailClaim!;
    }

    public string GetIdFromClaim(HttpContext httpContext)
    {

        // Get the JWT bearer token from the authorization header
        var authHeader = httpContext.Request.Headers["Authorization"].ToString();
        var token = authHeader.Substring("Bearer ".Length).Trim();

        // Decode the JWT token
        var jwtHandler = new JwtSecurityTokenHandler();
        var jwtToken = jwtHandler.ReadJwtToken(token);

        // Get the email claim from the JWT token
        var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

        return userId!;
    }

    public bool Verify(string jwt)
    {
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = _configuration.GetSection("TokenValidation").GetValue<string>("Issuer")!,
            ValidateAudience = true,
            ValidAudience = _configuration.GetSection("TokenValidation").GetValue<string>("Audience")!,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("TokenValidation").GetValue<string>("SecretKey")!))
        };

        try
        {
            var claimsPrincipal = new JwtSecurityTokenHandler()
                .ValidateToken(jwt, validationParameters, out var rawValidatedToken);

            //long exp = long.Parse(claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "exp").Value);

            //if (exp < DateTimeOffset.UtcNow.ToUnixTimeSeconds())
            //    return false;
            
            return true;
            // Or, you can return the ClaimsPrincipal
            // (which has the JWT properties automatically mapped to .NET claims)
        }
        catch (SecurityTokenValidationException)
        {
            // The token failed validation!
            // TODO: Log it or display an error.
            return false;
        }
        catch (ArgumentException)
        {
            // The token was not well-formed or was invalid for some other reason.
            // TODO: Log it or display an error.
            return false;
        }
    }


}