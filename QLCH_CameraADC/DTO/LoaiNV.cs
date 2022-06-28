using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiNV
    {
        public string MaLoaiNV { get; set; }
        public string TenLoaiNV { set; get; }
        public Boolean NhanVien { set; get; }
        public Boolean KhachHang { set; get; }
        public Boolean NhaCungCap { set; get; }
        public Boolean LoaiSP { set; get; }
        public Boolean SanPham { set; get; }
        public Boolean BanHang { set; get; }
        public Boolean NhapHang { set; get; }
        public Boolean HoaDonBan { set; get; }
        public Boolean HoaDonNhap { set; get; }
        public Boolean ThongKe { set; get; }
        public Boolean PhanQuyen { set; get; }
        public int TrangThai { get; set; }
    }
}
