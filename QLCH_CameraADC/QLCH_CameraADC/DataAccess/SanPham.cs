namespace QLCH_CameraADC.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CTHD_Ban = new HashSet<CTHD_Ban>();
            CTHD_Nhap = new HashSet<CTHD_Nhap>();
        }

        [Key]
        [StringLength(100)]
        public string MaSP { get; set; }

        [Required]
        [StringLength(100)]
        public string MaLoaiSP { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNSX { get; set; }

        [Required]
        public string TenSP { get; set; }

        public double Gia { get; set; }

        public int SL { get; set; }

        [Required]
        public string DVT { get; set; }

        public string MoTa { get; set; }

        public string KhuyenMai { get; set; }

        public string Hinh { get; set; }

        public bool TrangThai { get; set; }

        public virtual LoaiSP LoaiSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD_Ban> CTHD_Ban { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD_Nhap> CTHD_Nhap { get; set; }
    }
}
