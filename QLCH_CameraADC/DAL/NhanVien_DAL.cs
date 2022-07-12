using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class NhanVien_DAL
    {
        KetNoiDatabase KetNoi = new KetNoiDatabase();

        public DataTable GetData(string Condition)
        {
            return KetNoi.GetDataTable("Select MaNV,TenLoaiNV,HoTen,NgaySinh,SDT,DiaChi,Email,CMND,(CASE WHEN GioiTinh='1' THEN 'Nam' ELSE N'Nữ' END) AS GioiTinh,HinhAnh,MatKhau,NhanVien.TrangThai from NhanVien,LoaiNV where NhanVien.MaLoaiNV=LoaiNV.MaLoaiNV and NhanVien.TrangThai=1" + Condition);
        }

        public DataTable GetTong(string Condition)
        {
            return KetNoi.GetDataTable("select * from NhanVien");
        }

        public DataTable TimKiem(string Condition)
        {
            return KetNoi.GetDataTable("Select MaNV,TenLoaiNV,HoTen,NgaySinh,SDT,DiaChi,Email,CMND,(CASE WHEN GioiTinh='1' THEN 'Nam' ELSE N'Nữ' END) AS GioiTinh,HinhAnh,MatKhau,NhanVien.TrangThai from NhanVien,LoaiNV where NhanVien.MaLoaiNV=LoaiNV.MaLoaiNV and NhanVien.TrangThai=1 and ( HoTen like '%" + Condition+"%' or SDT like '%"+Condition+"%' or CMND like '%"+Condition+"%')");
        }

        public void AddData(NhanVien ex)
        {
            KetNoi.ExecuteReader(@"Insert into NhanVien Values('" + ex.MaNV + "','" + ex.MaLoaiNV + "',N'" + ex.HoTen + "','" + ex.NgaySinh + "'," + ex.SDT + ",N'" + ex.DiaChi + "','" + ex.Email + "'," + ex.CMND + "," + ex.GioiTinh + ",'" + ex.HinhAnh + "','" + ex.MatKhau + "'," + ex.TrangThai + ")");
        }

        public void EditData(NhanVien ex)
        {
            KetNoi.ExecuteReader(@"Update NhanVien Set MaLoaiNV='" + ex.MaLoaiNV + "',HoTen=N'" + ex.HoTen + "',NgaySinh='" + ex.NgaySinh + "',SDT='" + ex.SDT + "',DiaChi=N'" + ex.DiaChi + "',Email='" + ex.Email + "',CMND=" + ex.CMND + ",GioiTinh=" + ex.GioiTinh + ",HinhAnh='" + ex.HinhAnh + "',MatKhau='" + ex.MatKhau + "',TrangThai=" + ex.TrangThai + " where MaNV='" + ex.MaNV + "'");
        }

        public void DeleteData(NhanVien ex)
        {
            KetNoi.ExecuteReader(@"update NhanVien Set TrangThai=0 Where MaNV='" + ex.MaNV + "'");
        }
    }
}
