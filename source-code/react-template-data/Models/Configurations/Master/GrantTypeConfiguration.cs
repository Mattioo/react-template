using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.Master;

namespace react_template_data.Models.Configurations.Master
{
    public class GrantTypeConfiguration : IEntityTypeConfiguration<GrantType>
    {
        public void Configure(EntityTypeBuilder<GrantType> builder)
        {
            #region Columns
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.DomainSystemId)
                .IsRequired();

            builder.Property(c => c.Active)
                .HasDefaultValue(true)
                .IsRequired();

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Name)
                .IsUnique();
            #endregion

            builder.HasData(
                new GrantType { Id = 1, Name = "authorization_code", Active = true, DomainSystemId = 1 }
            );
        }
    }
}
