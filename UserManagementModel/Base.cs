using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementModel
{
    public class Base<T>
    {       
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public String CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public String UpdatedBy { get; set; }
    }
}
