using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerCore.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime ServiceDate { get; set; }
                
        public IEnumerable<OrderItem> OrderItems { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
                           
        public int LocationId { get; set; }
        public Location Location { get; set; }

        //public int Location2Id { get; set; }
        //public Location Location2 { get; set; }

        public override string ToString()
        {
            return "OrderId " + OrderId;
        }

    }
}
