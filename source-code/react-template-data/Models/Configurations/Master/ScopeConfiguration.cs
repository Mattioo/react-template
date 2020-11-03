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
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();
            builder.Property(s => s.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Active)
                .HasDefaultValue(true)
                .IsRequired();
            builder.Property(c => c.DomainSystemId)
                .IsRequired();
            builder.Property(c => c.ApiScope)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasIndex(s => new { s.Name, s.DomainSystemId, s.ApiScope })
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
