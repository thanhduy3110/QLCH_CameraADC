using Microsoft.Reporting.WinForms;
using QLCH_CameraADC.DataAccess;
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
        private int ID_HD, IDNV;
        public frmInHD_Ban(int IDNV, int ID_HD)
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

        private void HienThiHD(int ID, int IDNV)
        {
            using (var _dbContext= new ADCDbConText() )
            {
                string sql = "select MaHDB,NhanVien.HoTen as TenNV,KhachHang.HoTen as TenKH,KhachHang.SDT as SDT,NgayLap,TongTien from HoaDonBan, NhanVien, KhachHang where HoaDonBan.MaNV = NhanVien.MaNV and HoaDonBan.MaKH = KhachHang.MaKH and HoaDonBan.MaHDB='"+ID+"'";

                List<HoaDonBan> Danhsach =_dbContext.Database.SqlQuery<HoaDonBan>(sql).ToList();

                var reportDatasoure = new ReportDataSource("DataSetHD", Danhsach);
                this.reportViewer1.LocalReport.ReportPath = "ReportHD.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDatasoure);
                this.reportViewer1.RefreshReport();

            }    
        }
     }
}
