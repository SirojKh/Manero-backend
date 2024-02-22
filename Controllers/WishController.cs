using Manero_Backend.Helpers.JWT;
using Manero_Backend.Models.Interfaces.Services;
using Manero_Backend.Models.Schemas.Wish;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    [Authorize]
    public class WishController : ControllerBase
    {
        private readonly IWishService _wishService;
        private readonly IJwtToken _jwtToken;

        public WishController(IWishService wishService, IJwtToken jwtToken)
        {
            _wishService = wishService;
            _jwtToken = jwtToken;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(WishSchema schema)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userId = _jwtToken.GetIdFromClaim(HttpContext);

                return await _wishService.AddAsync(schema, userId);
            }
            catch(Exception e) //Ilogger
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("~/v1/api/[controller]es")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var userId = _jwtToken.GetIdFromClaim(HttpContext);

                return await _wishService.GetAllAsync(userId);
            }
            catch (Exception e) //Ilogger
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(WishSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userId = _jwtToken.GetIdFromClaim(HttpContext);

                return await _wishService.RemoveAsync(schema, userId);
            }
            catch (Exception e) //Ilogger
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
