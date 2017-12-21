

using CustomerCore.Models;

namespace CustomerStore.Mappers
{
    public class CustomerMapper
    {
        public static void Update(Customer customer, Customer fromCustomer)
        {
            customer.Name = fromCustomer.Name;
            customer.PhoneNo = fromCustomer.PhoneNo;
            customer.Email = fromCustomer.Email;
        }
    }
}
