using Manero_Backend.Helpers.JWT;
using Manero_Backend.Helpers.Services;
using Manero_Backend.Models.Interfaces.Services;
using Manero_Backend.Models.Schemas.PromoCode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class PromoCodeController : ControllerBase
    {
        private readonly IPromoCodeService _promoCodeService;
        private readonly IJwtToken _jwtToken;

        public PromoCodeController(IPromoCodeService promoCodeService, IJwtToken jwtToken)
        {
            _promoCodeService = promoCodeService;
            _jwtToken = jwtToken;
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync(PromoCodeSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest("");

            try
            {
                return await _promoCodeService.CreateAsync(schema);
            }
            catch (Exception e) //Ilogger
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddAsync(PromoCodeAddSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userId = _jwtToken.GetIdFromClaim(HttpContext);

                return await _promoCodeService.AddAsync(schema, userId);
            }
            catch (Exception e) //Ilogger
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("~/v1/api/[controller]s")]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userId = _jwtToken.GetIdFromClaim(HttpContext);

                return await _promoCodeService.GetAllAsync(userId);
            }
            catch (Exception e) //Ilogger
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("getvalidate")]
        [Authorize]
        public async Task<IActionResult> GetValidateAsync(PromoCodeGetSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userId = _jwtToken.GetIdFromClaim(HttpContext);

                return await _promoCodeService.GetValidateAsync(schema, userId);
            }
            catch (Exception e) //Ilogger
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
