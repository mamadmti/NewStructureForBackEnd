using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Domain.Contracts.Services;
using MyProject.Domain.Entities;
using MyProject.Repositories;
using NewStructureForBackEnd.Domain.Contracts.Repositories;

namespace MyProject.Service
{

    public class AddressService : IAdressService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public AddressService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<Address> AddNew(Address item)
        {
            return await _repositoryFactory.Repository.Add(item);
        }
        public async Task<IEnumerable<Address>> GetALL(ISpecification<Address> spec = null)
        {
            return await _repositoryFactory.Repository.List(spec);
        }

        public async Task<Address> GetById(long id)
        {
            return await _repositoryFactory.Repository.GetById<Address>(id);
        }

        public async Task Remove(Address item)
        {
            await _repositoryFactory.Repository.Delete(item);
        }

        public async Task Update(Address item)
        {
            await _repositoryFactory.Repository.Update(item);
        }
    }
}

