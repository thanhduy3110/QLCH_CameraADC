using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonNhap
    {
        public string MaHDN { get; set; }
        public string MaNV { get; set; }
        public string MaNCC { get; set; }
        public DateTime? NgayLap { get; set; }
        public float TongTien { get; set; }
        public int TrangThai { get; set; }
    }
}
