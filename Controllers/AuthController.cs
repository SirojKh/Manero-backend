using System.Net;
using Manero_Backend.Helpers.JWT;
using Manero_Backend.Models.Dtos.Authentication;
using Manero_Backend.Models.Interfaces.Services;
using Manero_Backend.Models.Schemas.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Constructor
        private readonly IAuthService _authService;
        private readonly IJwtToken _jwtToken;

        public AuthController(IAuthService authService, IJwtToken jwtToken)
        {
            _authService = authService;
            _jwtToken = jwtToken;
        }

        #endregion

        
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterSchema schema)
        {
            if(!ModelState.IsValid)
                return BadRequest("");

            try
            {
                var result = await _authService.RegisterAsync(schema);
                
                return result;
            }
            catch(Exception e) //Ilogger
            {
                return StatusCode(500, "");
            }
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest("");

            try
            {
                var result = await _authService.LoginAsync(schema);

                return result;
            }
            catch(Exception e) //Ilogger
            {
                return StatusCode(500,"");
            }
        }


        [HttpPost("getcode")]
        [Authorize]
        public async Task<IActionResult> GetCode(PhoneNumberSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest("");

            try
            {
                //Send sms with code add later.
                

                //Set phone number.
                var userId = _jwtToken.GetIdFromClaim(HttpContext);

                return await _authService.SetPhoneNumberAsync(userId, schema);
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, "");
            }
        }

        [HttpPost("validatecode")]
        [Authorize]
        public async Task<IActionResult> ValidateOtp(CodeSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest("");

            try
            {
                var userId = _jwtToken.GetIdFromClaim(HttpContext);

                return await _authService.ValidatePhoneNumber(userId, schema); 
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, "");
            }

        }
        
    }
}
