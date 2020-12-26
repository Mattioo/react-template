using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using react_template_data.Data.Owner;

namespace react_template_data.Models.Configurations.Master
{
    public class PdfConfiguration : IEntityTypeConfiguration<Pdf>
    {
        public void Configure(EntityTypeBuilder<Pdf> builder)
        {
            #region Columns
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Title)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.Active)
                .HasDefaultValue(true)
                .IsRequired();
            builder.Property(c => c.Default)
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(c => c.Encoding)
                .HasDefaultValue("utf-8")
                .IsRequired();
            builder.Property(c => c.Orientation)
                .HasDefaultValue(1) /* Portrait */
                .IsRequired();
            builder.Property(c => c.Size)
                .HasDefaultValue(9) /* A4 */
                .IsRequired();
            builder.Property(c => c.Counter)
                .IsRequired();
            builder.Property(c => c.MarginUnit)
                .HasDefaultValue(1) /* Milimeters */
                .IsRequired();
            builder.Property(c => c.HeaderFontName)
               .IsRequired();
            builder.Property(c => c.HeaderFontSize)
                .IsRequired();
            builder.Property(c => c.HeaderLine)
                .IsRequired();
            builder.Property(c => c.FooterFontName)
                .IsRequired();
            builder.Property(c => c.FooterFontSize)
                .IsRequired();
            builder.Property(c => c.FooterLine)
                .IsRequired();
            #endregion

            builder.HasData(
                new Pdf
                {
                    Id = 1,
                    Title = "Wydruk",
                    Default = true,
                    Counter = true,
                    MarginTop = 10,
                    HeaderFontName = "Arial",
                    HeaderFontSize = 9,
                    HeaderRight = "Strona [page] z [toPage]",
                    HeaderLine = true,
                    FooterFontName = "Arial",
                    FooterFontSize = 9,
                    FooterCenter = "Mateusz Korolow 2020 ®",
                    FooterLine = true,
                }
            );
        }
    }
}
