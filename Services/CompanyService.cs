using AutoMapper;
using JobsApi.Data;
using JobsApi.Dtos;
using JobsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly DataContext _entityFramework;
        private readonly IMapper _mapper;

        public CompanyService(IConfiguration config, IMapper mapper)
        {
            _entityFramework = new DataContext(config);
            _mapper = mapper;
        }

        public async Task<CompanyReadDto> GetCompanyById(int Id)
        {
            Company? company = await _entityFramework.Companies
                .Where(c => c.CompanyId == Id)
                .FirstOrDefaultAsync<Company>();

            if(company == null)
            {
                throw new Exception("Entreprise introuvable");
            }

            CompanyReadDto companyReadDto = _mapper.Map<CompanyReadDto>(company);

            return companyReadDto;
        }

        public async Task<IEnumerable<CompanyReadDto>> GetAllCompanies()
        {
            IEnumerable<Company> companies = await _entityFramework.Companies.ToListAsync<Company>();

            IEnumerable<CompanyReadDto> companyReadDtos = _mapper.Map<IEnumerable<CompanyReadDto>>(companies);

            return companyReadDtos;
        }

        public async Task<CompanyReadDto> RegisterNewCompany(CompanyCreateDto companyCreateDto)
        {
            Company company = _mapper.Map<Company>(companyCreateDto);

            await _entityFramework.AddAsync(company);

            var result = await SaveCompanyChanges();

            if (result)
            {
                return _mapper.Map<CompanyReadDto>(company);
            }
            
            throw new Exception("Erreur lors de la création de l'entreprise");
        }
        public async Task<bool> SaveCompanyChanges()
        {
            return await _entityFramework.SaveChangesAsync() > 0;
        }
    }
}




    

       

      
     