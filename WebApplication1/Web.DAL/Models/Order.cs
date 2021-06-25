using System.Collections.Generic;

namespace Web.DAL.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int? OrderNumber { get; set; }
        public AppUser AppUser { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}