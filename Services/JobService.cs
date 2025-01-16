using AutoMapper;
using JobsApi.Data;
using JobsApi.Dtos;
using JobsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Services
{
    public class JobService : IJobService 
    {
        private readonly DataContext _entityFramework;
        private readonly IMapper _mapper;

        public JobService(IConfiguration config, IMapper mapper)
        {
            _entityFramework = new DataContext(config);
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobReadDto>> GetAllJobs()
        {
            IEnumerable<Job> jobs = await _entityFramework.Jobs
                .Include(j => j.Company)
                .ToListAsync<Job>();

            IEnumerable<JobReadDto> jobReadDtos = _mapper.Map<IEnumerable<JobReadDto>>(jobs);

            return jobReadDtos;
        }

        public async Task<JobReadDto> RegisterNewJob(JobCreateDto jobCreateDto)
        {
            Job job = _mapper.Map<Job>(jobCreateDto);

            await _entityFramework.AddAsync(job);

            var result = await SaveJobChanges();

            if (result)
            {
                return _mapper.Map<JobReadDto>(job);
            }
            
            throw new Exception("Erreur lors de la création de l'emploi");
        }
        public async Task<bool> SaveJobChanges()
        {
            return await _entityFramework.SaveChangesAsync() > 0;
        }
    }
}




    

       

      
     