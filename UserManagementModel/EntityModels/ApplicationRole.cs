using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UserManagementModel.EntityModels
{
    public class ApplicationRole : IdentityRole
    {
        [StringLength(500)]
        public string Description { get; set; }
    }
}
