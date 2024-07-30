using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.EmailService.Models
{
    public class Attachment
    {
        public string Filename { get; set; }
        public Stream Data { get; set; }
        public string ContentType { get; set; }
    }
}
