using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using Vavatech.WebApi.Fakers;
using Vavatech.WebApi.IRepositories;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.FakeRepositories
{

    public class FakeCustomerRepository : ICustomerRepository
    {
        private ICollection<Customer> customers;
        private CustomerFaker customerFaker;

        public FakeCustomerRepository(CustomerFaker customerFaker)
        {
            this.customerFaker = customerFaker;

            customers = customerFaker.Generate(100);

            //customers = Enumerable.Empty<Customer>().ToList();

            //customers.Add(new Customer { Id = 1, FirstName = "Marcin", LastName = "Sulecki", Gender = Gender.Man });
            //customers.Add(new Customer { Id = 2, FirstName = "Bartek", LastName = "Sulecki", Gender = Gender.Man });
            //customers.Add(new Customer { Id = 3, FirstName = "Kasia", LastName = "Sulecka", Gender = Gender.Woman });
        }

        public IEnumerable<Customer> GetByCity(string city)
        {
            return customers.Where(c => c.FirstName == city);
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public Customer Get(int id)
        {
            // SQL
            // select * from customers where id = 100

            //foreach (var customer in customers)
            //{
            //    if (customer.Id == id)
            //    {
            //        return customer;
            //    }
            //}

            return customers.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        public void Remove(int id)
        {
            customers.Remove(Get(id));
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            // zla praktyka:
            // return customers.Where(c=>c.Id == id).Count()>0;


            // dobra praktyka:
            return customers.Where(c => c.Id == id).Any();

            return customers.Any(c => c.Id == id);

            // zla praktyka:
            // bool isAllWoman = customers.Where(c=>c.Gender == Gender.Woman).Count() = customers.Count()

            // dobra praktyka:
            bool isAllWoman = customers.All(c => c.Gender == Gender.Woman);
          
        }

        public Customer Authorize(string username, string password)
        {
            return customers.SingleOrDefault(c => c.UserName == username && c.HashPassword == password);
        }
    }
}
