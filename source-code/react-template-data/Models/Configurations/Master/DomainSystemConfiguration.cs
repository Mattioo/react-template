using IdentityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.Master;

namespace react_template_data.Models.Configurations.Master
{
    public class DomainSystemConfiguration : IEntityTypeConfiguration<DomainSystem>
    {
        public void Configure(EntityTypeBuilder<DomainSystem> builder)
        {
            #region Columns
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();
            builder.Property(s => s.Identifier)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(s => s.Secret)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.Active)
                .HasDefaultValue(true)
                .IsRequired();

            builder.HasIndex(s => s.Identifier)
                .IsUnique();
            #endregion

            builder.HasData(
                new DomainSystem { Id = 1, Identifier = "react-template", Name = "Front office", Secret = "P@ssw0rd".ToSha256(), Active = true }
            );
        }
    }
}
