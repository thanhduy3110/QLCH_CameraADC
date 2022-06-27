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

    public partial class frmInHD_Nhap : Form
    {
        private string ID_HD, IDNV;
        public frmInHD_Nhap(string IDNV, string ID_HD)
        {
            InitializeComponent();
            this.IDNV = IDNV;
            this.ID_HD = ID_HD;
        }

        private void frmInHD_Nhap_Load(object sender, EventArgs e)
        {
            HienThiHD(this.ID_HD, this.IDNV);
            this.reportViewer1.RefreshReport();
        }

        private void HienThiHD(string ID, string IDNV)
        {
            using (var _dbContext = new ADCDbConText())
            {
                string sql = "select MaHDN,NV.HoTen as TenNV,NgayLap,TongTien From HoaDonNhap HD,NhanVien NV Where NV.MaNV=HD.MaNV and HD.MaHDN='" + ID + "'";

                List<InHDNhap> Danhsach = _dbContext.Database.SqlQuery<InHDNhap>(sql).ToList();

                string sql1 = "select CTHD_Nhap.MaSP as MaSP,CTHD_Nhap.MaNCC as MaNCC,TenSP,TenNCC,SoLuong,GiaNhap,ThanhTien,CTHD_Nhap.GhiChu,CTHD_Nhap.TrangThai from CTHD_Nhap,SanPham,NhaCungCap where CTHD_Nhap.MaSP=SanPham.MaSP and CTHD_Nhap.MaNCC=NhaCungCap.MaNCC and MaHDN='" + ID + "'";

                List<InHDNhap_CTHDNhap> Danhsach1 = _dbContext.Database.SqlQuery<InHDNhap_CTHDNhap>(sql1).ToList();

                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\ngodu\source\repos\QLADC\QLCH_CameraADC\QLCH_CameraADC\QLCH_CameraADC\Reporting\ReportHDNhap.rdlc";

                var reportDatasoure = new ReportDataSource("DataSetHD", Danhsach);
                var reportDatasoure1 = new ReportDataSource("DataSetHDNhap", Danhsach1);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDatasoure);
                this.reportViewer1.LocalReport.DataSources.Add(reportDatasoure1);
                this.reportViewer1.RefreshReport();

            }
        }
    }
}
