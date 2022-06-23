using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class HoaDonBan_DAL
    {
        KetNoiDatabase KetNoi = new KetNoiDatabase();

        public DataTable GetData(string Condition)
        {
            return KetNoi.GetDataTable("select MaHDB,NhanVien.HoTen as TenNV,KhachHang.HoTen as TenKH,HoaDonBan.MaKH as MaKH,HoaDonBan.MaNV as MaNV,NgayLap,TongTien,HoaDonBan.TrangThai from HoaDonBan, NhanVien, KhachHang where HoaDonBan.MaNV = NhanVien.MaNV and HoaDonBan.MaKH = KhachHang.MaKH");

        }

        public DataTable GetCTHD(string Condition)
        {
            return KetNoi.GetDataTable("" + Condition);
        }

        public DataTable GetSP(string Condition)
        {
            return KetNoi.GetDataTable("Select MaSP,TenSP from SanPham Order By TenSP ASC" + Condition);
        }

        public DataTable GetNV(string Condition)
        {
            return KetNoi.GetDataTable("Select MaNV,HoTen from NhanVien Order By TenNV ASC" + Condition);
        }

        public DataTable GetKH(string Condition)
        {
            return KetNoi.GetDataTable("Select MaKH,HoTen from KhachHang Order By HoTen ASC" + Condition);
        }

       

        public DataTable GetTimKiemSP(string Condition)
        {
            return KetNoi.GetDataTable("" + Condition);
        }

        public DataTable LaySP(string Condition)
        {
            return KetNoi.GetDataTable("" + Condition);
        }

        public DataTable GetDSkH(string Condition)
        {
            return KetNoi.GetDataTable("" + Condition);
        }

        public DataTable GetNhanVien(string Condition)
        {
            return KetNoi.GetDataTable("" + Condition);
        }


        public DataTable PhatSinhMaHD(string condition)
        {
            return KetNoi.GetDataTable("select * From HoaDonBan" + condition);
        }

        public void AddHD(HoaDonBan hdb)
        {
            KetNoi.ExecuteReader(@"Insert into HoaDonBan values('" + hdb.MaHDB + "','" + hdb.MaNV + "','" + hdb.MaKH + "','" + hdb.NgayLap + "'," + hdb.TongTien + "," + hdb.TrangThai + ")");
        }

        public void AddCTHD(CTHD_Ban cthd)
        {
            KetNoi.ExecuteReader(@"insert into CTHD_Ban values('" + cthd.MaHDB + "','" + cthd.MaSP + "'," + cthd.SoLuong + "," + cthd.GiaSP + "," + cthd.ThanhTien + ",'" + cthd.KhuyenMai + "'," + cthd.TrangThai + ")");
        }

        public void CapNhatSLTon(SanPham sp)
        {
            KetNoi.ExecuteReader(@"Update SanPham Set SL=" + sp.SL + " Where MaSP='" + sp.MaSP + "'");
        }


        public void UpdateHD(HoaDonBan hdb)
        {
            KetNoi.ExecuteReader(@"Update HoaDonBan set MaNV='" + hdb.MaNV + "',MaKH='" + hdb.MaKH + "',Ngaylap='" + hdb.NgayLap + "',TongTien=" + hdb.TongTien + ",TrangThai=" + hdb.TrangThai + " where MaHDB='" + hdb.MaHDB + "'");
        }

        public void UpDateCTHD(CTHD_Ban cthd)
        {
            KetNoi.ExecuteReader(@"Update CTHD_Ban set SoLuong=" + cthd.SoLuong + ",GiaSP=" + cthd.GiaSP + ",ThanhTien=" + cthd.ThanhTien + ",KhuyenMai='" + cthd.KhuyenMai + "',TrangThai=" + cthd.TrangThai + " where MaSP='" + cthd.MaSP + "'");
        }
    }
}
