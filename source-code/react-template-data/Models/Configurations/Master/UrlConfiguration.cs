using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.Master;

namespace react_template_data.Models.Configurations.Master
{
    public class UrlConfiguration : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            #region Columns
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();
            builder.Property(u => u.Active)
                .HasDefaultValue(false)
                .IsRequired();
            builder.HasOne(u => u.Client)
                .WithMany(c => c.Urls)
                .IsRequired();
            builder.HasOne(u => u.Style)
                .WithMany(s => s.Urls)
                .IsRequired();

            builder.HasIndex(u => new { u.ClientId, u.StyleId, u.Path })
                .IsUnique();
            #endregion
        }
    }
}
