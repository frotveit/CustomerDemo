using CustomerCore.Models;
using CustomerCore.Repositories;
using CustomerStore;
using CustomerStore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CustomerDemoTest
{
    [TestClass]
    public class CustomeRepositoryTest
    {
        public IAppDbContext dbcontext;

        public CustomeRepositoryTest()
        {
            if (dbcontext == null)
                dbcontext = InitDbContext();
        }

        public IAppDbContext InitDbContext()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("custRespTest");
            var context = new AppDbContext(builder.Options);

            if (context.Customers.Count() == 0)
            {
                var customers = Enumerable.Range(1, 10).Select(i => new Customer { CustomerId = i, Email = $"mail{i}@mail.com", PhoneNo = $"1234000{i}" });
                context.Customers.AddRange(customers);

                int changed = context.SaveChanges();
            }

            return context;
        }

        [TestMethod]
        public void GetById_ShouldGet()
        {
            ICustomerRepository repository = new CustomerRepository(dbcontext);

            var customer = repository.GetById(2);
            Assert.AreEqual(2, customer.CustomerId);
        }

        [TestMethod]
        public void GetById_ShouldReturnNullWhenNotThere()
        {
            ICustomerRepository repository = new CustomerRepository(dbcontext);

            var customer = repository.GetById(22);
            Assert.AreEqual(null, customer);
        }

        [TestMethod]
        public void AddCustomer_ShouldAdd()
        {
            ICustomerRepository repository = new CustomerRepository(dbcontext);

            var response = repository.AddCustomer(new Customer() { CustomerId = 19, Email = "somemail" });
            Assert.AreEqual(true, response.Succeeded);
        }

        [TestMethod]
        public void AddCustomer_ShouldNotAddExisting()
        {
            ICustomerRepository repository = new CustomerRepository(dbcontext);

            var response = repository.AddCustomer(new Customer() { CustomerId = 1, Email = "somemail@mail.com" });
            Assert.AreEqual(false, response.Succeeded);
        }
    }
}
