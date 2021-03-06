﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using react_template_data.Data;

namespace react_template_data.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20210217203305_RemoveStyleTableFromMasterContext")]
    partial class RemoveStyleTableFromMasterContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("react_template_data.Data.Master.BackgroundJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastRun")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UnitId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.HasIndex("Name", "UnitId")
                        .IsUnique();

                    b.ToTable("BackgroundJobs");
                });

            modelBuilder.Entity("react_template_data.Data.Master.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Database")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LicenceNo")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LicenceSince")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 2, 17, 20, 33, 5, 386, DateTimeKind.Utc).AddTicks(3041));

                    b.Property<DateTime?>("LicenceTo")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("LicenceNo")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Database = "react-template-owner-dev",
                            LicenceNo = "default",
                            LicenceSince = new DateTime(2021, 2, 17, 20, 33, 5, 392, DateTimeKind.Utc).AddTicks(1603),
                            Name = "default"
                        });
                });

            modelBuilder.Entity("react_template_data.Data.Master.Url", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<int>("UnitId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UnitId", "Path")
                        .IsUnique();

                    b.ToTable("Urls");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Path = "localhost",
                            UnitId = 1
                        });
                });

            modelBuilder.Entity("react_template_data.Data.Master.BackgroundJob", b =>
                {
                    b.HasOne("react_template_data.Data.Master.Unit", "Unit")
                        .WithMany("BackgroundJobs")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("react_template_data.Data.Master.Url", b =>
                {
                    b.HasOne("react_template_data.Data.Master.Unit", "Unit")
                        .WithMany("Urls")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
