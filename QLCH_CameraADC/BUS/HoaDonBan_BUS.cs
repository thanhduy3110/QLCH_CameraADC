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
    public class HoaDonBan_BUS
    {
        HoaDonBan_DAL HDB = new HoaDonBan_DAL();

        public DataTable GetData(string Condition)
        {
            return HDB.GetData(Condition);
        }

        public DataTable GetCTHD(string Condition)
        {
            return HDB.GetCTHD(Condition);
        }
        public DataTable GetSP(string Condition)
        {
            return HDB.GetSP(Condition);
        }

        public DataTable GetNV(string Condition)
        {
            return HDB.GetNV(Condition);
        }

        public DataTable GetKH(string Condition)
        {
            return HDB.GetKH(Condition);
        }

      

        public DataTable GetTimKiemSP(string Condition)
        {
            return HDB.GetTimKiemSP(Condition);
        }

        public DataTable LaySP(string Condition)
        {
            return HDB.LaySP(Condition);
        }

        public DataTable GetDSkH(string Condition)
        {
            return HDB.GetDSkH(Condition);
        }

        public DataTable GetNhanVien(string Condition)
        {
            return HDB.GetNhanVien(Condition);
        }

        public DataTable PhatSinhMaHD(string Condition)
        {
            return HDB.PhatSinhMaHD(Condition);
        }

        public void AddHD(HoaDonBan hdb)
        {
            HDB.AddHD(hdb);
        }

        public void AddCTHD(CTHD_Ban cthd)
        {
            HDB.AddCTHD(cthd);
        }

        public void CapNhatSLTon(SanPham sp)
        {
            HDB.CapNhatSLTon(sp);
        }

        public void UpDateHD(HoaDonBan hdb)
        {
            HDB.UpdateHD(hdb);
        }

        public void UpDateCTHD(CTHD_Ban cthd)
        {
            HDB.UpDateCTHD(cthd);
        }

        public void DeleteHD(HoaDonBan hdb)
        {
            HDB.DeleteHD(hdb);
        }
    }
}
