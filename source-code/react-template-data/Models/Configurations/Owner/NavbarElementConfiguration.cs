using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.Owner;

namespace react_template_data.Models.Configurations.Master
{
    public class NavbarElementConfiguration : IEntityTypeConfiguration<NavbarElement>
    {
        public void Configure(EntityTypeBuilder<NavbarElement> builder)
        {
            #region Columns
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Order)
                .IsRequired();
            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Title)
                .IsRequired();
            builder.Property(c => c.Url)
                .IsRequired()
                .HasDefaultValue('#');
            builder.Property(c => c.Content)
                .IsRequired();
            builder.Property(c => c.Anonymous)
                .IsRequired()
                .HasDefaultValue(true);
            builder.Property(c => c.Visible)
                .IsRequired()
                .HasDefaultValue(true);
            builder.Property(c => c.Active)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasIndex(u => u.Name)
                .IsUnique();
            #endregion

            builder.HasData(
                new NavbarElement { Id = 1, Order = 1, Name = "Home", Icon = "far fa-home", Content = "Strona główna", Title = "Przejdź do strony głównej", Url = "/" },
                new NavbarElement { Id = 2, Order = 2, Name = "About", Icon = "far fa-info-circle", Content = "Informacje", Title = "Przejdź do strony z informacjami", Url = "/info" },
                new NavbarElement { Id = 3, Order = 3, Name = "Contact", Icon = "far fa-address-card", Content = "Kontakt", Title = "Przejdź do strony z danymi teleadresowymi", Url = "/contact", Active = false }
            );
        }

    }
}
