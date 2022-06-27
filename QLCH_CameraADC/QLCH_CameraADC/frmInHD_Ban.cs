using Microsoft.Reporting.WinForms;
using QLCH_CameraADC.DataAccess;
using QLCH_CameraADC.Reporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCH_CameraADC
{
    public partial class frmInHD_Ban : Form
    {
        private string ID_HD, IDNV;
        public frmInHD_Ban(string IDNV, string ID_HD)
        {
            InitializeComponent();
            this.IDNV = IDNV;
            this.ID_HD = ID_HD;
        }
        
          
        private void frmInHD_Ban_Load(object sender, EventArgs e)
        {
            HienThiHD(this.ID_HD, this.IDNV);
            this.reportViewer1.RefreshReport();
        }

        private void HienThiHD(string ID, string IDNV)
        {
            using (var _dbContext= new ADCDbConText() )
            {
                string sql = "select MaHDB,NhanVien.HoTen as TenNV,KhachHang.HoTen as TenKH,KhachHang.SDT as SDT,NgayLap,TongTien from HoaDonBan, NhanVien, KhachHang where HoaDonBan.MaNV = NhanVien.MaNV and HoaDonBan.MaKH = KhachHang.MaKH and HoaDonBan.MaHDB='"+ID+"'";

                List<InHDBan> Danhsach =_dbContext.Database.SqlQuery<InHDBan>(sql).ToList();

                string sql1 = "select CTHD_Ban.MaSP as MaSP,TenSP,SoLuong,GiaSP,CTHD_Ban.KhuyenMai,ThanhTien,CTHD_Ban.TrangThai from CTHD_Ban,SanPham where CTHD_Ban.MaSP=SanPham.MaSP and MaHDB='" + ID + "'";

                List<InHDBan_CTHDBan> Danhsach1 = _dbContext.Database.SqlQuery<InHDBan_CTHDBan>(sql1).ToList();

                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\ngodu\source\repos\QLADC\QLCH_CameraADC\QLCH_CameraADC\QLCH_CameraADC\Reporting\ReportHD.rdlc";

                var reportDatasoure = new ReportDataSource("DataSetHD", Danhsach);
                var reportDatasoure1 = new ReportDataSource("DataSetCTHD", Danhsach1);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDatasoure);
                this.reportViewer1.LocalReport.DataSources.Add(reportDatasoure1);
                this.reportViewer1.RefreshReport();

            }    
        }
     }
}
