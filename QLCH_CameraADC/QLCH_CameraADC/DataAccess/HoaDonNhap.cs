namespace QLCH_CameraADC.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonNhap")]
    public partial class HoaDonNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonNhap()
        {
            CTHD_Nhap = new HashSet<CTHD_Nhap>();
        }

        [Key]
        [StringLength(100)]
        public string MaHDN { get; set; }

        [Required]
        [StringLength(100)]
        public string MaNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLap { get; set; }

        public double TongTien { get; set; }

        public bool TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD_Nhap> CTHD_Nhap { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
