using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.DAL.Models;

namespace Web.DAL.Configuration
{
    public class OrderProductContext
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProduct");

            builder.HasKey(bc => bc.OrderProductId);
            builder.HasOne(bc => bc.Order)
                .WithMany(b => b.OrderProducts)
                .HasForeignKey(bc => bc.OrderId);
            builder.HasOne(bc => bc.Product)
                .WithMany(c => c.OrderProducts)
                .HasForeignKey(bc => bc.ProductId);
        }
    }
}