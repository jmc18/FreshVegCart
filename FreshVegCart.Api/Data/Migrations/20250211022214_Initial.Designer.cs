﻿// <auto-generated />
using System;
using FreshVegCart.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FreshVegCart.Api.Data.Migrations
{
    [DbContext(typeof(FreshVegCartDbContext))]
    [Migration("20250211022214_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FreshVegCart.Api.Data.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("Placed");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("FreshVegCart.Api.Data.Entities.OrderItem", b =>
                {
                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrderId", "ProductId");

                    b.ToTable("OrderItems", (string)null);
                });

            modelBuilder.Entity("FreshVegCart.Api.Data.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/avocado.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Avocado",
                            Price = 1.99m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 2L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/beet.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Beet",
                            Price = 0.99m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 3L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/bell_pepper.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Bell Pepper",
                            Price = 1.50m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 4L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/broccoli.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Broccoli",
                            Price = 2.00m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 5L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/cabbage.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Cabbage",
                            Price = 1.20m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 6L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/capsicum.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Capsicum",
                            Price = 1.80m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 7L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/carrot.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Carrot",
                            Price = 0.80m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 8L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/cauliflower.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Cauliflower",
                            Price = 2.50m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 9L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/coriander.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Coriander",
                            Price = 0.70m,
                            Unit = "bunch"
                        },
                        new
                        {
                            Id = 10L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/corn.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Corn",
                            Price = 1.00m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 11L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/cucumber.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Cucumber",
                            Price = 0.90m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 12L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/eggplant.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Eggplant",
                            Price = 1.75m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 13L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/farmer.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Farmer",
                            Price = 5.00m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 14L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/ginger.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Ginger",
                            Price = 2.20m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 15L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/green_beans.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Green Beans",
                            Price = 1.60m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 16L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/ladyfinger.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Ladyfinger",
                            Price = 1.10m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 17L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/lettuce.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Lettuce",
                            Price = 1.30m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 18L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/mushroom.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Mushroom",
                            Price = 2.80m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 19L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/onion.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Onion",
                            Price = 0.60m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 20L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/pea.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Pea",
                            Price = 1.40m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 21L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/potato.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Potato",
                            Price = 0.50m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 22L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/pumpkin.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Pumpkin",
                            Price = 3.00m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 23L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/radish.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Radish",
                            Price = 0.85m,
                            Unit = "bunch"
                        },
                        new
                        {
                            Id = 24L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/red_chili.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Red Chili",
                            Price = 1.50m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 25L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/spinach.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Spinach",
                            Price = 1.20m,
                            Unit = "bunch"
                        },
                        new
                        {
                            Id = 26L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/tomato.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Tomato",
                            Price = 0.95m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 27L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/turnip.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Turnip",
                            Price = 0.75m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 28L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/vegetables.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Vegetables",
                            Price = 4.00m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 29L,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/yellow_capsicum.png",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Yellow Capsicum",
                            Price = 1.80m,
                            Unit = "each"
                        });
                });

            modelBuilder.Entity("FreshVegCart.Api.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsLocked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("FreshVegCart.Api.Data.Entities.UserAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDefault")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserAddresses", (string)null);
                });

            modelBuilder.Entity("FreshVegCart.Api.Data.Entities.Order", b =>
                {
                    b.HasOne("FreshVegCart.Api.Data.Entities.UserAddress", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FreshVegCart.Api.Data.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FreshVegCart.Api.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("FreshVegCart.Api.Data.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FreshVegCart.Api.Data.Entities.UserAddress", b =>
                {
                    b.HasOne("FreshVegCart.Api.Data.Entities.User", "User")
                        .WithMany("UserAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FreshVegCart.Api.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("FreshVegCart.Api.Data.Entities.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserAddresses");
                });

            modelBuilder.Entity("FreshVegCart.Api.Data.Entities.UserAddress", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
