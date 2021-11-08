using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Entities;

namespace MyProject.Domain.Contexts
{
    public class CustomerContext:DbContext
    {
        //کانتکست یا همون لاجیک نرم افزار را ایجاد میکند
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
