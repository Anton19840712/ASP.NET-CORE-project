using System.ComponentModel.DataAnnotations.Schema;

namespace Web.DAL.Models
{
    public class ProductRating
    {
        public int ProductRatingId { get; set; }
        public int ProductId { get; set; }
        public string AppUserId { get; set; }
        public int Rating { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }
    }
}