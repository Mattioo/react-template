using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.Master;
using System;

namespace react_template_data.Models.Configurations.Master
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            #region Columns
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Database)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.LicenceNo)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.LicenceSince)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();

            builder.Property(c => c.Active)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Name)
                .IsUnique();
            builder.HasIndex(c => c.LicenceNo)
                .IsUnique();
            #endregion

            builder.HasData(
                new Client { Id = 1, Name = "default", Database = "react-template-owner-dev", LicenceNo = "default", LicenceSince = DateTime.UtcNow, Active = true }
            );
        }
    }
}
