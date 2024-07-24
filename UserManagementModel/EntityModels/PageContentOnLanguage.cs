using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementModel.EntityModels
{
    /// <summary>
    /// This table contains different language content 
    /// for multilingula option here
    /// </summary>
    public class PageContentOnLanguage : Base<int>
    {
        [Required]
        public int LanguageId { get; set; }

        [Required]
        [StringLength(30)]
        public string LanguageCode { get; set; }

        [Required]
        public int PageId { get; set; }

        [Required]
        [StringLength(30)]
        public string PageCode { get; set; }

        /// <summary>
        /// property like UserName,Password,SignIn,SignUp
        /// </summary>
        [Required]
        [StringLength(150)]
        public string PropertyName { get; set; }

        /// <summary>
        /// type will be label,textbox,
        /// textarea,placeholder,button,
        /// validation etc
        /// </summary>
        [StringLength(50)]
        [Required]
        public string PropertyType { get; set; }

        /// <summary>
        /// This content has different language content
        /// and will show on page
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// depends on priority Ui will display
        /// </summary>
        [Required]
        public int Priority { get; set; }
    }
}

