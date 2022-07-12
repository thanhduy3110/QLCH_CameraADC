using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class LoaiSP_DAL
    {
        KetNoiDatabase KetNoi = new KetNoiDatabase();

        //Lấy danh sách
        public DataTable GetData(string Condition)
        {
            return KetNoi.GetDataTable("Select * from LoaiSP Where TrangThai=N'1' " + Condition);
        }

        //Tìm kiếm
        public DataTable Timkiem(string Condition)
        {
            return KetNoi.GetDataTable("Select * from LoaiSP Where TrangThai=N'1' and TenLoaiSP like N'%" + Condition+"%'");
        }
        //Thêm
        public void AddData(LoaiSP ex)
        {
            KetNoi.ExecuteReader(@"Insert into LoaiSP values('" + ex.MaLoaiSP + "',N'" + ex.TenLoaiSP + "'," + ex.TrangThai + ")");
        }

        //Sửa
        public void EditData(LoaiSP ex)
        {
            KetNoi.ExecuteReader(@"Update LoaiSP Set TenLoaiSP=N'" + ex.TenLoaiSP + "',TrangThai=" + ex.TrangThai + "where MaLoaiSP='" + ex.MaLoaiSP + "'");
        }

        //Xóa
        public void DeleteData(LoaiSP ex)
        {
            KetNoi.ExecuteReader(@"Update LoaiSP Set TrangThai=0 Where MaLoaiSP='" + ex.MaLoaiSP+"'" );
        }
    }
}
