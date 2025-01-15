using JobsApi.Data;
using JobsApi.Dtos;
using JobsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CompanyController : ControllerBase
    {
        DataContext _entityFramework;

        public CompanyController(IConfiguration config)
        {
            _entityFramework = new DataContext(config);
        }

        [HttpGet("companies")]
        public async Task<IActionResult> GetCompanies()
        {
            IEnumerable<Company> companies = await _entityFramework.Companies.ToListAsync<Company>();

            return Ok(companies);
        }

        [HttpGet("companies/{Id:int}")]
        public async Task<IActionResult> GetCompanies(int Id)
        {
            Company? company = await _entityFramework.Companies
                .Where(c => c.CompanyId == Id)
                .FirstOrDefaultAsync<Company>();

            if(company == null)
            {
                throw new Exception("Error");
            }

            return Ok(company);
        }

        [HttpPost("companies")]
        public async Task<IActionResult> AddCompany(CompanyCreateDto companyCreateDto)
        {
            Company company = new Company();

            company.Name = companyCreateDto.Name;

            await _entityFramework.AddAsync(company);

            if (await _entityFramework.SaveChangesAsync() > 0)
            {
                return Ok(company);
            }
            
            throw new Exception("Error");
        }
    }
}