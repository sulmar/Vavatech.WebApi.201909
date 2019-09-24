using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vavatech.WebApi.FakeRepositories;
using Vavatech.WebApi.IRepositories;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.Api.Controllers
{
    public class CustomersController : ApiController
    {
        private ICustomerRepository customerRepository;


        public CustomersController()
            : this(new FakeCustomerRepository(new Fakers.CustomerFaker()))
        {
        }

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        // api/customers
        public IHttpActionResult Get()
        {
            var customers = customerRepository.Get();

            return Ok(customers);
        }

        // api/customers/10

        public IHttpActionResult Get(int id)
        {
            // typ anonimowy
            var person = new { Imie = "Marcin", Nazwisko = "Sulecki" };

            var customer = customerRepository.Get(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }


        public IHttpActionResult Post(Customer customer)
        {
            customerRepository.Add(customer);

            // return Created($"https://localhost:44375/api/customers/{customer.Id}", customer);

            return CreatedAtRoute("DefaultApi", new { customer.Id }, customer);
        }

        // PUT /api/customers/100
        public IHttpActionResult Put(int id, Customer customer)
        {
            if (customer.Id != id)
                return BadRequest();

            customerRepository.Update(customer);

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {

            if (!customerRepository.Exists(id))
                return NotFound();

            customerRepository.Remove(id);

            return Ok();
        }
    }
}