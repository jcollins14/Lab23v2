﻿// <auto-generated />
using System;
using Lab23v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab23v2.Migrations
{
    [DbContext(typeof(Lab23v2Context))]
    partial class Lab23v2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab23v2.Models.Items", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ItemID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemDesc")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ItemId")
                        .HasName("PK__Items__727E83EB3AE374E3");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            ItemDesc = "Anodized Aluminum Case",
                            Price = 88,
                            Quantity = 4
                        },
                        new
                        {
                            ItemId = 2,
                            ItemDesc = "60% Printed Circut Board (PCB)",
                            Price = 45,
                            Quantity = 1
                        },
                        new
                        {
                            ItemId = 3,
                            ItemDesc = "75% Printed Circuit Board (PCB)",
                            Price = 53,
                            Quantity = 3
                        },
                        new
                        {
                            ItemId = 4,
                            ItemDesc = "Tactile Mechanical Switches",
                            Price = 4,
                            Quantity = 300
                        },
                        new
                        {
                            ItemId = 5,
                            ItemDesc = "Linear Mechanical Switches",
                            Price = 4,
                            Quantity = 0
                        },
                        new
                        {
                            ItemId = 6,
                            ItemDesc = "Clicky Mechanical Switches",
                            Price = 4,
                            Quantity = 100
                        });
                });

            modelBuilder.Entity("Lab23v2.Models.UserItems", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("UserItems");
                });

            modelBuilder.Entity("Lab23v2.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)")
                        .HasMaxLength(75);

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnName("FName")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnName("LName")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int?>("Wallet")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("UserId")
                        .HasName("PK__Users__1788CCAC26301223");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
