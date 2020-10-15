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
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();
            builder.Property(s => s.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Active)
                .HasDefaultValue(true)
                .IsRequired();

            builder.HasIndex(s => s.Name)
                .IsUnique();
            #endregion

            builder.HasData(
                new GrantType { Id = 1, Name = "authorization_code", Active = true }
            );
        }
    }
}
