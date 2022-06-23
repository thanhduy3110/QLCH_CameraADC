namespace QLCH_CameraADC.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            CTHD_Nhap = new HashSet<CTHD_Nhap>();
        }

        [Key]
        [StringLength(100)]
        public string MaNCC { get; set; }

        [Required]
        public string TenNCC { get; set; }

        [Required]
        public string DiaChi { get; set; }

        public string SDT { get; set; }

        public string Email { get; set; }

        public string GhiChu { get; set; }

        public bool TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD_Nhap> CTHD_Nhap { get; set; }
    }
}
