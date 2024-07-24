using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModel.EntityModels;

namespace UserManagementInterface
{
    public interface IPageContentService
    {
        Task<IQueryable<PageContentOnLanguage>> GetAll();
        Task<PageContentOnLanguage> GetPageContentById(int id);
        Task<IQueryable<PageContentOnLanguage>> GetPageContentByLanguageCode(string languageCode);
        Task<IQueryable<PageContentOnLanguage>> GetPageContentByLanguageId(int languageId);
        Task<IQueryable<PageContentOnLanguage>> GetPageContentByPageId(string pageId);
        Task<IQueryable<PageContentOnLanguage>> GetPageContentByPageCode(string pageCode);
        Task<IQueryable<PageContentOnLanguage>> GetPageContentByPropertyName(string propertyName);
        Task<IQueryable<PageContentOnLanguage>> GetPageContentByPropertyType(string propertyType);
        Task<PageContentOnLanguage> Save(PageContentOnLanguage pageContent);
        Task<PageContentOnLanguage> Update(PageContentOnLanguage pageContent);
        Task<PageContentOnLanguage> Delete(int id);
    }
}
