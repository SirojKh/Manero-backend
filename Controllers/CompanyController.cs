using Manero_Backend.Helpers.Services;
using Manero_Backend.Models.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Route("~/v1/api/companies")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return await _companyService.GetAllAsync();
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, "");
            }
        }
    }
}
