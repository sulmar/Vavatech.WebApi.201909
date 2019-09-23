using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vavatech.WebApi.FakeRepositories;
using Vavatech.WebApi.IRepositories;

namespace Vavatech.WebApi.Api.Controllers
{
    public class CustomersController : ApiController
    {
        private ICustomerRepository customerRepository;


        public CustomersController()
            : this(new FakeCustomerRepository())
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
    }
}