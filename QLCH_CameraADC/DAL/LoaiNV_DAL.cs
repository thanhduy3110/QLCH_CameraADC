using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class LoaiNV_DAL
    {
        KetNoiDatabase KetNoi = new KetNoiDatabase();

        public DataTable GetData(string Condition)
        {
            return KetNoi.GetDataTable("select * from LoaiNV" + Condition);
        }

        public DataTable GetTong()
        {
            return KetNoi.GetDataTable(" select * from LoaiNV");
        }
        public void AddChucVu(LoaiNV ex)
        {
            KetNoi.ExecuteReader(@"Insert into LoaiNV Values('" + ex.MaLoaiNV + "',N'" + ex.TenLoaiNV + "','" + ex.NhanVien + "','" + ex.KhachHang + "','" + ex.SanPham + "','" + ex.BanHang + "','" + ex.NhaCungCap + "','" + ex.LoaiSP + "','" + ex.NhapHang + "','" + ex.HoaDonNhap + "','" + ex.PhanQuyen + "','" + ex.ThongKe + "','" + ex.HoaDonBan +  "', " + ex.TrangThai + ")");
        }

        public void EditChuCVu(LoaiNV ex)
        {
            KetNoi.ExecuteReader(@"update LoaiNV Set TenLoaiNV=N'" + ex.TenLoaiNV + "',NhanVien='" + ex.NhanVien + "',KhachHang='" + ex.KhachHang + "',SanPham='" + ex.SanPham + "',BanHang='" + ex.BanHang + "',NhaCungCap='" + ex.NhaCungCap + "',LoaiSP='" + ex.LoaiSP + "',NhapHang='" + ex.NhapHang + "',HoaDonNhap='" + ex.HoaDonNhap + "',PhanQuyen='" + ex.PhanQuyen + "',ThongKe='" + ex.ThongKe + "',HoaDonBan='" + ex.HoaDonBan +  "',TrangThai=" + ex.TrangThai + " Where MaLoaiNV='" + ex.MaLoaiNV + "'");
        }
    }
}
