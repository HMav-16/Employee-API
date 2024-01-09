using EmployeeWebApi.Data;
using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementsController : ControllerBase
    {
        private readonly ApplicationDBContext _DeptDBContext;

        public DepartementsController(ApplicationDBContext DeptDBContext)
        {
            _DeptDBContext = DeptDBContext;     
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_DeptDBContext.Departements.ToList());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_DeptDBContext.Departements.FirstOrDefault(c => c.DeptId == id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] department department)
        {
            _DeptDBContext.Departements.Add(department);
            _DeptDBContext.SaveChanges();

            return Ok("Departement created");
        }


        [HttpPut]
        public IActionResult Put([FromBody] department department)
        {
            var dep = _DeptDBContext.Departements
                       .FirstOrDefault(c => c.DeptId == department.DeptId);

            if (dep == null)
                return BadRequest();

            dep.DeptName = department.DeptName;
            dep.ManagerId = department.ManagerId;
            dep.LocationId = department.LocationId;

            _DeptDBContext.Departements.Update(dep);
            _DeptDBContext.SaveChanges();

            return Ok("Departement updated");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dep = _DeptDBContext.Departements
                        .FirstOrDefault(c => c.DeptId == id);

            if (dep == null)
                return BadRequest();

            _DeptDBContext.Departements.Remove(dep);
            _DeptDBContext.SaveChanges();

            return Ok("Departement deleted");
        }
    }
}
