using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLCH_CameraADC.DataAccess
{
    public partial class ADCDbConText : DbContext
    {
        public ADCDbConText()
            : base("name=ADCDbConText1")
        {
        }

        public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiNV> LoaiNVs { get; set; }
        public virtual DbSet<LoaiSP> LoaiSPs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<CTHD_Ban> CTHD_Ban { get; set; }
        public virtual DbSet<CTHD_Nhap> CTHD_Nhap { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDonBan>()
                .Property(e => e.MaHDB)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonBan>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonBan>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonBan>()
                .HasMany(e => e.CTHD_Ban)
                .WithRequired(e => e.HoaDonBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDonNhap>()
                .Property(e => e.MaHDN)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonNhap>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonNhap>()
                .HasMany(e => e.CTHD_Nhap)
                .WithRequired(e => e.HoaDonNhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDonBans)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiNV>()
                .Property(e => e.MaLoaiNV)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiNV>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.LoaiNV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiSP>()
                .Property(e => e.MaLoaiSP)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiSP>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.LoaiSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .HasMany(e => e.CTHD_Nhap)
                .WithRequired(e => e.NhaCungCap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaLoaiNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDonBans)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDonNhaps)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaLoaiSP)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.TenNSX)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CTHD_Ban)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CTHD_Nhap)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CTHD_Ban>()
                .Property(e => e.MaHDB)
                .IsUnicode(false);

            modelBuilder.Entity<CTHD_Ban>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<CTHD_Nhap>()
                .Property(e => e.MaHDN)
                .IsUnicode(false);

            modelBuilder.Entity<CTHD_Nhap>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<CTHD_Nhap>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);
        }
    }
}
