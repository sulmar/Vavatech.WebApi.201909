using System;
using System.Diagnostics;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.IRepositories
{

    public interface ICustomerRepository : IEntityRepository<Customer>
    {

        Customer Authorize(string username, string password);
    }


}
