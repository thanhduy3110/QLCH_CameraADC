using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class NhaCungCap_DAL
    {
        KetNoiDatabase KetNoi = new KetNoiDatabase();

        //Lay danh sach
        public DataTable GetData(string Condition)
        {
            return KetNoi.GetDataTable("Select MaNCC,TenNCC,DiaChi,SDT,Email,GhiChu from NhaCungCap Where TrangThai=1" + Condition);
        }

        //Tang ma tu dong
        public DataTable PhatSinhMa(string condition)
        {
            return KetNoi.GetDataTable("Select * From NhaCungCap" + condition);
        }

        //Tim kiem
        public DataTable Timkiem(string Condition)
        {
            return KetNoi.GetDataTable("Select MaNCC,TenNCC,DiaChi,SDT,Email,GhiChu from NhaCungCap Where TrangThai=1 and (TenNCC like N'%" + Condition+"%' or SDT like '%"+Condition+"%' )");
        }

        //Them
        public void AddData(NhaCungCap ex)
        {
            KetNoi.ExecuteReader(@"INSERT INTO NhaCungCap     
                                   VALUES('" + ex.MaNCC + "',N'" + ex.TenNCC + "',N'" + ex.DiaChi +
                                   "','" + ex.SDT + "','" + ex.Email + "',N'"+ex.GhiChu+"'," + ex.TrangThai + ")");
        }

        //Sửa
        public void EditData(NhaCungCap ex)
        {
            KetNoi.ExecuteReader(@"UPDATE NhaCungCap SET TenNCC =N'" + ex.TenNCC + "', DiaChi =N'" + ex.DiaChi +
                "', SDT ='" + ex.SDT + "',Email ='" + ex.Email +"',GhiChu=N'"+ ex.GhiChu+"',TrangThai=" + ex.TrangThai + " Where MaNCC=N'" + ex.MaNCC + "'");
        }

        //Xóa
        public void DeleteData(NhaCungCap ex)
        {
            KetNoi.ExecuteReader(@"Update NhaCungCap Set TrangThai=0 Where MaNCC='" + ex.MaNCC + "'");
        }
    }
}
