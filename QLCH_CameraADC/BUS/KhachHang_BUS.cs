using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAL;

namespace BUS
{
    public class KhachHang_BUS
    {
        KhachHang_DAL khachHang = new KhachHang_DAL();

        public DataTable GetData(string Condition)
        {
            return khachHang.GetData(Condition);
        }

        public DataTable GetTong(string Condition)
        {
            return khachHang.GetTong(Condition);
        }
        public void AddData(KhachHang ex)
        {
            khachHang.AddData(ex);
        }

        public void EditData(KhachHang ex)
        {
            khachHang.EditData(ex);
        }

        public void DeleteData(KhachHang ex)
        {
            khachHang.DeleteData(ex);
        }

        //
        public DataTable TimKiemTheoSDT(string Condition)
        {
            return khachHang.TimKiemTheoSDT(Condition);
        }
    }
}
