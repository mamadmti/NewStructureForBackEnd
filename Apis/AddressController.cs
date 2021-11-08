using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Domain.Contracts.Services;
using MyProject.Domain.Entities;
using MyProject.Domain.ViewModel;
using MyProject.Service;

namespace MyProject.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public AddressController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        private IAdressService AddressService { get; set; }
        
        [HttpGet("GetAddressById")]
        public async Task<Address> GetAddressById(long id)
        {
            AddressService = _serviceFactory.AddressService;
            return await AddressService.GetById(id);
        }


        [HttpPost("AddNewAddress")]
        public async Task<Address> AddNewAddress(AddressDto item)
        {
            AddressService = _serviceFactory.AddressService;
            var res = await AddressService.AddNew(new ()
            {
              UserId = Guid.Parse("e4246c59-4357-4c5e-a5a9-af4307c4f751"),
              City = item.City,
              Country = item.Country,
              CreateAt = DateTime.Now,
              CustomerId = item.CustomerId,
              Province = item.Province,
              RecordStatus = 0,
              Region = item.Region,
              Rest = item.Rest
            });
            var result = await _serviceFactory.SaveAsync();
            return res;
        }

        [HttpPut("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress(AddressDto item)
        {
            AddressService = _serviceFactory.AddressService;
            var address = await AddressService.GetById(item.Id ?? 0);
            address.CustomerId = item.CustomerId;
            address.Region = item.Region;
            address.City = item.City;
            address.Province = item.Province;
            address.Rest = item.Rest;
            await AddressService.Update(address);
            var result = await _serviceFactory.SaveAsync();
            return Ok("Operation is Successfull");

        }

        [HttpDelete("DeleteAddressById")]
        public async Task<IActionResult> DeleteAddressById(long id)
        {
            AddressService = _serviceFactory.AddressService;
            var address = await AddressService.GetById(id);
            await AddressService.Remove(address);
            var result = await _serviceFactory.SaveAsync();
            return Ok("Operation is succefull");
        }

    }
}
