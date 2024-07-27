using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagementDbContext;
using UserManagementInterface;
using UserManagementModel.EntityModels;
using UserManagementModel.Parameters;

namespace UserManagementRepository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Company>> GetAll()
        {
            return await Task.FromResult(_context.companies.AsQueryable());
        }

        public async Task<Company?> GetCompanyById(int id)
        {
            return await _context.companies.FindAsync(id);
        }

        public async Task<Company> Save(Company company)
        {
            _context.companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> Update(Company company)
        {
            _context.companies.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }

        /// <summary>
        /// single property update only
        /// </summary>
        /// <param name="canActive"></param>
        /// <returns></returns>
        public async Task<Company?> CanActive(CanActive canActive)
        {
            var company = await _context.companies.FindAsync(canActive.Id);
            if (company != null)
            {
                company.IsActive = canActive.IsActive;
                await _context.SaveChangesAsync();
            }
            return company;
        }

        public async Task<Company?> Delete(int id)
        {
            var company = await _context.companies.FindAsync(id);
            if (company != null)
            {
                _context.companies.Remove(company);
                await _context.SaveChangesAsync();
            }
            return company;
        }
    }
}
