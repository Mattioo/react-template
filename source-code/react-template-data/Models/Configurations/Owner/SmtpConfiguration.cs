using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.Owner;

namespace react_template_data.Models.Configurations.Master
{
    public class SmtpConfiguration : IEntityTypeConfiguration<Smtp>
    {
        public void Configure(EntityTypeBuilder<Smtp> builder)
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
            builder.Property(c => c.Host)
                .IsRequired();
            builder.Property(c => c.Port)
                .IsRequired();
            builder.Property(c => c.Username)
                .IsRequired();
            builder.Property(c => c.Password)
                .IsRequired();
            builder.Property(c => c.SecureSocketOption)
                .IsRequired();

            builder.HasIndex(u => u.Name)
                .IsUnique();
            #endregion

            builder.HasData(
                new Smtp { Id = 1, Name = "default", Active = true, Host = "smtp.gmail.com", Port = 587, Username = "m.korolvv@gmail.com", Password = "WpMF3NPW", SecureSocketOption = 1 }
            );
        }
    }
}
