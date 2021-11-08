using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Domain.Contracts.Services;
using MyProject.Repositories;

namespace MyProject.Service
{
    public interface IServiceFactory
    {
        public CustomerService CustomerService { get; }
        public AddressService AddressService { get; }
        Task<int> SaveAsync();
    }

    public class ServiceFactory:IServiceFactory,IDisposable
    {
        private readonly IRepositoryFactory _factory;
        public ServiceFactory(IRepositoryFactory repositoryFactory)
        {
            _factory = repositoryFactory;

        }


        private AddressService _addressService;
        public AddressService AddressService
        {
            get
            {
                this._addressService ??= new AddressService(_factory); //اگه نال بود جدید ایجاد کن در غیر اینصورت خودش رو بفرست
                return _addressService;
            }
        }



        private CustomerService _customerService;
        public CustomerService CustomerService
        {
            get
            {
                this._customerService ??= new CustomerService(_factory); //اگه نال بود جدید ایجاد کن در غیر اینصورت خودش رو بفرست
                return _customerService;
            }
        }

        #region SaveChange
        public async Task<int> SaveAsync()
        {
            return await _factory.SaveAsync();
        }
        #endregion

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    ((IDisposable)_factory).Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
    }
}
