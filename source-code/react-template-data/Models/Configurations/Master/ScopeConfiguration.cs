using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.Master;

namespace react_template_data.Models.Configurations.Master
{
    public class ScopeConfiguration : IEntityTypeConfiguration<Scope>
    {
        public void Configure(EntityTypeBuilder<Scope> builder)
        {
            #region Columns
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.DomainSystemId)
                .IsRequired();
            builder.Property(c => c.ApiScope)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(c => c.Active)
                .HasDefaultValue(true)
                .IsRequired();

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => new { c.Name, c.DomainSystemId, c.ApiScope })
                .IsUnique();
            #endregion

            builder.HasData(
                new Scope { Id = 1, Name = "openid", Active = true, DomainSystemId = 1 },
                new Scope { Id = 2, Name = "profile", Active = true, DomainSystemId = 1 },
                new Scope { Id = 3, Name = "custom", Active = true, DomainSystemId = 1 },
                new Scope { Id = 4, Name = "custom", Active = true, DomainSystemId = 1, ApiScope = true }
            );
        }
    }
}
