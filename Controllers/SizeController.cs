using Manero_Backend.Helpers.Services;
using Manero_Backend.Models.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet]
        [Route("~/v1/api/sizes")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return await _sizeService.GetAllAsync();
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, "");
            }
        }
    }
}
