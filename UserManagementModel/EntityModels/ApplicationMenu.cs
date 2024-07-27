using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementModel.EntityModels
{
    /// <summary>
    /// This contains All menu and submenu
    /// also api parameter as object
    /// </summary>
    public class ApplicationMenu : BaseEntity
    {
        /// <summary>
        /// /get-role or /create-role 
        /// this route will save ApuUrl
        /// </summary>
        [StringLength(250)]
        public string ApiUrl { get; set; }

        /// <summary>
        /// GET,POST,PUT,PATCH,DELETE
        /// </summary>
        [StringLength(10)]
        public string MethodType { get; set; }

        [StringLength(15)]
        public string MenuTitle { get; set; }

        [StringLength(150)]
        public string ParameterObjectName { get; set; }

        /// <summary>
        /// This is name will display menu
        /// </summary>
        [StringLength(50)]
        public string MenuDisplayName { get; set; }

        /// <summary>
        /// Menu permission name when assign role
        /// like Can Access Role, Can Create Role, Can Update Role etc
        /// </summary>
        [StringLength(50)]
        public string MenuPermissionName { get; set; }

        /// <summary>
        /// Explain the menu roles & responsibilities
        /// this will show as tooltip when mouse hover
        /// on menu button
        /// </summary>
        [StringLength(150)]
        public string MenuDescription { get; set; }

        /// <summary>
        /// If Menu is root like User/Role/Settings
        /// </summary>
        public bool IsRootMenu { get; set; }

        /// <summary>
        /// Is this is submenu like UserList/RoleList/ etc
        /// </summary>
        public bool IsSubMenu { get; set; }

        /// <summary>
        /// Only enable menu will show 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Based on priority this menu 
        /// will display on sequence 
        /// </summary>
        public int Priority { get; set; }
    }
}
