using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class HoaDonNhap_DAL
    {
        KetNoiDatabase KetNoi = new KetNoiDatabase();

        public DataTable GetData(string Condition)
        {
            return KetNoi.GetDataTable("Select MaSP,TenSP from SanPham where TrangThai=N'1' " + Condition);
        }

        public DataTable GetNhanVien(string Condition)
        {
            return KetNoi.GetDataTable("" + Condition);
        }

        public DataTable GetNCC(string condition)
        {
            return KetNoi.GetDataTable("Select * From NhaCungCap" + condition);
        }

        public DataTable HienThiHDN(string condition)
        {
            return KetNoi.GetDataTable("select MaHDN,NV.HoTen as TenNV,HD.MaNV,NgayLap,TongTien,HD.TrangThai From HoaDonNhap HD,NhanVien NV Where NV.MaNV=HD.MaNV  and HD.TrangThai=N'1'");
        }

        public DataTable PhatSinhMa(string condition)
        {
            return KetNoi.GetDataTable("Select * From HoaDonNhap" + condition);
        }

        public DataTable HienThiCTHDNH(string condition)
        {
            return KetNoi.GetDataTable("" + condition);
        }

        public void AddHoaDon(HoaDonNhap ex)
        {
            KetNoi.ExecuteReader(@"insert into HoaDonNhap(MaHDN,MaNV,NgayLap,TongTien,TrangThai)
Values('" + ex.MaHDN  + "','" + ex.MaNV + "','" + ex.NgayLap + "'," + ex.TongTien + "," + ex.TrangThai + ")");
        }

        public void AddCTHD(CTHD_Nhap ex)
        {
            KetNoi.ExecuteReader(@"insert into CTHD_Nhap(MaHDN,MaSP,MaNCC,SoLuong,GiaNhap,ThanhTien,GhiChu,TrangThai)
values('" + ex.MaHDN + "','" + ex.MaSP + "','" + ex.MaNCC + "'," + ex.SoLuong + "," + ex.GiaNhap + "," + ex.ThanhTien + ",N'"+ex.GhiChu+"'," + ex.TrangThai + ")");
        }

        public void UpdateHDN(HoaDonNhap ex)
        {
            KetNoi.ExecuteReader(@" update HoaDonNhap Set NgayLap='" + ex.NgayLap + "',TongTien=" + ex.TongTien + " Where MaHDN='" + ex.MaHDN + "'");
        }

        public void UpdateCTHDN(CTHD_Nhap ex)
        {
            KetNoi.ExecuteReader(@"update CTHD_Nhap Set MaSP='"+ex.MaSP+"',MaNCC='"+ex.MaNCC+"',SoLuong=" + ex.SoLuong + ",GiaNhap=" + ex.GiaNhap + ",ThanhTien=" + ex.ThanhTien + ",GhiChu=N'"+ex.GhiChu+"'  Where MaHDN=N'" + ex.MaHDN +"'");
        }

        public DataTable LayDSSP(string condition)
        {
            return KetNoi.GetDataTable("" + condition);
        }

        public void CapNhatSLTon(SanPham sp)
        {
            KetNoi.ExecuteReader(@"Update SanPham Set SL=" + sp.SL + " Where MaSP='" + sp.MaSP + "'");
        }
        public void UpdateHD(HoaDonNhap hdb)
        {
            KetNoi.ExecuteReader(@"Update HoaDonNhap set MaNV='" + hdb.MaNV  + "',Ngaylap='" + hdb.NgayLap + "',TongTien=" + hdb.TongTien + ",TrangThai=" + hdb.TrangThai + " where MaHDN='" + hdb.MaHDN + "'");
        }

    }
}
