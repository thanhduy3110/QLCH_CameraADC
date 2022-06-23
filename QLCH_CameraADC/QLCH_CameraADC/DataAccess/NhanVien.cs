namespace QLCH_CameraADC.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            HoaDonBans = new HashSet<HoaDonBan>();
            HoaDonNhaps = new HashSet<HoaDonNhap>();
        }

        [Key]
        [StringLength(100)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(100)]
        public string MaLoaiNV { get; set; }

        [Required]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        public string SDT { get; set; }

        [Required]
        public string DiaChi { get; set; }

        public string Email { get; set; }

        public int CMND { get; set; }

        public bool GioiTinh { get; set; }

        public string HinhAnh { get; set; }

        [Required]
        public string MatKhau { get; set; }

        public bool TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; }

        public virtual LoaiNV LoaiNV { get; set; }
    }
}
