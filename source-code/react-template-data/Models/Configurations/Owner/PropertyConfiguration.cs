using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.Owner;

namespace react_template_data.Models.Configurations.Master
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            #region Columns
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(u => u.Name)
                .IsUnique();
            #endregion
        }
    }
}
