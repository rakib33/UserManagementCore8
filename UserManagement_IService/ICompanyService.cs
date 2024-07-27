using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModel.EntityModels;
using UserManagementModel.Parameters;

namespace UserManagement_IService
{
    public interface ICompanyService
    {
        Task<IQueryable<Company>> GetAllCompanies();
        Task<Company?> GetCompanyById(int id);
        Task<Company> CreateCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task<Company?> ChangeCompanyStatus(CanActive canActive);
        Task<bool> DeleteCompany(int id);
    }
}
