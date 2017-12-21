using CustomerCore.Models;
using CustomerStore.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerDemoTest
{
    [TestClass]
    public class CustomerMapperUnitTest
    {
        [TestMethod]
        public void TestUpdate()
        {
            var customer = new Customer { CustomerId = 1, Name = "oldname", Email = "oldmail", PhoneNo = "0011" };

            CustomerMapper.Update(customer,
                new Customer { CustomerId = 2, Name = "newname", Email = "newmail", PhoneNo = "1111" });

            Assert.AreEqual(1, customer.CustomerId, "Id should not change");
            Assert.AreEqual("newname", customer.Name);
            Assert.AreEqual("newmail", customer.Email);
            Assert.AreEqual("1111", customer.PhoneNo);
        }
    }
}
