using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement_IService;
using UserManagementModel.EntityModels;
using UserManagementModel.Parameters;

namespace UserManagementCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompanies();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            if (company == null)
            {
                return BadRequest();
            }

            var createdCompany = await _companyService.CreateCompany(company);
            return CreatedAtAction(nameof(GetCompanyById), new { id = createdCompany.Id }, createdCompany);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] Company company)
        {
            if (company == null || id != company.Id)
            {
                return BadRequest();
            }

            var updatedCompany = await _companyService.UpdateCompany(company);
            if (updatedCompany == null)
            {
                return NotFound();
            }
            return Ok(updatedCompany);
        }

        [HttpPut("change-status")]
        public async Task<IActionResult> ChangeCompanyStatus([FromBody] CanActive canActive)
        {
            if (canActive == null)
            {
                return BadRequest();
            }

            var company = await _companyService.ChangeCompanyStatus(canActive);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var success = await _companyService.DeleteCompany(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
