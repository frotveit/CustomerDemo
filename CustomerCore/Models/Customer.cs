using System.ComponentModel.DataAnnotations;

namespace CustomerCore.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
