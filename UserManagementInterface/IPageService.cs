using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModel.EntityModels;

namespace UserManagementInterface
{
    public interface IPageService
    {
        Task<IQueryable<Page>> GetAll();
        Task<Page> GetPageById(int id);
        Task<Page> GetPageByCode(string code);
        Task<Page> Save(Page page);
        Task<Page> Update(Page page);
        Task<Page> Delete(int id);
    }
}
