using UserManagement_IService;
using UserManagementInterface;
using UserManagementModel.EntityModels;
using UserManagementModel.Parameters;

namespace UserManagementService
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IQueryable<Company>> GetAllCompanies()
        {
            return await _companyRepository.GetAll();
        }

        public async Task<Company?> GetCompanyById(int id)
        {
            return await _companyRepository.GetCompanyById(id);
        }

        public async Task<Company> CreateCompany(Company company)
        {
            return await _companyRepository.Save(company);
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            return await _companyRepository.Update(company);
        }

        public async Task<Company?> ChangeCompanyStatus(CanActive canActive)
        {
            return await _companyRepository.CanActive(canActive);
        }

        public async Task<bool> DeleteCompany(int id)
        {
            var company = await _companyRepository.Delete(id);
            return company != null;
        }
    }
}
