using JobsApi.Dtos;
using JobsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobsApi.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
           
            IEnumerable<JobReadDto> jobReadDtos = await _jobService.GetAllJobs();

            return Ok(jobReadDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddJob(JobCreateDto jobCreateDto)
        {
            JobReadDto job = await _jobService.RegisterNewJob(jobCreateDto);

            if (job == null)
            {
                throw new Exception("Error");
            }
            
            return Ok(job);
        }
    }
}