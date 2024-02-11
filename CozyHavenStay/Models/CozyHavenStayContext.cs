using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CozyHavenStay.Models
{
    public partial class CozyHavenStayContext : DbContext
    {
        public CozyHavenStayContext()
        {
        }

        public CozyHavenStayContext(DbContextOptions<CozyHavenStayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<HotelImage> HotelImages { get; set; } = null!;
        public virtual DbSet<HotelOwner> HotelOwners { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Refund> Refunds { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomImage> RoomImages { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DEEPRAJ;database=CozyHavenStay;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(255);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                entity.Property(e => e.CheckOutDate).HasColumnType("datetime");

                entity.Property(e => e.RefundAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.TotalFare).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Booking__RoomID__4D94879B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Booking__UserID__4CA06362");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Hotel__OwnerID__403A8C7D");
            });

            modelBuilder.Entity<HotelImage>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK__HotelIma__7516F4EC71E149F8");

                entity.ToTable("HotelImage");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .HasColumnName("ImageURL");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelImages)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__HotelImag__Hotel__4316F928");
            });

            modelBuilder.Entity<HotelOwner>(entity =>
            {
                entity.HasKey(e => e.OwnerId)
                    .HasName("PK__HotelOwn__81938598FF5F2D79");

                entity.ToTable("HotelOwner");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Owner')");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(255);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.Action).HasMaxLength(100);

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Log__UserID__59063A47");
            });

            modelBuilder.Entity<Refund>(entity =>
            {
                entity.ToTable("Refund");

                entity.Property(e => e.RefundId).HasColumnName("RefundID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.RefundAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RefundDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RefundStatus)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('In Progress')");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Refunds)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Refund__BookingI__5441852A");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Review__HotelID__5165187F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Review__UserID__5070F446");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.Acstatus)
                    .HasMaxLength(3)
                    .HasColumnName("ACStatus");

                entity.Property(e => e.BaseFare).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BedType).HasMaxLength(50);

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.RoomSize).HasMaxLength(50);

                entity.Property(e => e.RoomType).HasMaxLength(50);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Room__HotelID__45F365D3");
            });

            modelBuilder.Entity<RoomImage>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK__RoomImag__7516F4EC388147E8");

                entity.ToTable("RoomImage");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomImages)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__RoomImage__RoomI__49C3F6B7");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Guest')");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.ContactNumber).HasMaxLength(20);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.ProfileImage).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
