

using System.ComponentModel.DataAnnotations;

namespace CustomerCore.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }
        //public Order Order { get; set; }

        public int ProductIdId { get; set; }
        public virtual Product Product { get; set; }

        public override string ToString()
        {
            return "OrderId: " + OrderId + " OrderItemId: " + OrderItemId;
        }
    }
}
