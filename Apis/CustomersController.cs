using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Domain.Contracts.Services;
using MyProject.Domain.Entities;
using MyProject.Domain.Enums;
using MyProject.Domain.ViewModel;
using MyProject.Service;
using NewStructureForBackEnd.Specification;

namespace MyProject.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public CustomersController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        private ICustomerService CustomerService { get; set; }

        [HttpGet("GetCustomerById")]
        public async Task<Customer> GetCustomerById(long id)
        {
            CustomerService = _serviceFactory.CustomerService;
            return await CustomerService.GetById(id);
        }


        [HttpGet("GetCustomerByName")]
        public async Task<IEnumerable<Customer>> GetCustomerByName(string name) 
        {
            CustomerService = _serviceFactory.CustomerService;
            return await CustomerService.GetALL(new CustomerSpecification(name));
        }

        [HttpGet("GetCustomerByNationalCode")]
        public async Task<IEnumerable<Customer>> GetCustomerByNationalCode(string nationalCode)
        {
            CustomerService = _serviceFactory.CustomerService;
            return await CustomerService.GetALL(new CustomerSpecification(NationalCode:nationalCode));
        }
        [HttpPost("AddNewCustomer")]
        public async Task<Customer> AddNewCustomer(CustomerDto item)
        {
            CustomerService = _serviceFactory.CustomerService;
            var res = await CustomerService.AddNew(new Customer()
            {
                Name = item.Name,
                Family = item.Family,
                NationalCode = item.NationalCode,
                CreateAt = DateTime.Now,
                RecordStatus = RecordStatus.IsActive,
                UserId = Guid.Parse("e4246c59-4357-4c5e-a5a9-af4307c4f751")

            });
            var result=await _serviceFactory.SaveAsync();
            return res;
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustomerDto item)
        {
            CustomerService = _serviceFactory.CustomerService;
            var customer = await CustomerService.GetById(item.Id??0);
            customer.Name = item.Name == string.Empty ? customer.Name : item.Name;
            customer.Family = string.IsNullOrEmpty(item.Family) ? customer.Family : item.Family;
            customer.NationalCode =string.IsNullOrEmpty(item.NationalCode) ? customer.NationalCode : item.NationalCode;
            await CustomerService.Update(customer);
            var result = await _serviceFactory.SaveAsync();
            return Ok("Operation is succefull");

        }

        [HttpDelete("DeleteCustomerById")]
        public async Task<IActionResult> DeleteCustomerById(long id)
        {
            CustomerService = _serviceFactory.CustomerService;
            var customer = await CustomerService.GetById(id);
            await CustomerService.Remove(customer);
            var result = await _serviceFactory.SaveAsync();
            return Ok("Operation is succefull");
        }


    }
}
