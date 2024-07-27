using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModel.EntityModels;

namespace UserManagement_IService
{
    public interface ILanguageService
    {
        Task<IQueryable<Language>> GetAll();
        Task<Language> GetLanguageById(int id);
        Task<Language> GetLanguageByCode(string code);
        Task<Language> Save(Language language);
        Task<Language> Update(Language language);
        Task<Language> Delete(int id);
    }
}
