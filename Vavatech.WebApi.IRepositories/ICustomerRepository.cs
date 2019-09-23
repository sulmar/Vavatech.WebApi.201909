using System;
using System.Collections.Generic;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.IRepositories
{
    public interface ICustomerRepository
    {
        Customer Get(int id);
        IEnumerable<Customer> Get();
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(int id);
    }
}
