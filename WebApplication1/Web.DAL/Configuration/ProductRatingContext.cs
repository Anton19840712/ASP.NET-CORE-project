using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.DAL.Models;

namespace Web.DAL.Configuration
{
    public class ProductRatingContext : IEntityTypeConfiguration<ProductRating>
    {
        public void Configure(EntityTypeBuilder<ProductRating> builder)
        {
            builder.HasKey(pr => new { pr.ProductRatingId });
            builder.HasOne(pr => pr.Product)
                .WithMany(p => p.ProductRatings)
                .HasForeignKey(p => p.ProductId);
            builder.HasOne(pr => pr.AppUser)
                .WithMany(u => u.ProductRatings)
                .HasForeignKey(u => u.AppUserId);

            builder.ToTable("ProductRating");
            builder.Property(pr => pr.Rating).IsRequired().HasColumnName("Rating");
            
            builder.HasIndex(pr => pr.Rating);

        }
    }
}