using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DineTime.Models
{
    public partial class DineTimeDbContext : DbContext
    {
        public DineTimeDbContext()
        {
        }

        public DineTimeDbContext(DbContextOptions<DineTimeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Restaurant> Restaurants { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DineTimeDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID").ValueGeneratedOnAdd();

                entity.Property(e => e.Category1)
                    .HasMaxLength(64)
                    .HasColumnName("Category");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).HasColumnName("ClientID").ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName).HasMaxLength(64);

                entity.Property(e => e.LastName).HasMaxLength(64);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.ReservationId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ReservationID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ReservationDate).HasColumnType("date");

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ClientID_FK");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RestaurantID_FK");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID").ValueGeneratedOnAdd();

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Name).HasMaxLength(64);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CategoryID_FK");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ReviewID");

                entity.Property(e => e.Comments).HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
