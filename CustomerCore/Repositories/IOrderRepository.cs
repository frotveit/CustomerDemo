using CustomerCore.Models;
using System.Collections.Generic;


namespace CustomerCore.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        Order GetOrderById(int id);
        RepositoryResponse AddOrder(Order order);
        RepositoryResponse UpdateOrder(Order order);
        RepositoryResponse DeleteOrder(Order order);
    }
}
