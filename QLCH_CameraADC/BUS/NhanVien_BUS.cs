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
    public class NhanVien_BUS
    {
        NhanVien_DAL nhanvien = new NhanVien_DAL();

        //Lấy danh sách nhân viên
        public DataTable GetData(string Conditon)
        {
            return nhanvien.GetData(Conditon);
        }

        public DataTable GetTong(string Conditon)
        {
            return nhanvien.GetTong(Conditon);
        }

        //Lấy data tìm kiếm
        public DataTable TimKiem(string Conditon)
        {
            return nhanvien.TimKiem(Conditon);
        }

        //Thêm data nhân viên
        public void AddData(NhanVien ex)
        {
            nhanvien.AddData(ex);
        }

        //chỉnh sửa data nhân viên
        public void EditData(NhanVien ex)
        {
            nhanvien.EditData(ex);
        }

        //Xóa data nhân viên
        public void DeleteData(NhanVien ex)
        {
            nhanvien.DeleteData(ex);
        }
    }
}
