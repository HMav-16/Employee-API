using EmployeeWebApi.Data;
using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ApplicationDBContext _LocDBContext;
        public LocationsController(ApplicationDBContext LocDBContext)
        {
            _LocDBContext = LocDBContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_LocDBContext.Locations.ToList());
        }


        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_LocDBContext.Locations.FirstOrDefault(c => c.locationId == id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] location location)
        {
            _LocDBContext.Locations.Add(location);
            _LocDBContext.SaveChanges();

            return Ok("Location created");
        }


        [HttpPut]
        public IActionResult Put([FromBody] location location)
        {
            var loc = _LocDBContext.Locations
                       .FirstOrDefault(c => c.locationId == location.locationId);

            if (loc == null)
                return BadRequest();

            loc.StreetAddress  = loc.StreetAddress;
            loc.StateProvince = loc.StateProvince;
            loc.City = loc.City;
            loc.PostalCode = loc.PostalCode;
            loc.CountryId = loc.CountryId;

            _LocDBContext.Locations.Update(loc);
            _LocDBContext.SaveChanges();

            return Ok("Location updated");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var loc = _LocDBContext.Locations
                      .FirstOrDefault(c => c.locationId == id);

            if (loc == null)
                return BadRequest();

            _LocDBContext.Locations.Remove(loc);
            _LocDBContext.SaveChanges();

            return Ok("Location deleted");
        }
    }
}
