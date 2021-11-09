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
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public CustomerService(IRepositoryFactory repositoryFactory )
        {
            _repositoryFactory = repositoryFactory;
        }
        public async Task<Customer> AddNew(Customer item)
        {
            return await _repositoryFactory.Repository.Add(item);
        }

        public async Task<IEnumerable<Customer>> GetALL(ISpecification<Customer> spec = null)
        {
            return await _repositoryFactory.Repository.List(spec);
        }

        public async Task<Customer> GetById(long id)
        {
            return await _repositoryFactory.Repository.GetById<Customer>(id);
        }

        public async Task Remove(Customer item)
        {
            await _repositoryFactory.Repository.Delete(item);
        }

        public async Task Update(Customer item)
        {
            await _repositoryFactory.Repository.Update(item);
        }

    }
}
