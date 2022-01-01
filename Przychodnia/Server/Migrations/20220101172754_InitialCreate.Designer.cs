﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Przychodnia.Server.Models;

#nullable disable

namespace Przychodnia.Server.Migrations
{
    [DbContext(typeof(AppDb))]
    [Migration("20220101172754_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Przychodnia.Shared.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleID = 2,
                            RoleName = "Doktor"
                        },
                        new
                        {
                            RoleID = 3,
                            RoleName = "Pacjent"
                        });
                });

            modelBuilder.Entity("Przychodnia.Shared.User", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 995213523765L,
                            Name = "Marcel",
                            PhotoPath = "Images/Marcel.png",
                            RoleID = 1,
                            Surname = "Kowal"
                        },
                        new
                        {
                            ID = 99768496534L,
                            Name = "Wiktoria",
                            PhotoPath = "Images/Wiktoria.png",
                            RoleID = 2,
                            Surname = "Tak"
                        },
                        new
                        {
                            ID = 99574836547L,
                            Name = "Cezary",
                            PhotoPath = "Images/Cezary.png",
                            RoleID = 3,
                            Surname = "Muza"
                        });
                });

            modelBuilder.Entity("Przychodnia.Shared.Visit", b =>
                {
                    b.Property<int>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VisitId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<bool>("Successful")
                        .HasColumnType("bit");

                    b.HasKey("VisitId");

                    b.ToTable("Visits");

                    b.HasData(
                        new
                        {
                            VisitId = 1,
                            Date = new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Badanie Rozwojowe",
                            Duration = 3,
                            Name = "Badanie",
                            Paid = true,
                            Successful = true
                        },
                        new
                        {
                            VisitId = 2,
                            Date = new DateTime(2022, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Badanie Rozwojowe1",
                            Duration = 4,
                            Name = "Badanie1",
                            Paid = true,
                            Successful = false
                        });
                });

            modelBuilder.Entity("Przychodnia.Shared.User", b =>
                {
                    b.HasOne("Przychodnia.Shared.Role", "RoleName")
                        .WithMany()
                        .HasForeignKey("RoleID");

                    b.Navigation("RoleName");
                });
#pragma warning restore 612, 618
        }
    }
}
