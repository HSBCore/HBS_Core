using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BOL.Data
{
    public partial class HBS_DBContext : DbContext
    {
        public HBS_DBContext()
        {
        }

        public HBS_DBContext(DbContextOptions<HBS_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Gust> Gusts { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomClass> RoomClasses { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HBS_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("bookingDate");

                entity.Property(e => e.CheckIn)
                    .HasColumnType("date")
                    .HasColumnName("check_in");

                entity.Property(e => e.CheckOut)
                    .HasColumnType("date")
                    .HasColumnName("check_out");

                entity.Property(e => e.DateRange).HasColumnName("date_range");

                entity.Property(e => e.GustId).HasColumnName("GustID");

                entity.Property(e => e.RoomId).HasColumnName("roomID");

                entity.Property(e => e.StaffId).HasColumnName("staffID");

                entity.HasOne(d => d.Gust)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.GustId)
                    .HasConstraintName("FK_Booking_Gusts");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Booking_Rooms");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_Booking_Staff");
            });

            modelBuilder.Entity<Gust>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descrption).HasColumnName("descrption");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.RoomClassId).HasColumnName("RoomClassID");

                entity.HasOne(d => d.RoomClass)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomClassId)
                    .HasConstraintName("FK_Rooms_RoomClass");
            });

            modelBuilder.Entity<RoomClass>(entity =>
            {
                entity.ToTable("RoomClass");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(50)
                    .HasColumnName("job_title");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
