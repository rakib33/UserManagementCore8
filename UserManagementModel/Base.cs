using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementModel
{
    public class BaseEntity<T>
    {       
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public String CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public String UpdatedBy { get; set; }

    }

    //donot add properties/fields/methods to this class. Do that in the above class.
    public class BaseEntity : BaseEntity<int> { }

}
