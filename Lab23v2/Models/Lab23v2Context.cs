using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab23v2.Models
{
    public partial class Lab23v2Context : DbContext
    {
        public Lab23v2Context()
        {
        }

        public Lab23v2Context(DbContextOptions<Lab23v2Context> options): base(options)
        {
        }

        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Chocobo\\SQLEXPRESS;Database=Lab23v2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__Items__727E83EB3AE374E3");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemDesc).HasMaxLength(100);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CCAC26301223");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(30);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(30);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
            Seed(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>()
                .HasData((new Items[]
                {
                    new Items()
                    {
                        ItemId = 1,
                        ItemDesc = "Anodized Aluminum Case",
                        Quantity = 4,
                        Price = 88,
                    },
                     new Items()
                    {
                        ItemId = 2,
                        ItemDesc = "60% Printed Circut Board (PCB)",
                        Quantity = 1,
                        Price = 45,
                    },
                      new Items()
                    {
                        ItemId = 3,
                        ItemDesc = "75% Printed Circuit Board (PCB)",
                        Quantity = 3,
                        Price = 53,
                    },
                       new Items()
                    {
                        ItemId = 4,
                        ItemDesc = "Tactile Mechanical Switches",
                        Quantity = 300,
                        Price = 4
                       },
                        new Items()
                    {
                        ItemId = 5,
                        ItemDesc= "Linear Mechanical Switches",
                        Quantity = 0,
                        Price = 4
                    },
                         new Items()
                    {
                        ItemId = 6,
                        ItemDesc = "Clicky Mechanical Switches",
                        Quantity = 100,
                        Price = 4
                    },
                }));
        }
    }
}
