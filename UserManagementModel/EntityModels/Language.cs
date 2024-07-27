using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementModel.EntityModels
{
    public class Language : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string LanguageName { get; set; }

        [Required]
        [StringLength(30)]
        public string LanguageCode { get; set; }
    }
}
