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
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();
            builder.Property(s => s.Dict)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(s => s.File)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(s => s.Default)
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(s => s.Active)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasIndex(s => new { s.Dict, s.File })
                .IsUnique();
            #endregion

            builder.HasData(
                new Style { Id = 1, Dict = "default", File = "bundle.css", Default = true, Active = true }
            );
        }
    }
}
