using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
namespace DAL
{
    public class Login_DAL
    {
        KetNoiDatabase KetNoi = new KetNoiDatabase();
        NhanVien bus = new NhanVien();

        //Dang nhap
        public DataTable DangNhap(string username, string password)
        {
            return KetNoi.GetDataTable("Select * From NhanVien Where MaNV='" + username + "' and MatKhau=N'" + password + "'");
        }

        //kiểm tra quyền đăng nhập
        public DataTable GetLoGin1(string username)
        {
            return KetNoi.GetDataTable(@"Select * From NhanVien,LoaiNV Where  NhanVien.MaNV='" + username + "' and LoaiNV.MaLoaiNV=NhanVien.MaLoaiNV");
        }
    }
}
