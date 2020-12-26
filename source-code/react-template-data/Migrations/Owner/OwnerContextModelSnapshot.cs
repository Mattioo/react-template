﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using react_template_data.Data;

namespace react_template_data.Migrations.Owner
{
    [DbContext(typeof(OwnerContext))]
    partial class OwnerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("react_template_data.Data.Owner.Pdf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<bool>("Counter")
                        .HasColumnType("boolean");

                    b.Property<bool>("Default")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Encoding")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("utf-8");

                    b.Property<string>("FooterCenter")
                        .HasColumnType("text");

                    b.Property<string>("FooterFontName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("FooterFontSize")
                        .HasColumnType("smallint");

                    b.Property<string>("FooterLeft")
                        .HasColumnType("text");

                    b.Property<bool>("FooterLine")
                        .HasColumnType("boolean");

                    b.Property<string>("FooterRight")
                        .HasColumnType("text");

                    b.Property<double?>("FooterSpacing")
                        .HasColumnType("double precision");

                    b.Property<string>("FooterUrl")
                        .HasColumnType("text");

                    b.Property<string>("HeaderCenter")
                        .HasColumnType("text");

                    b.Property<string>("HeaderFontName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("HeaderFontSize")
                        .HasColumnType("smallint");

                    b.Property<string>("HeaderLeft")
                        .HasColumnType("text");

                    b.Property<bool>("HeaderLine")
                        .HasColumnType("boolean");

                    b.Property<string>("HeaderRight")
                        .HasColumnType("text");

                    b.Property<double?>("HeaderSpacing")
                        .HasColumnType("double precision");

                    b.Property<string>("HeaderUrl")
                        .HasColumnType("text");

                    b.Property<double?>("MarginBottom")
                        .HasColumnType("double precision");

                    b.Property<double?>("MarginLeft")
                        .HasColumnType("double precision");

                    b.Property<double?>("MarginRight")
                        .HasColumnType("double precision");

                    b.Property<double?>("MarginTop")
                        .HasColumnType("double precision");

                    b.Property<int>("MarginUnit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<int>("Orientation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<int>("Size")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(9);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Pdfs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = false,
                            Counter = true,
                            Default = true,
                            FooterCenter = "Mateusz Korolow 2020 ®",
                            FooterFontName = "Arial",
                            FooterFontSize = (short)9,
                            FooterLine = true,
                            HeaderFontName = "Arial",
                            HeaderFontSize = (short)9,
                            HeaderLine = true,
                            HeaderRight = "Strona [page] z [toPage]",
                            MarginTop = 10.0,
                            MarginUnit = 0,
                            Orientation = 0,
                            Size = 0,
                            Title = "Wydruk"
                        });
                });

            modelBuilder.Entity("react_template_data.Data.Owner.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("react_template_data.Data.Owner.Sms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("MaxNumberOfCharacters")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SmsConfigs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            MaxNumberOfCharacters = 160,
                            Name = "default",
                            Token = "6gz7z1VyApBBzBoG8L8bJ2LyEqnuFuU8iUmY93oa"
                        });
                });

            modelBuilder.Entity("react_template_data.Data.Owner.Smtp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Port")
                        .HasColumnType("integer");

                    b.Property<int>("SecureSocketOption")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SmtpConfigs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Host = "smtp.gmail.com",
                            Name = "default",
                            Password = "WpMF3NPW",
                            Port = 587,
                            SecureSocketOption = 1,
                            Username = "m.korolvv@gmail.com"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
