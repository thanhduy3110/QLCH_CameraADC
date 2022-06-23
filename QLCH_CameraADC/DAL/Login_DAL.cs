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

        public DataTable DangNhap(string username, string password)
        {
            return KetNoi.GetDataTable("Select * From NhanVien Where MaNV='" + username + "' and MatKhau=N'" + password + "'");
        }
    }
}
