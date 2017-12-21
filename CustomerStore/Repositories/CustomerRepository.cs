using CustomerCore.Models;
using CustomerCore.Repositories;
using CustomerStore.Mappers;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerStore.Repositories
{

    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Customer> Customers
        {
            get
            {
                return _appDbContext.Customers;
            }
        }

        public Customer GetById(int id)
        {
            return _appDbContext.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public RepositoryResponse AddCustomer(Customer customer)
        {
            try
            {
                EntityEntry<Customer> customerResult =  _appDbContext.Customers.Add(customer);
                int result = _appDbContext.SaveChanges();
                if (result == 1)
                {
                    return RepositoryResponse.Success();
                }
            }
            catch (Exception e)
            {
                return RepositoryResponse.Failed(e.Message);
            }
            return RepositoryResponse.Failed("Add customer failed");
        }

        public RepositoryResponse UpdateCustomer(Customer customer)
        {
            var originalCustomer = GetById(customer.CustomerId);
            if (originalCustomer == null)
            {
                return RepositoryResponse.Failed("Customer do not exist: " + customer);
            }
            CustomerMapper.Update(originalCustomer, customer);
            _appDbContext.SaveChanges();

            return RepositoryResponse.Success();
        }

        public RepositoryResponse DeleteCustomer(Customer customer)
        {
            return DeleteCustomer(customer.CustomerId);
        }

        public RepositoryResponse DeleteCustomer(int id)
        {
            var customer = GetById(id);
            _appDbContext.Customers.Remove(customer);
            var count =_appDbContext.SaveChanges();

            if (count == 1)
                return RepositoryResponse.Success();

            return RepositoryResponse.Failed("Delete of customer " + id + " failed");
        }
    }
}
