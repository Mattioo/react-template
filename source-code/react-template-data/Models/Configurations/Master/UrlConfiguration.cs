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
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(c => c.Unit)
                .WithMany(c => c.Urls)
                .IsRequired();

            builder.Property(c => c.Active)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => new { c.UnitId, c.Path })
                .IsUnique();
            #endregion

            builder.HasData(
                new Url { Id = 1, Path = "localhost", Active = true, UnitId = 1 }
            );
        }
    }
}
