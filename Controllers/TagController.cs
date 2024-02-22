using Manero_Backend.Helpers.Services;
using Manero_Backend.Models.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        [Route("~/v1/api/tags")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return await _tagService.GetAllAsync();
            }
            catch (Exception e) //Ilogger
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
