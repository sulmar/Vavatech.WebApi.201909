using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WebApi.IRepositories;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.DbRepositories
{
    public class DbCustomerRepository : ICustomerRepository
    {
        private readonly MyContext context;

        public DbCustomerRepository(MyContext context)
        {
            this.context = context;
        }

        public void Add(Customer entity)
        {
            context.Customers.Add(entity);
            context.SaveChanges();
        }

        public Customer Authorize(string username, string password)
        {
            return context.Customers.SingleOrDefault(c => c.UserName == username && c.HashPassword == password);
        }

        public bool Exists(int id) => context.Customers.Any(c => c.Id == id);

        public Customer Get(int id) => context.Customers.Find(id);

        public IEnumerable<Customer> Get() => context.Customers.ToList();

        public void Remove(int id)
        {
            Customer customer = new Customer { Id = id };
            context.Entry(customer).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(Customer entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
