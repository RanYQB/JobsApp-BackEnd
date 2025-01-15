using AutoMapper;
using JobsApi.Data;
using JobsApi.Dtos;
using JobsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _entityFramework;

        public JobController(IConfiguration config, IMapper mapper)
        {
            _entityFramework = new DataContext(config);
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
           
            IEnumerable<Job> jobs = await _entityFramework.Jobs.ToListAsync<Job>();
            IEnumerable<JobReadDto> jobReadDtos = _mapper.Map<IEnumerable<JobReadDto>>(jobs);

            return Ok(jobReadDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddJob(JobCreateDto jobCreateDto)
        {
            Job job = _mapper.Map<Job>(jobCreateDto);

            await _entityFramework.AddAsync(job);

            if (await _entityFramework.SaveChangesAsync() > 0)
            {
                return Ok(job);
            }
            
            throw new Exception("Error");
        }
    }
}