
using System.ComponentModel.DataAnnotations;

namespace CustomerCore.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }
    }
}
