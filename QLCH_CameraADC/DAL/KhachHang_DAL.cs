using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class KhachHang_DAL
    {
        KetNoiDatabase KetNoi = new KetNoiDatabase();

        public DataTable GetData(string Condition)
        {
            return KetNoi.GetDataTable("select MaKH,HoTen,SDT,(CASE WHEN GioiTinh='1' THEN 'Nam' ELSE N'Nữ' END) AS GioiTinh,TrangThai from KhachHang Where TrangThai='1' " + Condition);
        }

        public DataTable GetTong(string Condition)
        {
            return KetNoi.GetDataTable("select * from KhachHang" + Condition);
        }


        public void AddData(KhachHang ex)
        {
            KetNoi.ExecuteReader(@"Insert into KhachHang values('" + ex.MaKH + "',N'" + ex.HoTen + "','" + ex.SDT + "'," + ex.GioiTinh + ",N'"+ex.GhiChu+"'," + ex.TrangThai + ")");
        }

        public void EditData(KhachHang ex)
        {
            KetNoi.ExecuteReader(@"Update KhachHang Set HoTen=N'" + ex.HoTen + "',SDT='" + ex.SDT + "',GioiTinh=" + ex.GioiTinh +",GhiChu=N'"+ex.GhiChu+ "',TrangThai=" + ex.TrangThai + " where MaKH='" + ex.MaKH + "'");
        }

        public void DeleteData(KhachHang ex)
        {
            KetNoi.ExecuteReader(@"Update KhachHang Set TrangThai=0 Where MaKH=N'" + ex.MaKH + "'");
        }

        public DataTable TimKiemTheoSDT(string Condition)
        {
            return KetNoi.GetDataTable("select MaKH,HoTen,SDT,(CASE WHEN GioiTinh='1' THEN 'Nam' ELSE N'Nữ' END) AS GioiTinh,TrangThai from KhachHang Where TrangThai='1' and SDT like '%" + Condition+"%'");
        }
    }
}
