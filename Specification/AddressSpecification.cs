using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Domain.Entities;
using NewStructureForBackEnd.Repositories;

namespace NewStructureForBackEnd.Specification
{
    public class AddressSpecification:BaseSpecification<Address>
    {
        public AddressSpecification(string city = null)
        {
            Criteria = i => i.City == city;
        }
    }

        //public CustomerSpecification(string NationalCode)
        //{
        //    Criteria = i => i.NationalCode == NationalCode;
        //}
    //}
}
