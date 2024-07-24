using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementModel.EntityModels
{
    /// <summary>
    /// Role permission contains companyId,RoleId and MenuId
    /// This indicate a company has a role and a role
    /// has multiple menue access permission
    /// Hear all model relation are flat
    /// </summary>
    public class RolePermission : Base<int>
    {
        /// <summary>
        /// Foreign Key of Role
        /// </summary>
        [Required]
        [StringLength(128)]
        public string RoleId { get; set; }

        [Required]
        [StringLength(150)]
        public string RoleName { get; set; }

        /// <summary>
        /// Foreign key of Company
        /// </summary>
        [Required]
        public int CompanyId { get; set; }

        /// <summary>
        /// Foreign key of ApplicationMenu
        /// </summary>
        [Required]
        public int ApplicationMenuId { get; set; }
    }
}
