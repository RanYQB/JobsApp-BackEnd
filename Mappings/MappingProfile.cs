using AutoMapper;
using JobsApi.Dtos;
using JobsApi.Models;

namespace JobsApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserReadDto>();

            CreateMap<CompanyCreateDto, Company>();
            CreateMap<Company, CompanyReadDto>();

            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobReadDto>();

        }
    }
}
