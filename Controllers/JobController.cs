using JobsApi.Data;
using JobsApi.Dtos;
using JobsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class JobController : ControllerBase
    {
        DataContext _entityFramework;

        public JobController(IConfiguration config)
        {
            _entityFramework = new DataContext(config);
        }

        [HttpGet("jobs")]
        public async Task<IActionResult> GetJobs()
        {
            IEnumerable<Job> jobs = await _entityFramework.Jobs.ToListAsync<Job>();

            return Ok(jobs);
        }

        [HttpPost("jobs")]
        public async Task<IActionResult> AddJob(JobCreateDto jobCreateDto)
        {
            Job job = new Job();

            job.Title = jobCreateDto.Title;
            job.StartedOn = jobCreateDto.StartedOn;
            job.EndedOn = jobCreateDto.EndedOn;
            job.CompanyId = jobCreateDto.CompanyId;
            job.UserId = jobCreateDto.UserId;
            job.IsCurrent = job.IsCurrent;

            await _entityFramework.AddAsync(job);

            if (await _entityFramework.SaveChangesAsync() > 0)
            {
                return Ok(job);
            }
            
            throw new Exception("Error");
        }
    }
}