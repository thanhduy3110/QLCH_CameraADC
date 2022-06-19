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
    public class NhaCungCap_BUS
    {
        NhaCungCap_DAL ncc = new NhaCungCap_DAL();

        public DataTable GetData(string Conditon)
        {
            return ncc.GetData(Conditon);
        }

        public DataTable PhatSinhMa(string condition)
        {
            return ncc.PhatSinhMa(condition);
        }

        public void AddData(NhaCungCap ex)
        {
            ncc.AddData(ex);
        }
        public void EditData(NhaCungCap ex)
        {
            ncc.EditData(ex);
        }
        public void DeleteData(NhaCungCap ex)
        {
            ncc.DeleteData(ex);
        }
    }
}
