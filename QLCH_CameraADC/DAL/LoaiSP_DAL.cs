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

        public DataTable GetData(string Condition)
        {
            return KetNoi.GetDataTable("Select * from LoaiSP Where TrangThai=N'1' " + Condition);
        }

        public DataTable Timkiem(string Condition)
        {
            return KetNoi.GetDataTable("Select * from LoaiSP Where TrangThai=N'1' and TenLoaiSP like N'%" + Condition+"%'");
        }
        public void AddData(LoaiSP ex)
        {
            KetNoi.ExecuteReader(@"Insert into LoaiSP values('" + ex.MaLoaiSP + "',N'" + ex.TenLoaiSP + "'," + ex.TrangThai + ")");
        }

        public void EditData(LoaiSP ex)
        {
            KetNoi.ExecuteReader(@"Update LoaiSP Set TenLoaiSP=N'" + ex.TenLoaiSP + "',TrangThai=" + ex.TrangThai + "where MaLoaiSP='" + ex.MaLoaiSP + "'");
        }

        public void DeleteData(LoaiSP ex)
        {
            KetNoi.ExecuteReader(@"Update LoaiSP Set TrangThai=0 Where MaLoaiSP='" + ex.MaLoaiSP+"'" );
        }
    }
}
