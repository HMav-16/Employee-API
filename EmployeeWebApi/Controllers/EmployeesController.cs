using EmployeeWebApi.Data;
using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDBContext _EmpDBContext;

        public EmployeesController(ApplicationDBContext EmpDBContext)
        {
            _EmpDBContext = EmpDBContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_EmpDBContext.Employees.ToList());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_EmpDBContext.Employees.FirstOrDefault(c => c.EmpId == id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] employee employee)
        {
            _EmpDBContext.Employees.Add(employee);
            _EmpDBContext.SaveChanges();

            return Ok("Employee created");
        }


        [HttpPut]
        public IActionResult Put([FromBody] employee employee)
        {
            var emp = _EmpDBContext.Employees.FirstOrDefault(c => c.EmpId == employee.EmpId);

            if (emp == null)
                return BadRequest();

            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Email = employee.Email;
            emp.ComissionPCT = employee.ComissionPCT;
            emp.DepartementId = employee.DepartementId;
            emp.PhoneNumber = employee.PhoneNumber;
            emp.Salary = employee.Salary;
            emp.ManagerId = employee.ManagerId;
            emp.HireDate = employee.HireDate;
            emp.JobId = employee.JobId;

            _EmpDBContext.Employees.Update(emp);
            _EmpDBContext.SaveChanges();

            return Ok("Employee updated");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _EmpDBContext.Employees.FirstOrDefault(c => c.EmpId == id);

            if (emp == null)
                return BadRequest();

            _EmpDBContext.Employees.Remove(emp);
            _EmpDBContext.SaveChanges();

            return Ok("Employee deleted");
        }
    }
}


