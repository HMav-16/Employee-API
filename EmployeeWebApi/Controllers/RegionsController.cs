using EmployeeWebApi.Data;
using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly ApplicationDBContext _RegDBContext;
        public RegionsController(ApplicationDBContext RegDBContext)
        {
            _RegDBContext = RegDBContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_RegDBContext.Regions.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_RegDBContext.Regions.FirstOrDefault(c => c.RegionId == id));
        }
    }
}
