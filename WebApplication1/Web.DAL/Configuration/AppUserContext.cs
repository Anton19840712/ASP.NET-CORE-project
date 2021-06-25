using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.DAL.Models;

namespace Web.DAL.Configuration
{
    public class AppUserContext : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(x => x.Orders).WithOne(x => x.AppUser);

            builder.HasData(
                new AppUser() {LastName = "Jones"},
                new AppUser() {LastName = "Trump"},
                new AppUser() {LastName = "Obama"},
                new AppUser() {LastName = "Richter"},
                new AppUser() {LastName = "Suzuki"});
        }
    }
}