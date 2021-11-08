using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Domain.Entities;

namespace MyProject.Domain.Contracts.Services
{
    public interface IAdressService : IService<Address, long>
    {
    }
}
