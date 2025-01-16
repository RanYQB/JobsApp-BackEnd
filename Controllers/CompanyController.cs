using AutoMapper;
using JobsApi.Data;
using JobsApi.Dtos;
using JobsApi.Models;
using JobsApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            IEnumerable<CompanyReadDto> companyReadDtos = await _companyService.GetAllCompanies();

            return Ok(companyReadDtos);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetCompanies(int Id)
        {
            CompanyReadDto? companyReadDto = await _companyService.GetCompanyById(Id);

            if(companyReadDto == null)
            {
                throw new Exception("Entreprise introuvable");
            }

            return Ok(companyReadDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyCreateDto companyCreateDto)
        {
            CompanyReadDto company = await _companyService.RegisterNewCompany(companyCreateDto);

            if (company == null)
            {
                throw new Exception("Error");
            }
            
            return Ok(company);
        }
    }
}