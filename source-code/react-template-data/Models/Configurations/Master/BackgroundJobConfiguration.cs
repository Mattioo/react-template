using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.Master;

namespace react_template_data.Models.Configurations.Master
{
    public class BackgroundJobConfiguration : IEntityTypeConfiguration<BackgroundJob>
    {
        public void Configure(EntityTypeBuilder<BackgroundJob> builder)
        {
            #region Columns
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Active)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => new { c.Name, c.ClientId })
                .IsUnique();
            #endregion
        }
    }
}
