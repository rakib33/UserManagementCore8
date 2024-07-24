using Microsoft.AspNetCore.Identity;

namespace UserManagementModel.EntityModels
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsActive { get; set; }
    }
}
