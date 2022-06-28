using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BUS;

namespace QLCH_CameraADC
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }
        ThongKe_BUS bus = new ThongKe_BUS();

        public void KhoanChiThangNay(string condition, string condition1)
        {
            comboBoxChi.DataSource = bus.KhoanChiTheoThang("" + condition);
            comboBoxChi.DisplayMember = "TT";

            cboDoanhThu.DataSource = bus.DoanhThuTheoThang("" + condition, condition1);
            cboDoanhThu.DisplayMember = "TT";
            try
            {
                decimal LoiNhuan;
                LoiNhuan = decimal.Parse(cboDoanhThu.Text) - decimal.Parse(comboBoxChi.Text);
                comboloinhuan.Text = LoiNhuan.ToString();
                comboloinhuan.Text = string.Format("{0:#,##0}", decimal.Parse(comboloinhuan.Text));
            }
            catch
            {

            }
        }

        public void KhoanChiTheoNam(string condition)
        {
            cboDoanhThu.DataSource = bus.DoanThuTheoNam("" + condition);
            cboDoanhThu.DisplayMember = "TT";

            comboBoxChi.DataSource = bus.ThuChiTheoNam("" + condition);
            comboBoxChi.DisplayMember = "TT";

            try
            {
                decimal LoiNhuan;
                LoiNhuan = decimal.Parse(cboDoanhThu.Text) - decimal.Parse(comboBoxChi.Text);
                comboloinhuan.Text = LoiNhuan.ToString();
                comboloinhuan.Text = string.Format("{0:#,##0}", decimal.Parse(comboloinhuan.Text));
            }
            catch
            {

            }
        }
        public void SPBanChayTheoThang(string condition, string condition2)
        {
            dgvThongKe.DataSource = bus.SPBanChayTheoThang("" + condition, condition2);
        }

        public void Top3SanPhamBanTrongNam(string condition)
        {
            dgvThongKe.DataSource = bus.Top3SanPhamBanTrongNam("" + condition);
        }
        public void Top3SPMuaNhieuTrongThang(string condition, string condition1)
        {
            dgvThongKe.DataSource = bus.Top3MuaMonth("" + condition, condition1);
        }

        public void Top3SPMuaNhieuTrongNam(string condition)
        {
            dgvThongKe.DataSource = bus.Top3SPMuaYear("" + condition);
        }

        public void Khachhangmuanhieutrongthang(string condition, string condition1)
        {
            dgvThongKe.DataSource = bus.KhachhangMuaNhieu("" + condition, condition1);
        }

        public void KHMuaNhieuTrongNam(string condition)
        {
            dgvThongKe.DataSource = bus.KhachHangMuaNhieuTrongNam("" + condition);
        }
        public void SanPhamTonKho()
        {
            dgvThongKe.DataSource = bus.SanPhamTonKho("");
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            if (radioBanNhieuMonth.Checked == true)
            {
                string condition1 = cboThang.Text;
                string condition2 = cboNam.Text;
                SPBanChayTheoThang(condition1, condition2);
            }

            if (radioBanNhieuYear.Checked == true)
            {
                string condition2 = cboNam.Text;
                Top3SanPhamBanTrongNam(condition2);
            }

            if (radioBanNhieuYear.Checked == true)
            {
                string condition = cboNam.Text;
                Top3SPMuaNhieuTrongNam(condition);
            }
            if (radioMuaNhieuMonth.Checked == true)
            {
                string condition = cboThang.Text;
                string condition1 = cboNam.Text;
                Top3SPMuaNhieuTrongThang(condition, condition1);
            }

            if (radioKHMuaNhieuThang.Checked == true)
            {
                string condition = cboThang.Text;
                string condition1 = cboNam.Text;
                Khachhangmuanhieutrongthang(condition, condition1);
            }
            if (radioKHMuaNhieuNam.Checked == true)
            {
                string condition = cboNam.Text;
                KHMuaNhieuTrongNam(condition);
            }

            if (radioSPTonKho.Checked == true)
            {
                SanPhamTonKho();
            }
        }

        public void LoadBieuDo()
        {
            int year = DateTime.Now.Year;
            var chart = chart1.ChartAreas[0];
            chart.AxisX.IntervalType = DateTimeIntervalType.Number;

            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "{#,###} Đ";
            chart.AxisY.LabelStyle.IsEndLabelVisible = true;

            chart.AxisX.Minimum = 1;
            chart.AxisX.Maximum = 12;
            chart.AxisY.Minimum = 0;

            //chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0,}K";
            chart1.DataSource = bus.DoanhThuCacThang();
            chart1.Series["Doanh Thu"].XValueMember = "Thang";
            chart1.Series["Doanh Thu"].YValueMembers = "TongTien";
            chart1.Titles.Add("Doanh Thu Các Tháng Của Năm" + " " + year);
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            LoadBieuDo();
            AddItems_cboNam();
        }

        private void AddItems_cboNam()
        {
            try
            {
                cboNam.Items.Clear();
                for (int i = DateTime.Now.Year - 1; i < DateTime.Now.Year + 1; i++)
                {
                    cboNam.Items.Add(i);
                }
                //comboBoxNam.Text = DateTime.Now.Year.ToString();
            }
            catch
            {

            }
        }

        private void dgvThongKe_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvThongKe.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
