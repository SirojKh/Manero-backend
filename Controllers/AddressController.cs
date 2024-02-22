using Manero_Backend.Helpers.JWT;
using Manero_Backend.Helpers.Services;
using Manero_Backend.Models.Interfaces.Services;
using Manero_Backend.Models.Schemas.Address;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IJwtToken _jwtToken;

        public AddressController(IAddressService addressService, IJwtToken jwtToken)
        {
            _addressService = addressService;
            _jwtToken = jwtToken;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddressSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest("");

            var userId = _jwtToken.GetIdFromClaim(HttpContext);

            var result = await _addressService.CreateAsync(schema, userId);

            return result;

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(AddressDeleteSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest("");

            var userId = _jwtToken.GetIdFromClaim(HttpContext);

            return await _addressService.RemoveAsync(schema, userId);
        }

        [HttpGet]
        [Route("~/v1/api/[controller]es")]
        public async Task<IActionResult> GetAllAsync()
        {
            var userId = _jwtToken.GetIdFromClaim(HttpContext);

            return await _addressService.GetAllAsync(userId);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(AddressPutSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest("");

            var userId = _jwtToken.GetIdFromClaim(HttpContext);

            return await _addressService.PutAsync(schema, userId);
        }
        
    }
}
