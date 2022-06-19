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
    public class SanPham_BUS
    {
        SanPham_DAL sanpham = new SanPham_DAL();

        public DataTable GetData(string Conditon)
        {
            return sanpham.GetData(Conditon);
        }

        public DataTable GetTong(string Conditon)
        {
            return sanpham.GetTong(Conditon);
        }

        public void AddData(SanPham ex)
        {
            sanpham.AddData(ex);
        }

        public void EditData(SanPham ex)
        {
            sanpham.EditData(ex);
        }

        public void DeleteData(SanPham ex)
        {
            sanpham.DeleteData(ex);
        }
    }
}
