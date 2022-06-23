using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string MaLoaiNV { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public int CMND { get; set; }
        public int GioiTinh { get; set; }
        public string HinhAnh { get; set; }
        public string MatKhau { get; set; }
        public int TrangThai { get; set; }
    }
}
