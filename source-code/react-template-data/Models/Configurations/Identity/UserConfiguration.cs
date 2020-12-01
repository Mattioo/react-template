using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.IS;

namespace react_template_data.Models.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(o => o.Id).HasName("PK_AspNetUsers");
            var user = new User
            {
                Id = "495b44bd-5688-4fd7-acfa-2e72d85517ab",
                UserName = "mattioo@mailinator.com",
                NormalizedUserName = "mattioo@mailinator.com".ToUpper(),
                Email = "mattioo@mailinator.com",
                NormalizedEmail = "mattioo@mailinator.com".ToUpper(),
                EmailConfirmed = true
            };
            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, "P@ssw0rd");

            builder.HasData(user);
        }
    }
}
