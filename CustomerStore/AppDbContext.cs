
using CustomerCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CustomerStore
{
    public interface IAppDbContext
    {
        int SaveChanges();

        void AddRange(IEnumerable<object> entities);
        void AddRange(params object[] entities);

        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Customer> Customers { get; set; }
    }

    public class AppDbContext: DbContext , IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }       

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>().HasKey(c => c.CustomerId);

            builder.Entity<Location>().HasKey(l => l.LocationId);

            builder.Entity<Order>().HasKey(o => o.OrderId);

            builder.Entity<OrderItem>().HasKey(o => o.OrderItemId);

            builder.Entity<Product>().HasKey(o => o.ProductId);
        }
    }
}
