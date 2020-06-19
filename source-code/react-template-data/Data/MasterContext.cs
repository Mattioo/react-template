using Microsoft.EntityFrameworkCore;
using react_template_data.Data.Master;
using System;

namespace react_template_data.Data
{
    public class MasterContext : DbContext
    {
        public MasterContext(DbContextOptions<MasterContext> options) : base(options)
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Url> Urls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Clients
            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Client>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Client>()
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(c => c.Database)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(c => c.LicenceNo)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(c => c.LicenceSince)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(c => c.Active)
                .HasDefaultValue(false)
                .IsRequired();

            modelBuilder
                .Entity<Client>()
                .HasIndex(c => c.Name)
                .IsUnique();
            modelBuilder
                .Entity<Client>()
                .HasIndex(c => c.LicenceNo)
                .IsUnique();
            #endregion
            #region Styles
            modelBuilder.Entity<Style>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Style>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Style>()
                .Property(s => s.Dict)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Style>()
                .Property(s => s.File)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Style>()
                .Property(s => s.Default)
                .HasDefaultValue(false)
                .IsRequired();
            modelBuilder.Entity<Style>()
                .Property(s => s.Active)
                .HasDefaultValue(false)
                .IsRequired();

            modelBuilder
                .Entity<Style>()
                .HasIndex(s => new { s.Dict, s.File })
                .IsUnique();
            #endregion
            #region Urls
            modelBuilder.Entity<Url>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Url>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Url>()
                .Property(u => u.Active)
                .HasDefaultValue(false)
                .IsRequired();
            modelBuilder.Entity<Url>()
                .HasOne(u => u.Client)
                .WithMany(c => c.Urls)
                .IsRequired();
            modelBuilder.Entity<Url>()
                .HasOne(u => u.Style)
                .WithMany(s => s.Urls)
                .IsRequired();

            modelBuilder
                .Entity<Url>()
                .HasIndex(u => new { u.ClientId, u.StyleId, u.Path })
                .IsUnique();
            #endregion

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Name = "default", Database = "default", LicenceNo = "default", Active = true }
            );

            modelBuilder.Entity<Style>().HasData(
                new Style { Id = 1, Dict = "default", File = "styles.11030.css", Default = true, Active = true },
                new Style { Id = 2, Dict = "other", File = "styles.d46c3.css", Active = true }
            );

            modelBuilder.Entity<Url>().HasData(
                new Url { Id = 1, ClientId = 1, StyleId = 1, Active = true }
            );
        }
    }
}
