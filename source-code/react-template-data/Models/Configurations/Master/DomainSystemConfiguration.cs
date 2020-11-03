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
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Identifier)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Secret)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Active)
                .HasDefaultValue(true)
                .IsRequired();

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Identifier)
                .IsUnique();
            #endregion

            builder.HasData(
                new DomainSystem { Id = 1, Identifier = "react-template", Name = "Front office", Secret = "P@ssw0rd".ToSha256(), Active = true }
            );
        }
    }
}
