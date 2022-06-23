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
    public class HoaDonNhap_BUS
    {
        HoaDonNhap_DAL bus = new HoaDonNhap_DAL();

        public DataTable GetData(string Condition)
        {
            return bus.GetData(Condition);
        }

        public DataTable GetNhanVien(string Condition)
        {
            return bus.GetNhanVien(Condition);
        }

        public DataTable GetNCC(string condition)
        {
            return bus.GetNCC(condition);
        }

        public DataTable HienThiHDN(string condition)
        {
            return bus.HienThiHDN(condition);
        }
        public DataTable PhatSinhMa(string condition)
        {
            return bus.PhatSinhMa(condition);
        }

      
        public DataTable HienThiCTHDNH(string condition)
        {
            return bus.HienThiCTHDNH(condition);
        }

        public void AddHoaDon(HoaDonNhap ex)
        {
            bus.AddHoaDon(ex);
        }
        public void AddCTHD(CTHD_Nhap ex)
        {
            bus.AddCTHD(ex);
        }

        public DataTable LayDSSP(string condition)
        {
            return bus.LayDSSP(condition);
        }
        public void CapNhatSLTon(SanPham sp)
        {
            bus.CapNhatSLTon(sp);
        }
        public void UpdateHD(HoaDonNhap hdn)
        {
            bus.UpdateHD(hdn);
        }

    }
}
