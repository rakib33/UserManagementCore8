using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModel.EntityModels;
using UserManagementModel.Parameters;

namespace UserManagementInterface
{
    public interface IApplicationMenuService
    {
        Task<IQueryable<ApplicationMenu>> GetAll();
        Task<ApplicationMenu> GetApplicationMenuById(int id);
        Task<IQueryable<ApplicationMenu>> GetAllApplicationActiveMenu();
        Task<IQueryable<ApplicationMenu>> GetAllApplicationInActiveMenu();
        Task<ApplicationMenu> Save(ApplicationMenu applicationMenu);
        Task<ApplicationMenu> Update(ApplicationMenu applicationMenu);

        /// <summary>
        /// Active or InActive a menu 
        /// </summary>
        /// <param name="canActive"></param>
        /// <returns></returns>
        Task<ApplicationMenu> CanActiveMenu(CanActive canActive);
        Task<ApplicationMenu> Delete(int id);
    }
}
