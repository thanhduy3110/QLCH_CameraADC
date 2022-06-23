namespace QLCH_CameraADC.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonBan")]
    public partial class HoaDonBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonBan()
        {
            CTHD_Ban = new HashSet<CTHD_Ban>();
        }

        [Key]
        [StringLength(100)]
        public string MaHDB { get; set; }

        [Required]
        [StringLength(100)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(100)]
        public string MaKH { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLap { get; set; }

        public double TongTien { get; set; }

        public bool TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD_Ban> CTHD_Ban { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
