using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.Master;

namespace react_template_data.Models.Configurations.Master
{
    public class StyleConfiguration : IEntityTypeConfiguration<Style>
    {
        public void Configure(EntityTypeBuilder<Style> builder)
        {
            #region Columns
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Dict)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.File)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Default)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(c => c.Active)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => new { c.Dict, c.File })
                .IsUnique();
            #endregion

            builder.HasData(
                new Style { Id = 1, Dict = "default", File = "bundle.css", Default = true, Active = true }
            );
        }
    }
}
