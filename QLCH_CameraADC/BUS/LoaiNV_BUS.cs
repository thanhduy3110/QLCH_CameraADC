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
    public class LoaiNV_BUS
    {
        LoaiNV_DAL loaiNV = new LoaiNV_DAL();

        public DataTable GetData(string Condition)
        {
            return loaiNV.GetData(Condition);
        }

        public DataTable GetTong()
        {
            return loaiNV.GetTong();
        }

        public void AddChucVu(LoaiNV ex)
        {
            loaiNV.AddChucVu(ex);
        }
        public void EditCV(LoaiNV ex)
        {
            loaiNV.EditChuCVu(ex);
        }

    }
}
