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
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.Active)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasIndex(c => c.Name)
                .IsUnique();
            builder.HasIndex(c => c.ClientId)
                .IsUnique();
            #endregion
        }
    }
}
