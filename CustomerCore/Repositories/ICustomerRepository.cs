using CustomerCore.Models;
using System.Collections.Generic;

namespace CustomerCore.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }
        Customer GetById(int id);
        RepositoryResponse AddCustomer(Customer customer);
        RepositoryResponse UpdateCustomer(Customer customer);
        RepositoryResponse DeleteCustomer(int id);
        RepositoryResponse DeleteCustomer(Customer customer);
    }
}
