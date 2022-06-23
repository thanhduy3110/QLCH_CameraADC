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
    public class LoaiSP_BUS
    {
        LoaiSP_DAL loaiSP = new LoaiSP_DAL();

        public DataTable GetData(string Condition)
        {
            return loaiSP.GetData(Condition);
        }
        public void AddData(LoaiSP ex)
        {
            loaiSP.AddData(ex);
        }

        public void Editdata(LoaiSP ex)
        {
            loaiSP.EditData(ex);
        }

        public void DeleteData(LoaiSP ex)
        {
            loaiSP.DeleteData(ex);
        }
    }
}
