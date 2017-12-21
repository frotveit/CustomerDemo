
using CustomerCore.Models;
using CustomerCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CustomerDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }


        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _repository.Customers;
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public Customer Get(int id)
        {
            return _repository.Customers.FirstOrDefault(c => c.CustomerId == id);
        }
        
        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody]Customer value)
        {
        }
        
        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Customer value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteCustomer(id);
        }
    }
}
