using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementModel.EntityModels
{
    public class Page : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string PageName { get; set; }

        [Required]
        [StringLength(30)]
        public string PageCode { get; set; }

    }
}
