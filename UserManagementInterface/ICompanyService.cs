using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModel.EntityModels;
using UserManagementModel.Parameters;

namespace UserManagementInterface
{
    public interface ICompanyService
    {
        Task<IQueryable<Company>> GetAll();
        Task<Company> GetCompanyById(int id);
        Task<Company> Save(Company company);
        Task<Company> Update(Company company);

        /// <summary>
        /// This will be patch only update single field
        /// </summary>
        /// <param name="canActive"></param>
        /// <returns></returns>
        Task<Company> CanActive(CanActive canActive);
        Task<Company> Delete(int id);
    }
}
