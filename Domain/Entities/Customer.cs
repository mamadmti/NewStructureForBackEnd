using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Domain.Entities
{
    public class Customer:BaseEntity
    {
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }

        public ICollection<Address> Addresses { get; set; }

    }
}
