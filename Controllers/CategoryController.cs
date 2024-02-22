using Manero_Backend.Models.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("~/v1/api/categories")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return await _categoryService.GetAllAsync();
            }
            catch(Exception e) //Ilogger
            {
                return StatusCode(500,"");
            }
        }
    }
}
