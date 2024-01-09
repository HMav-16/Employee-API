using EmployeeWebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDBContext _CountrieDBContext;
        public CountriesController(ApplicationDBContext CountrieDBContext)
        {
            _CountrieDBContext = CountrieDBContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_CountrieDBContext.Countries.ToList());
        }
    }
}
