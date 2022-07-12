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

        public DataTable GetData(string Conditon)
        {
            return nhanvien.GetData(Conditon);
        }

        public DataTable GetTong(string Conditon)
        {
            return nhanvien.GetTong(Conditon);
        }
        public DataTable TimKiem(string Conditon)
        {
            return nhanvien.TimKiem(Conditon);
        }

        public void AddData(NhanVien ex)
        {
            nhanvien.AddData(ex);
        }

        public void EditData(NhanVien ex)
        {
            nhanvien.EditData(ex);
        }

        public void DeleteData(NhanVien ex)
        {
            nhanvien.DeleteData(ex);
        }
    }
}
