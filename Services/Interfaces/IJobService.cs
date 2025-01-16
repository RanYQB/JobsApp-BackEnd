using JobsApi.Dtos;

namespace JobsApi.Services
{
    public interface IJobService
    {
        Task<IEnumerable<JobReadDto>> GetAllJobs();
        Task<JobReadDto> RegisterNewJob(JobCreateDto jobCreateDto);
        Task<bool> SaveJobChanges();
    }
}
