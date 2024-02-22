using Manero_Backend.Helpers.JWT;
using Manero_Backend.Helpers.Services;
using Manero_Backend.Models.Interfaces.Services;
using Manero_Backend.Models.Schemas.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IJwtToken  _jwtToken;

        public OrderController(IOrderService orderService, IJwtToken jwtToken)
        {
            _orderService = orderService;
            _jwtToken = jwtToken;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(OrderSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest("");

            try
            {
                var userId = _jwtToken.GetIdFromClaim(HttpContext);

                return await _orderService.CreateAsync(schema, userId);
            }
            catch (Exception e) //Ilogger
            {
                Console.WriteLine(e);
                return StatusCode(500, "");
            }
        }
    }
}
