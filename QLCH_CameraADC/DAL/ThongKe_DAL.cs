using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
namespace DAL
{
    public class ThongKe_DAL
    {
        KetNoiDatabase KetNoi = new KetNoiDatabase();

        public DataTable DoanhThuCacThang()
        {
            return KetNoi.GetDataTable("SELECT Month(hd.NgayLap) as Thang, sum(hd.TongTien) as TongTien FROM HoaDonBan hd WHERE hd.TrangThai=N'1' and Month(hd.NgayLap)>0 and MONTH(hd.NgayLap)<13  Group By Month(hd.NgayLap)");
        }

        public DataTable DoanhThuTheoThang(string condition, string condition1)
        {
            return KetNoi.GetDataTable("SELECT   format(sum([TongTien]),'N0') AS N'Tổng tiền'" +
              " FROM HoaDonBan hd WHERE Month(hd.NgayLap)=" + condition + " and Year(hd.NgayLap)=" + condition1 + " ");
        }


        //public DataTable DoanhThuTheoNam(string condition)
        //{
        //    return KetNoi.GetDataTable("Select format(sum([TongTien]),'N0') as TT" +
        //        " From HoaDonBan Where YEAR(NgayLap) =" + condition + "");
        //}

        public DataTable KhoanChiTheoThang(string condition,string condition1)
        {
            return KetNoi.GetDataTable("SELECT   format(sum([TongTien]),'N0') AS N'Tổng tiền'" +
              " FROM HoaDonNhap hd WHERE Month(hd.NgayLap)=" + condition + " and Year(hd.NgayLap)=" + condition1 + " ");
        }


        //public DataTable ThuChiTheoNam(string condition)
        //{
        //    return KetNoi.GetDataTable("SELECT   format(sum([TongTien]),'N0') AS TT" +
        //      " FROM HoaDonNhap hd WHERE Year(hd.NgayLap)=" + condition + "");
        //}

        //public DataTable SPBanChayTheoThang(string condiiton, string condition2)
        //{
        //    return KetNoi.GetDataTable("SELECT TOP(3) sp.TenSP As'Tên Sản Phẩm', SUM(ct.SoLuong) AS 'Số Lượng'  " +
        //        "FROM CTHD_Ban ct, HoaDonBan hd, SanPham sp " +
        //        "where ct.MaHDB = hd.MaHDB and sp.MaSP = ct.MaSP  and MONTH(hd.NgayLap) =" + condiiton + " and Year(hd.NgayLap)=" + condition2 + "" +
        //        " GROUP BY sp.TenSP ORDER BY SUM(ct.SoLuong) DESC ");
        //}

        //public DataTable Top3SanPhamBanTrongNam(string condiiton)
        //{
        //    return KetNoi.GetDataTable("SELECT TOP(3) sp.TenSP As'Tên Sản Phẩm', SUM(ct.SoLuong) AS 'Số Lượng'" +
        //        " FROM CTHD_Ban ct, HoaDonBan hd, SanPham sp" +
        //        " where ct.MaHDB = hd.MaHDB and sp.MaSP = ct.MaSP  and Year(hd.NgayLap) =" + condiiton + " " +
        //        "GROUP BY sp.TenSP ORDER BY SUM(ct.SoLuong) DESC");
        //}

        //public DataTable Top3SPMuaNhieuTrongThang(string condition, string condition1)
        //{
        //    return KetNoi.GetDataTable("SELECT TOP(3) sp.TenSP As'Tên Sản Phẩm', SUM(ct.SoLuong) AS 'Số Lượng'" +
        //        " FROM CTHD_Nhap ct, HoaDonNhap hd, SanPham sp " +
        //        "where ct.MaHDN = hd.MaHDN and sp.MaSP = ct.MaSP  and Month(hd.NgayLap) =" + condition + "and Year(hd.NgayLap)=" + condition1 + " " +
        //        "GROUP BY sp.TenSP ORDER BY SUM(ct.SoLuong) DESC");
        //}
        //public DataTable Top3SPMuaNhieuTrongNam(string condition)
        //{
        //    return KetNoi.GetDataTable("SELECT TOP(3) sp.TenSP As'Tên Sản Phẩm', SUM(ct.SoLuong) AS 'Số Lượng' " +
        //        "FROM CTHD_Nhap ct, HoaDonNhap hd, SanPham sp " +
        //        "where ct.MaHDN = hd.MaHDN and sp.MaSP = ct.MaSP  and Year(hd.NgayLap) =" + condition + " " +
        //        "GROUP BY sp.TenSP ORDER BY SUM(ct.SoLuong) DESC");
        //}

        //public DataTable KhachHangMuaNhieu(string condition, string condition1)
        //{
        //    return KetNoi.GetDataTable("SELECT TOP(1) kh.TenKH As'Tên Khách Hàng', count(hd.MaHDB) AS 'Số Lần' FROM  HoaDonBan hd,KhachHang kh where kh.MaKH=hd.MaKH and month(hd.NgayLap) =" + condition + " and Year(hd.NgayLap)=" + condition1 + " GROUP BY kh.TenKH ORDER BY count(hd.MaHDB) DESC");
        //}

        //public DataTable KhachHangMuaNhieuTrongNam(string condition)
        //{
        //    return KetNoi.GetDataTable("SELECT TOP(1) kh.TenKH As'Tên Khách Hàng', count(hd.MaHDB) AS 'Số Lần' FROM  HoaDonBan hd,KhachHang kh where kh.MaKH=hd.MaKH and year(hd.NgayLap) =" + condition + " GROUP BY kh.TenKH ORDER BY count(hd.MaHDB) DESC");
        //}

        public DataTable DSNVBanTrongThang(string condition, string condition1)
        {
            return KetNoi.GetDataTable("SELECT  nv.HoTen as N'Họ tên nhân viên', format(sum([TongTien]),'N0') AS N'Tổng tiền'" +
              " FROM HoaDonBan hd, NhanVien nv WHERE hd.MaNV=nv.MaNV and Month(hd.NgayLap)=" + condition + " and Year(hd.NgayLap)=" + condition1 + " ");
        }

        public DataTable DSSPBanTrongThang(string condition, string condition1)
        {
            return KetNoi.GetDataTable("SELECT  sp.TenSP as N'Tên sản phẩm', SUM(cthd.SoLuong) as N'Số lượng'" +
              " FROM HoaDonBan hd,CTHD_Ban cthd,SanPham sp WHERE hd.MaHDB=cthd.MaHDB and cthd.MaSP=sp.MaSP and Month(hd.NgayLap)=" + condition + " and Year(hd.NgayLap)=" + condition1 + " ");
        }

        public DataTable DSSPNhapTrongThang(string condition, string condition1)
        {
            return KetNoi.GetDataTable("SELECT  sp.TenSP as N'Tên sản phẩm', SUM(cthd.SoLuong) as N'Số lượng'" +
              " FROM HoaDonNhap hd,CTHD_Nhap cthd,SanPham sp WHERE hd.MaHDN=cthd.MaHDN and cthd.MaSP=sp.MaSP and Month(hd.NgayLap)=" + condition + " and Year(hd.NgayLap)=" + condition1 + " ");
        }
        public DataTable SanPhamTonKho(string condition)
        {
            return KetNoi.GetDataTable("Select TenSP as 'Tên sản phẩm',SL as 'Số Lượng Tồn' From SanPham Where TrangThai=N'1' " + condition);
        }
    }
}
