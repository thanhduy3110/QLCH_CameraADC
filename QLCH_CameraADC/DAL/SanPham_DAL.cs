using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class SanPham_DAL
    {
        KetNoiDatabase KetNoi = new KetNoiDatabase();

        public DataTable GetData(string Condition)
        {
            return KetNoi.GetDataTable("select MaSP,TenSP,TenLoaiSP,TenNSX,Gia,SL,DVT,MoTa,KhuyenMai,Hinh,SanPham.TrangThai from SanPham,LoaiSP where SanPham.MaLoaiSP=LoaiSP.MaLoaiSP and  SanPham.TrangThai=1 " + Condition);
        }

        public DataTable GetTong(string Condition)
        {
            return KetNoi.GetDataTable("select * from SanPham");
        }


        public DataTable TimKiem(string Condition)
        {
            return KetNoi.GetDataTable("select MaSP,TenSP,TenLoaiSP,TenNSX,Gia,SL,DVT,MoTa,KhuyenMai,Hinh,SanPham.TrangThai from SanPham,LoaiSP where SanPham.MaLoaiSP=LoaiSP.MaLoaiSP and  SanPham.TrangThai=1 and SanPham.TenSP like N'% " + Condition+"%'");
        }
        public void AddData(SanPham ex)
        {
            KetNoi.ExecuteReader(@"Insert into SanPham Values('" + ex.MaSP + "','" + ex.MaLoaiSP + "',N'" + ex.TenNSX + "',N'" + ex.TenSP + "'," + ex.Gia + "," + ex.SL + ",N'" + ex.DVT + "',N'" + ex.MoTa + "','"+ex.KhuyenMai+"','" + ex.Hinh + "'," + ex.TrangThai + ")");
        }

        public void EditData(SanPham ex)
        {
            KetNoi.ExecuteReader(@"Update SanPham Set MaLoaiSP ='" + ex.MaLoaiSP + "',TenNSX=N'" + ex.TenNSX + "',TenSP=N'" + ex.TenSP + "',Gia=" + ex.Gia + ",SL=" + ex.SL + ",DVT='" + ex.DVT + "',MoTa=N'" + ex.MoTa +"',KhuyenMai='"+ex.KhuyenMai+ "',Hinh='" + ex.Hinh + "',TrangThai=" + ex.TrangThai + "where MaSP='" + ex.MaSP + "'");
        }

        public void DeleteData(SanPham ex)
        {
            KetNoi.ExecuteReader(@"Update SanPham Set TrangThai=0 Where MaSP='" + ex.MaSP + "'");
        }
    }
}
