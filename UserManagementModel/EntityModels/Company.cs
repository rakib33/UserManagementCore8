using System.ComponentModel.DataAnnotations;

namespace UserManagementModel.EntityModels
{
    /// <summary>
    /// This is company information
    /// </summary>
    public class Company : Base<int>
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// company short name 
        /// </summary>
        [Required]
        [StringLength(20)]
        public string ShortName { get; set; }

        [Required]
        [Phone]
        [StringLength(16)]
        public string Phone_01 { get; set; }

        [Phone]
        [StringLength(16)]
        public string Phone_02 { get; set; }

        [Required]
        [StringLength(150)]
        public string Address_01 { get; set; }

        [StringLength(150)]
        public string Address_02 { get; set; }

        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public byte[] Logo { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(500)]
        public string LicenseKey { get; set; }

    }
}
