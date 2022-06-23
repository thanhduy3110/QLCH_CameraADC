namespace QLCH_CameraADC.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CTHD_Nhap
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string MaHDN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string MaSP { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string MaNCC { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SoLuong { get; set; }

        [Key]
        [Column(Order = 4)]
        public double GiaNhap { get; set; }

        [Key]
        [Column(Order = 5)]
        public double ThanhTien { get; set; }

        public string GhiChu { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool TrangThai { get; set; }

        public virtual HoaDonNhap HoaDonNhap { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
