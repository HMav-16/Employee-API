using EmployeeWebApi.Data;
using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly ApplicationDBContext _jobDBContext;

        public JobsController(ApplicationDBContext jobDBContext)
        {
            _jobDBContext = jobDBContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jobDBContext.Jobs.ToList());
        }


        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_jobDBContext.Jobs.FirstOrDefault(c => c.JobId == id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] job job)
        {
            _jobDBContext.Jobs.Add(job);
            _jobDBContext.SaveChanges();

            return Ok("Job created");
        }


        [HttpPut]
        public IActionResult Put([FromBody] job job)
        {
            var jb = _jobDBContext.Jobs
                       .FirstOrDefault(c => c.JobId == job.JobId);

            if (jb == null)
                return BadRequest();

            jb.Title = job.Title;
            jb.MinSalairy = job.MinSalairy;
            jb.MaxSalairy = job.MaxSalairy;

            _jobDBContext.Jobs.Update(jb);
            _jobDBContext.SaveChanges();

            return Ok("Job updated");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var jb = _jobDBContext.Jobs
                      .FirstOrDefault(c => c.JobId == id);

            if (jb == null)
                return BadRequest();

            _jobDBContext.Jobs.Remove(jb);
            _jobDBContext.SaveChanges();

            return Ok("Job deleted");
        }
    }
}
