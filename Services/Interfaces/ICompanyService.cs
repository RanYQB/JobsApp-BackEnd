using JobsApi.Dtos;

namespace JobsApi.Services
{
    public interface ICompanyService
    {
        Task<CompanyReadDto> GetCompanyById(int Id);
        Task<IEnumerable<CompanyReadDto>> GetAllCompanies();
        Task<CompanyReadDto> RegisterNewCompany(CompanyCreateDto companyCreateDto);
        Task<bool> SaveCompanyChanges();
    }
}
