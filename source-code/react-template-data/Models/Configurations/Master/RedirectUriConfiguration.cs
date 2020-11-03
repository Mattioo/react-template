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
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Uri)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.DomainSystemId)
                .IsRequired();

            builder.Property(c => c.Active)
                .HasDefaultValue(true)
                .IsRequired();

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Uri)
                .IsUnique();
            #endregion

            builder.HasData(
                new RedirectUri { Id = 1, Uri = "https://localhost:44394", Active = true, DomainSystemId = 1 }
            );
        }
    }
}
