using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.Master;

namespace react_template_data.Models.Configurations.Master
{
    public class RedirectUriConfiguration : IEntityTypeConfiguration<RedirectUri>
    {
        public void Configure(EntityTypeBuilder<RedirectUri> builder)
        {
            #region Columns
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();
            builder.Property(s => s.Uri)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.Active)
                .HasDefaultValue(true)
                .IsRequired();

            builder.HasIndex(s => s.Uri)
                .IsUnique();
            #endregion

            builder.HasData(
                new RedirectUri { Id = 1, Uri = "https://localhost:44394", Active = true }
            );
        }
    }
}
