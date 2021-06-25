using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.DAL.Models;

namespace Web.DAL.Configuration
{
    public class OrderContext
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey("OrderId");
            builder.Property(s => s.OrderId).IsRequired();
            builder.HasOne(x => x.AppUser).WithMany(x => x.Orders);
        }
    }
}