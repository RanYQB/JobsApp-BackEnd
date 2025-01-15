using AutoMapper;
using JobsApi.Data;
using JobsApi.Dtos;
using JobsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _entityFramework;

        public CompanyController(IConfiguration config, IMapper mapper)
        {
            _entityFramework = new DataContext(config);
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            IEnumerable<Company> companies = await _entityFramework.Companies.ToListAsync<Company>();

            IEnumerable<CompanyReadDto> companyReadDtos = _mapper.Map<IEnumerable<CompanyReadDto>>(companies);

            return Ok(companies);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetCompanies(int Id)
        {
            Company? company = await _entityFramework.Companies
                .Where(c => c.CompanyId == Id)
                .FirstOrDefaultAsync<Company>();

            if(company == null)
            {
                throw new Exception("Error");
            }

            CompanyReadDto companyReadDto = _mapper.Map<CompanyReadDto>(company);
            return Ok(companyReadDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyCreateDto companyCreateDto)
        {
            Company company = _mapper.Map<Company>(companyCreateDto);

            await _entityFramework.AddAsync(company);

            if (await _entityFramework.SaveChangesAsync() > 0)
            {
                return Ok(company);
            }
            
            throw new Exception("Error");
        }
    }
}