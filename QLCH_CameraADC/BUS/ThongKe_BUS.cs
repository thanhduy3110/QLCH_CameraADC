using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
namespace BUS
{
    public class ThongKe_BUS
    {
        ThongKe_DAL tk = new ThongKe_DAL();

        public DataTable DoanhThuCacThang()
        {
            return tk.DoanhThuCacThang();
        }

        public DataTable DoanhThuTheoThang(string condition, string condition1)
        {
            return tk.DoanhThuTheoThang(condition, condition1);
        }

        public DataTable DoanThuTheoNam(string condition)
        {
            return tk.DoanhThuTheoNam(condition);
        }

        public DataTable KhoanChiTheoThang(string condition)
        {
            return tk.KhoanChiTheoThang(condition);
        }

     
        public DataTable ThuChiTheoNam(string condition)
        {
            return tk.ThuChiTheoNam(condition);
        }

        public DataTable SPBanChayTheoThang(string condition, string condition2)
        {
            return tk.SPBanChayTheoThang(condition, condition2);
        }
        public DataTable Top3SanPhamBanTrongNam(string condition)
        {
            return tk.Top3SanPhamBanTrongNam(condition);
        }
        public DataTable Top3MuaMonth(string condition, string condition1)
        {
            return tk.Top3SPMuaNhieuTrongThang(condition, condition1);
        }
        public DataTable Top3SPMuaYear(string condition)
        {
            return tk.Top3SPMuaNhieuTrongNam(condition);
        }
        public DataTable KhachhangMuaNhieu(string condition, string condition1)
        {
            return tk.KhachHangMuaNhieu(condition, condition1);
        }
        public DataTable KhachHangMuaNhieuTrongNam(string condition)
        {
            return tk.KhachHangMuaNhieuTrongNam(condition);
        }
        public DataTable SanPhamTonKho(string condition)
        {
            return tk.SanPhamTonKho(condition);
        }
    }
}
