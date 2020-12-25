using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.Owner;

namespace react_template_data.Models.Configurations.Master
{
    public class SmsConfigConfiguration : IEntityTypeConfiguration<SmsConfig>
    {
        public void Configure(EntityTypeBuilder<SmsConfig> builder)
        {
            #region Columns
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Active)
                .IsRequired();
            builder.Property(c => c.Token)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.MaxNumberOfCharacters)
                .IsRequired();

            builder.HasIndex(u => u.Name)
                .IsUnique();
            #endregion

            builder.HasData(
                new SmsConfig { Id = 1, Name = "default", Active = true, Token = "6gz7z1VyApBBzBoG8L8bJ2LyEqnuFuU8iUmY93oa", MaxNumberOfCharacters = 160 }
            );
        }
    }
}
