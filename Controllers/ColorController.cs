using Manero_Backend.Helpers.Services;
using Manero_Backend.Models.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        [Route("~/v1/api/colors")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return await _colorService.GetAllAsync();
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, "");
            }
        }
    }
}
