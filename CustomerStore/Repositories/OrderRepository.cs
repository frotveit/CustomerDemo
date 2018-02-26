

using CustomerCore.Models;
using CustomerCore.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerStore.Repositories
{

    public class OrderRepository : IOrderRepository
    {
        private readonly IAppDbContext _appDbContext;

        public OrderRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Order> Orders
        {
            get
            {
                var orders = _appDbContext.Orders;
                foreach (var order in orders)
                {
                    order.OrderItems = _appDbContext.OrderItems.Where(item => item.OrderId == order.OrderId).ToList();
                    order.Customer = _appDbContext.Customers.FirstOrDefault(customer => customer.CustomerId == order.CustomerId);
                    order.Location = _appDbContext.Locations.FirstOrDefault(location => location.LocationId == order.LocationId);
                    //order.Location2 = _appDbContext.Locations.FirstOrDefault(l => l.LocationId == order.CustomerId);
                }
                return orders;
            }
        }

        public Order GetOrderById(int id)
        {
            var order = _appDbContext.Orders.FirstOrDefault(o => o.OrderId == id);

            if (order != null)
            {
                order.OrderItems = _appDbContext.OrderItems.Where(item => item.OrderId == order.OrderId);
                order.Customer = _appDbContext.Customers.FirstOrDefault(c => c.CustomerId == order.CustomerId);
                order.Location = _appDbContext.Locations.FirstOrDefault(l => l.LocationId == order.LocationId);
                //order.Location2 = _appDbContext.Locations.FirstOrDefault(l => l.LocationId == order.CustomerId);
            }
            return order;            
        }

        public RepositoryResponse AddOrder(Order order)
        {
            try
            {
                _appDbContext.OrderItems.AddRange(order.OrderItems);
                EntityEntry<Customer> customerResult = _appDbContext.Customers.Add(order.Customer);
                EntityEntry<Location> locationResult = _appDbContext.Locations.Add(order.Location);
                EntityEntry<Order> orderResult = _appDbContext.Orders.Add(order);

                int result = _appDbContext.SaveChanges();                
            }
            catch (Exception e) {
                return RepositoryResponse.Failed(e.Message);
            }
            return RepositoryResponse.Success();
        }

        public RepositoryResponse UpdateOrder(Order order) {
            var originalOrder = GetOrderById(order.OrderId);
            if (originalOrder == null)
            {
                return RepositoryResponse.Failed("Order do not exist: " + order);
            }
            originalOrder.OrderItems = order.OrderItems;
            originalOrder.ServiceDate = order.ServiceDate;
            originalOrder.Customer = order.Customer;
            originalOrder.Location = order.Location;

            _appDbContext.SaveChanges();

            return RepositoryResponse.Success();
        }

        public RepositoryResponse DeleteOrder(Order order)
        {
            var originalOrder = GetOrderById(order.OrderId);
            if (originalOrder == null)
            {
                return RepositoryResponse.Failed("Order do not exist: " + order);
            }

            try
            {
                _appDbContext.Orders.Remove(order);
                int count = _appDbContext.SaveChanges();
            }
            catch(Exception e)
            {
                return RepositoryResponse.Failed(e.Message);
            }
            return RepositoryResponse.Success();
        }
    }
}
