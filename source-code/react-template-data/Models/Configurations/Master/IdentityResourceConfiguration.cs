using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.Master;

namespace react_template_data.Models.Configurations.Master
{
    public class IdentityResourceConfiguration : IEntityTypeConfiguration<IdentityResource>
    {
        public void Configure(EntityTypeBuilder<IdentityResource> builder)
        {
            #region Columns
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Claim)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.DomainSystemId)
                .IsRequired();

            builder.Property(c => c.Active)
                .HasDefaultValue(true)
                .IsRequired();

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => new { c.Name, c.Claim })
                .IsUnique();
            #endregion

            builder.HasData(
                new IdentityResource { Id = 1, Active = true, DomainSystemId = 1, Name = "openid", Claim = "sub" },

                new IdentityResource { Id = 2, Active = true, DomainSystemId = 1, Name = "email", Claim = "email" },
                new IdentityResource { Id = 3, Active = true, DomainSystemId = 1, Name = "email", Claim = "email_verified" },

                new IdentityResource { Id = 4, Active = true, DomainSystemId = 1, Name = "profile", Claim = "name" },
                new IdentityResource { Id = 5, Active = true, DomainSystemId = 1, Name = "profile", Claim = "family_name" },
                new IdentityResource { Id = 6, Active = true, DomainSystemId = 1, Name = "profile", Claim = "given_name" },
                new IdentityResource { Id = 7, Active = true, DomainSystemId = 1, Name = "profile", Claim = "middle_name" },
                new IdentityResource { Id = 8, Active = true, DomainSystemId = 1, Name = "profile", Claim = "nickname" },
                new IdentityResource { Id = 9, Active = true, DomainSystemId = 1, Name = "profile", Claim = "preferred_username" },
                new IdentityResource { Id = 10, Active = true, DomainSystemId = 1, Name = "profile", Claim = "profile" },
                new IdentityResource { Id = 11, Active = true, DomainSystemId = 1, Name = "profile", Claim = "picture" },
                new IdentityResource { Id = 12, Active = true, DomainSystemId = 1, Name = "profile", Claim = "website" },
                new IdentityResource { Id = 13, Active = true, DomainSystemId = 1, Name = "profile", Claim = "gender" },
                new IdentityResource { Id = 14, Active = true, DomainSystemId = 1, Name = "profile", Claim = "birthdate" },
                new IdentityResource { Id = 15, Active = true, DomainSystemId = 1, Name = "profile", Claim = "zoneinfo" },
                new IdentityResource { Id = 16, Active = true, DomainSystemId = 1, Name = "profile", Claim = "locale" },
                new IdentityResource { Id = 17, Active = true, DomainSystemId = 1, Name = "profile", Claim = "updated_at" }
            );
        }
    }
}
