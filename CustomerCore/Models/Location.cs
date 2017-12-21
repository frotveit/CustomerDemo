
using System.ComponentModel.DataAnnotations;

namespace CustomerCore.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string Address { get; set; }
    }
}
