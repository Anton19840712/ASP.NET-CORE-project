using System;
using System.Collections.Generic;
using Web.DAL.Enums;

namespace Web.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Categories Category { get; set; }
        public Genres Genre { get; set; }
        public Ratings RatingByAge { get; set; }
        public DateTime DateCreated { get; set; }
        public string Logo { get; set; }
        public string Background { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int TotalRating { get; set; }
        public ICollection<ProductRating> ProductRatings { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}