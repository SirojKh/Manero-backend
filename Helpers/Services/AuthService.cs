using System.Net;
using System.Security.Claims;
using Manero_Backend.Helpers.Enums;
using Manero_Backend.Helpers.Factory;
using Manero_Backend.Helpers.JWT;
using Manero_Backend.Models.Auth;
using Manero_Backend.Models.Dtos.Authentication;
using Manero_Backend.Models.Interfaces.Services;
using Manero_Backend.Models.Schemas.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;


namespace Manero_Backend.Helpers.Services;

public class AuthService : IAuthService
{
    #region Constructor
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    
    private readonly IJwtToken _jwtToken;
    private SignInManager<AppUser> _signInManager;


    public AuthService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, IJwtToken jwtToken, SignInManager<AppUser> signInManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _jwtToken = jwtToken;
        _signInManager = signInManager;
    }

    #endregion

    public async Task<IActionResult> Test(string jwtToken)
    {
        


        return HttpResultFactory.Ok();
        //return HttpResultFactory.Ok(_jwtToken.Verify(jwtToken));
    }

    public async Task<IActionResult> SetPhoneNumberAsync(string userId, string phoneNumber)
    {
        AppUser user = await _userManager.FindByIdAsync(userId);

        if (user.PhoneNumberConfirmed)
            return HttpResultFactory.Forbid();


        return (await _userManager.SetPhoneNumberAsync(user, phoneNumber)).Succeeded ? HttpResultFactory.Ok("") : HttpResultFactory.StatusCode(500, "");
    }

    public async Task<IActionResult> ValidatePhoneNumber(string userId, string code)
    {
        AppUser user = await _userManager.FindByIdAsync(userId);

        if (user.PhoneNumberConfirmed)
            return HttpResultFactory.Forbid();

        if (user.Otp != code)
            return HttpResultFactory.Unauthorized("");

        user.PhoneNumberConfirmed = true;

        await _userManager.UpdateAsync(user);

        return HttpResultFactory.NoContent();
    }


    #region Register
    public async Task<IActionResult> RegisterAsync(RegisterSchema user)
    {
        if(await _userManager.FindByEmailAsync(user.Email) != null) return HttpResultFactory.Conflict("");

        string role = await CheckIfFirstUserAsync();

        var result = await _userManager.CreateAsync(user, user.Password);

        if (!result.Succeeded) return HttpResultFactory.BadRequest("");
        
        var identityUser = await _userManager.FindByEmailAsync(user.Email);
        
        var resultRole = await _userManager.AddToRoleAsync(identityUser, role);

        if (!resultRole.Succeeded) return HttpResultFactory.BadRequest("");

        return HttpResultFactory.Created("", await _jwtToken.GenerateToken(identityUser, false));
    }
    
    #endregion
    
    #region Login
    public async Task<IActionResult> LoginAsync(LoginSchema schema)
    {
        var identityUser = await _userManager.FindByEmailAsync(schema.Email);
        if (identityUser == null)
            return HttpResultFactory.Unauthorized("");
            
            
        var signInResult = await _signInManager.CheckPasswordSignInAsync(identityUser, schema.Password, false);
        if (!signInResult.Succeeded)
            return HttpResultFactory.Unauthorized("");
        

        return HttpResultFactory.Ok(await _jwtToken.GenerateToken(identityUser, schema.RememberMe));
    }
    
    #endregion
    
    #region Logout
    public async Task<IActionResult> LogoutAsync()
    {
        return _signInManager.SignOutAsync().IsCompletedSuccessfully ? HttpResultFactory.Ok() : HttpResultFactory.BadRequest("");
    }
    
    #endregion
    
    #region Delete
    public async Task<bool> DeleteAsync(Guid id)
    {
        var appUser = await _userManager.FindByIdAsync(id.ToString());
        
        if (appUser != null)
            await _userManager.DeleteAsync(appUser);
        
        return true;
    }
    
    #endregion

    #region GetAll, this will get removed later.
    public async Task<IEnumerable<AppUser>> GetAllAsync()
    {
        var result = await _userManager.Users.ToListAsync();
        return result;
    }

    #endregion

    
    #region Logic AuthService
    private async Task<string> CheckIfFirstUserAsync()
    {
        //This will only run once when the first schema ever is added to the database
        if (!_roleManager.Roles.Any())
        {
            foreach (var role in Enum.GetValues(typeof(RoleEnum)))
            {
                await _roleManager.CreateAsync(new IdentityRole(role.ToString()!));
            }
            
            return RoleEnum.Admin.ToString();
        }
        
        return RoleEnum.User.ToString();
    }
    
    #endregion
}