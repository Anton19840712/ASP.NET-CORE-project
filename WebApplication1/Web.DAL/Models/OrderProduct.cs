using System.ComponentModel.DataAnnotations.Schema;

namespace Web.DAL.Models
{
    public class OrderProduct
    {
        public int OrderProductId { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int AmountOfProducts { get; set; }
    }
}