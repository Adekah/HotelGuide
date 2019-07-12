using System;
using HotelGuide.Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualBasic;

namespace HotelGuide.Entity.Model
{
    public partial class HotelDbContext : DbContext
    {
        public HotelDbContext()
        {
        }

        public HotelDbContext(DbContextOptions<HotelDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<HotelAddress> HotelAddress { get; set; }
        public virtual DbSet<HotelComment> HotelComment { get; set; }
        public virtual DbSet<HotelContact> HotelContact { get; set; }
        public virtual DbSet<HotelContactType> HotelContactType { get; set; }
        public virtual DbSet<HotelImage> HotelImage { get; set; }
        public virtual DbSet<HotelRoom> HotelRoom { get; set; }
        public virtual DbSet<HotelRoomPrice> HotelRoomPrice { get; set; }
        public virtual DbSet<HotelScore> HotelScore { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<HotelsViewModel> HotelsViewModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=ASUS;initial catalog=HotelDB;integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HotelAddress>(entity =>
            {
                entity.Property(e => e.AddressText)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LocationLatitude)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LocationLongtitude)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelAddress)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelAddress_Hotel");
            });

            modelBuilder.Entity<HotelComment>(entity =>
            {
                entity.Property(e => e.Comment)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelComment)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelComment_Hotel");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HotelComment)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_HotelComment_User");
            });

            modelBuilder.Entity<HotelContact>(entity =>
            {
                entity.Property(e => e.ContactValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.HotelContactType)
                    .WithMany(p => p.HotelContact)
                    .HasForeignKey(d => d.HotelContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HotelContact_HotelContactType");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelContact)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HotelContact_Hotel");
            });

            modelBuilder.Entity<HotelContactType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HotelImage>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelImage)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelImage_Hotel");
            });

            modelBuilder.Entity<HotelRoom>(entity =>
            {
                entity.Property(e => e.RoomDetail).IsUnicode(false);

                entity.Property(e => e.RoomSummary)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelRoom)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelRoom_Hotel");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.HotelRoom)
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK_HotelRoom_RoomType");
            });

            modelBuilder.Entity<HotelRoomPrice>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.HotelRoom)
                    .WithMany(p => p.HotelRoomPrice)
                    .HasForeignKey(d => d.HotelRoomId)
                    .HasConstraintName("FK_HotelRoomPrice_HotelRoom");
            });

            modelBuilder.Entity<HotelScore>(entity =>
            {
                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelScore)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelScore_Hotel");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
