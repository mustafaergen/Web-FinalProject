﻿// <auto-generated />
using System;
using FinalProject_Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalProject_WebApp.Migrations
{
    [DbContext(typeof(RepositoryContex))]
    [Migration("20250114222413_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FinalProject_Entities.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(3954),
                            Name = "Book",
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(3963),
                            Name = "Computer",
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(3964),
                            Name = "Phone",
                            Status = 0
                        });
                });

            modelBuilder.Entity("FinalProject_Entities.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("ShowCase")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4451),
                            ImageUrl = "default.png",
                            Name = "Istanbul",
                            Price = 35m,
                            ShowCase = true,
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4456),
                            ImageUrl = "default.png",
                            Name = "Fatih",
                            Price = 35m,
                            ShowCase = true,
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4457),
                            ImageUrl = "default.png",
                            Name = "Asus Pc",
                            Price = 35000m,
                            ShowCase = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4458),
                            ImageUrl = "default.png",
                            Name = "Lenovo Pc",
                            Price = 38000m,
                            ShowCase = true,
                            Status = 0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4460),
                            ImageUrl = "default.png",
                            Name = "Mac Book",
                            Price = 65000m,
                            ShowCase = true,
                            Status = 0
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4461),
                            ImageUrl = "default.png",
                            Name = "HP Pc",
                            Price = 65000m,
                            ShowCase = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4462),
                            ImageUrl = "default.png",
                            Name = "Roman",
                            Price = 45m,
                            ShowCase = true,
                            Status = 0
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4463),
                            ImageUrl = "default.png",
                            Name = "Iphone 16 Pro Max",
                            Price = 99000m,
                            ShowCase = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4464),
                            ImageUrl = "default.png",
                            Name = "Iphone 15 Pro Max",
                            Price = 85000m,
                            ShowCase = false,
                            Status = 0
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2025, 1, 15, 1, 24, 12, 830, DateTimeKind.Local).AddTicks(4466),
                            ImageUrl = "default.png",
                            Name = "Samsung",
                            Price = 65000m,
                            ShowCase = true,
                            Status = 0
                        });
                });

            modelBuilder.Entity("FinalProject_Entities.Models.Product", b =>
                {
                    b.HasOne("FinalProject_Entities.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FinalProject_Entities.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
