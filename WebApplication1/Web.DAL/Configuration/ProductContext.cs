using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Web.DAL.Enums;
using Web.DAL.Models;

namespace Web.DAL.Configuration
{
    public class ProductContext : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");



            builder.Property(s => s.Name).IsRequired(false);
            builder.Property(s => s.Category).IsRequired();
            builder.Property(s => s.Genre).IsRequired();
            builder.Property(s => s.RatingByAge).IsRequired();
            builder.Property(s => s.DateCreated).IsRequired();
            builder.Property(s => s.Logo).IsRequired();
            builder.Property(s => s.Background).IsRequired();
            builder.Property(s => s.Price).IsRequired();
            builder.Property(s => s.Count).IsRequired();
            builder.Property(s => s.TotalRating).IsRequired();

            
            builder.HasIndex(s => s.Name);
            builder.HasIndex(s => s.Category);
            builder.HasIndex(s => s.Genre);
            builder.HasIndex(s => s.RatingByAge);
            builder.HasIndex(s => s.DateCreated);
            builder.HasIndex(s => s.Price);
            builder.HasIndex(s => s.Count);
            builder.HasIndex(s => s.TotalRating);
            builder.HasData(
                new Product() {Id = 1, Name = "Wii Sports", Category = Categories.Sports, Genre = Genres.Interactive, RatingByAge = Ratings.G, DateCreated = new DateTime(2020, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 16.6, Count = 2},
                new Product() {Id = 2, Name = "Wii Sports", Category = Categories.Sports, Genre = Genres.Interactive, RatingByAge = Ratings.G, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 17.6, Count = 2},
                new Product() {Id = 3, Name = "Wii Sports", Category = Categories.Sports, Genre = Genres.Interactive, RatingByAge = Ratings.G, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 18.6, Count = 2},
                new Product() {Id = 4, Name = "Wii Sports", Category = Categories.Sports, Genre = Genres.Interactive, RatingByAge = Ratings.G, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 19.6, Count = 2},
                new Product() {Id = 5, Name = "Wii Sports", Category = Categories.Sports, Genre = Genres.Interactive, RatingByAge = Ratings.G, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 16.9, Count = 2},
                new Product() {Id = 6, Name = "Wii Sports", Category = Categories.Sports, Genre = Genres.Interactive, RatingByAge = Ratings.G, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 16.8, Count = 2},
                new Product() {Id = 7, Name = "Wii Sports", Category = Categories.Sports, Genre = Genres.Interactive, RatingByAge = Ratings.G, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 16.7, Count = 2},
                new Product() {Id = 8, Name = "Wii Sports", Category = Categories.Sports, Genre = Genres.Interactive, RatingByAge = Ratings.G, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 14.6, Count = 2},
                new Product() {Id = 9, Name = "Wii Sports", Category = Categories.Sports, Genre = Genres.Interactive, RatingByAge = Ratings.G, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 13.5, Count = 2},
                new Product() {Id = 10, Name = "Wii Sports", Category = Categories.Sports,Genre = Genres.Interactive, RatingByAge = Ratings.G, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 12.4, Count = 2},
                new Product() {Id = 11, Name = "Wii Sports", Category = Categories.Sports,Genre = Genres.Interactive, RatingByAge = Ratings.G, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 11.3, Count = 2},
                new Product() {Id = 12, Name = "Wii Sports", Category = Categories.Sports,Genre = Genres.Interactive, RatingByAge = Ratings.G, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 10.2, Count = 2},
                new Product() {Id = 13, Name = "Wii Sports", Category = Categories.Sports,Genre = Genres.Interactive, RatingByAge = Ratings.G, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 9.1, Count = 2},
                new Product() {Id = 14, Name = "Wii Sports", Category = Categories.Sports,Genre = Genres.Interactive, RatingByAge = Ratings.Nc17, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 18.6, Count = 2},
                new Product() {Id = 15, Name = "Wii Sports", Category = Categories.Sports,Genre = Genres.Rhythm, RatingByAge = Ratings.G, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 76.6, Count = 2},
                new Product() {Id = 16, Name = "Wii Sports", Category = Categories.Sports,Genre = Genres.Interactive, RatingByAge = Ratings.G, DateCreated = new DateTime(2021, 7, 20), Logo = "logoAwsLink", Background = "backgroundAwsLink", Price = 96.6, Count = 2}
            );
        }
    }
}