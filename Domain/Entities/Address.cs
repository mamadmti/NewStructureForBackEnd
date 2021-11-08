using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Domain.Entities
{
    public class Address:BaseEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Region { get; set; }
        public string Rest { get; set; }

        public virtual Customer Customer { get; set; }
        public long CustomerId { get; set; }
        
    }
}
