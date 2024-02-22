using System.Net;
using Manero_Backend.Models.Auth;
using Manero_Backend.Models.Dtos.Authentication;
using Manero_Backend.Models.Schemas.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Models.Interfaces.Services;

public interface IAuthService
{
    Task<IActionResult> RegisterAsync(RegisterSchema schema);
    
    Task<IActionResult> LoginAsync(LoginSchema schema);
    Task<IActionResult> LogoutAsync();

    public Task<IActionResult> Test(string jwtToken);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<AppUser>> GetAllAsync();
    public Task<IActionResult> SetPhoneNumberAsync(string userId, string phoneNumber);
    public Task<IActionResult> ValidatePhoneNumber(string userId, string code);
}