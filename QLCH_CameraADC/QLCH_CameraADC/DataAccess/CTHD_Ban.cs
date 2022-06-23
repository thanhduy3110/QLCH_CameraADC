namespace QLCH_CameraADC.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CTHD_Ban
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string MaHDB { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string MaSP { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SoLuong { get; set; }

        [Key]
        [Column(Order = 3)]
        public double GiaSP { get; set; }

        [Key]
        [Column(Order = 4)]
        public double ThanhTien { get; set; }

        public string KhuyenMai { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool TrangThai { get; set; }

        public virtual HoaDonBan HoaDonBan { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
