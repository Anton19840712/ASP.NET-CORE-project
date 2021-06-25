using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Web.DAL.Enums;
using Web.DAL.Models;

namespace Web.Bussiness.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Categories Category { get; set; }
        public Genres Genre { get; set; }
        public Ratings RatingByAge { get; set; }
        public DateTime DateCreated { get; set; }
        public IFormFile Logo { get; set; }
        public IFormFile Background { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int TotalRating { get; set; }
        public ICollection<ProductRating> ProductRatings { get; set; }
    }
}
