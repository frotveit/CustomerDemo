using CustomerCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CustomerStore
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            IAppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!context.Products.Any())
            {
                context.AddRange
                (
                    new Product
                    {
                        ProductId = 1,
                        Name = "Moving",
                        Price = 800
                    }, 
                    new Product
                    {
                        ProductId = 2,
                        Name = "Packing",
                        Price = 400
                    }, 
                    new Product
                    {
                        ProductId = 3,
                        Name = "Cleaning",
                        Price = 300
                    }
                );
            }

            if (!context.Customers.Any())
            {
                context.AddRange
                (
                    new Customer
                    {
                        CustomerId = 1,
                        Name = "Ole",
                        PhoneNo = "444 00 999",
                        Email = "ole@me"
                    },
                    new Customer
                    {
                        CustomerId = 2,
                        Name = "Mari",
                        PhoneNo = "444 00 991",
                        Email = "mari@me"
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
