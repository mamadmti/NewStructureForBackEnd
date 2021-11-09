using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Domain.Entities;
using NewStructureForBackEnd.Repositories;

namespace NewStructureForBackEnd.Specification
{
    public class CustomerSpecification:BaseSpecification<Customer>
    {
        public CustomerSpecification(string name = null, string NationalCode = null)
        {
            if (name != null && NationalCode == null)
            {
                Criteria = i => i.Name == name;

            }
            else if (name == null && NationalCode != null)
            {
                Criteria = i => i.NationalCode == NationalCode;

            }
            else if (name != null && NationalCode != null)
            {
                Criteria = i => i.NationalCode == NationalCode && i.Name == name;

            }


        }
    }

        //public CustomerSpecification(string NationalCode)
        //{
        //    Criteria = i => i.NationalCode == NationalCode;
        //}
    }
}
