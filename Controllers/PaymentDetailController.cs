using Manero_Backend.Helpers.JWT;
using Manero_Backend.Helpers.Services;
using Manero_Backend.Models.Interfaces.Services;
using Manero_Backend.Models.Schemas.Address;
using Manero_Backend.Models.Schemas.PaymentDetail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentDetailController : ControllerBase
    {
        private readonly IPaymentDetailService _paymentDetailService;
        private readonly IJwtToken _jwtToken;

        public PaymentDetailController(IPaymentDetailService paymentDetailService, IJwtToken jwtToken)
        {
            _paymentDetailService = paymentDetailService;
            _jwtToken = jwtToken;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(PaymentDetailSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest("");

            try
            {
                var userId = _jwtToken.GetIdFromClaim(HttpContext);

                return await _paymentDetailService.CreateAsync(schema, userId);
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, "");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(PaymentDetailDeleteSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest("");

            try
            {
                var userId = _jwtToken.GetIdFromClaim(HttpContext);

                return await _paymentDetailService.RemoveAsync(schema, userId);
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, "");
            }
        }

        [HttpGet]
        [Route("~/v1/api/[controller]s")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var userId = _jwtToken.GetIdFromClaim(HttpContext);

                return await _paymentDetailService.GetAllAsync(userId);
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, "");
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(PaymentDetailPutSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest("");

            try
            {
                var userId = _jwtToken.GetIdFromClaim(HttpContext);

                return await _paymentDetailService.PutAsync(schema, userId);
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, "");
            }
        }
    }
}
