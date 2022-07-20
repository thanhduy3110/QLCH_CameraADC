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

        //public void LoiNhuanTheoThang(string condition, string condition1)
        //{
        //    ComboBox DT = new ComboBox();
        //    ComboBox KC = new ComboBox();

        //    DT.DataSource = bus.DoanhThuTheoThang(condition, condition1);
        //    DT.DisplayMember = "TT";

        //    KC.DataSource = bus.KhoanChiTheoThang(condition, condition1);
        //    KC.DisplayMember = "TT";
        //    try
        //    {
        //        decimal LoiNhuan;
        //        LoiNhuan = decimal.Parse(DT.Text) - decimal.Parse(KC.Text);
        //        comboLoiNhuan.Text = LoiNhuan.ToString();
        //        comboLoiNhuan.Text = string.Format("{0:#,##0}", decimal.Parse(comboLoiNhuan.Text));
        //    }
        //    catch
        //    {

        //    }
        //}

        //public void KhoanChiTheoNam(string condition)
        //{
        //    cboDoanhThu.DataSource = bus.DoanThuTheoNam("" + condition);
        //    cboDoanhThu.DisplayMember = "TT";

        //    comboBoxChi.DataSource = bus.ThuChiTheoNam("" + condition);
        //    comboBoxChi.DisplayMember = "TT";

        //    try
        //    {
        //        decimal LoiNhuan;
        //        LoiNhuan = decimal.Parse(cboDoanhThu.Text) - decimal.Parse(comboBoxChi.Text);
        //        comboloinhuan.Text = LoiNhuan.ToString();
        //        comboloinhuan.Text = string.Format("{0:#,##0}", decimal.Parse(comboloinhuan.Text));
        //    }
        //    catch
        //    {

        //    }
        //}
        //public void SPBanChayTheoThang(string condition, string condition2)
        //{
        //    dgvThongKe.DataSource = bus.SPBanChayTheoThang("" + condition, condition2);
        //}

        //public void Top3SanPhamBanTrongNam(string condition)
        //{
        //    dgvThongKe.DataSource = bus.Top3SanPhamBanTrongNam("" + condition);
        //}
        //public void Top3SPMuaNhieuTrongThang(string condition, string condition1)
        //{
        //    dgvThongKe.DataSource = bus.Top3MuaMonth("" + condition, condition1);
        //}

        //public void Top3SPMuaNhieuTrongNam(string condition)
        //{
        //    dgvThongKe.DataSource = bus.Top3SPMuaYear("" + condition);
        //}

        //public void Khachhangmuanhieutrongthang(string condition, string condition1)
        //{
        //    dgvThongKe.DataSource = bus.KhachhangMuaNhieu("" + condition, condition1);
        //}

        //public void KHMuaNhieuTrongNam(string condition)
        //{
        //    dgvThongKe.DataSource = bus.KhachHangMuaNhieuTrongNam("" + condition);
        //}

        public void KhoanChiTheoThang(string condition, string condition1)
        {
            dgvThongKe.DataSource=bus.KhoanChiTheoThang(condition,condition1);
        }

        public void DoanhThuTheoThang(string condition, string condition1)
        {
            dgvThongKe.DataSource = bus.DoanhThuTheoThang(condition, condition1);
        }

        public void DSNVBanTrongThang(string condition, string condition1)
        {
            dgvThongKe.DataSource = bus.DSNVBanTrongThang(condition, condition1);
        }

        public void DSSPBanTrongThang(string condition, string condition1)
        {
            dgvThongKe.DataSource = bus.DSSPBanTrongThang(condition, condition1);
        }

        public void DSSPNhapTrongThang(string condition, string condition1)
        {
            dgvThongKe.DataSource = bus.DSSPNhapTrongThang(condition, condition1);
        }
        public void SanPhamTonKho()
        {
            dgvThongKe.DataSource = bus.SanPhamTonKho("");
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            if(radioKhoanChi.Checked==true)
            {
                string condition=cboThang.Text;
                string condition1 = cboNam.Text;
                KhoanChiTheoThang(condition, condition1);
            }

            if (radioDoanhThu.Checked == true)
            {
                string condition = cboThang.Text;
                string condition1 = cboNam.Text;
                DoanhThuTheoThang(condition, condition1);
            }

            if (radioDSNVBan.Checked == true)
            {
                string condition = cboThang.Text;
                string condition1 = cboNam.Text;
                DSNVBanTrongThang(condition, condition1);
            }

            if (radioDSSPBan.Checked == true)
            {
                string condition = cboThang.Text;
                string condition1 = cboNam.Text;
                DSSPBanTrongThang(condition, condition1);
            }

            if (radioDSSPNhap.Checked == true)
            {
                string condition = cboThang.Text;
                string condition1 = cboNam.Text;
                DSSPNhapTrongThang(condition, condition1);
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

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Records";

                try
                {
                    for (int i = 0; i < dgvThongKe.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgvThongKe.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dgvThongKe.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvThongKe.Columns.Count; j++)
                        {
                            if (dgvThongKe.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dgvThongKe.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "";
                            }
                        }
                    }

                    //Lấy vị trí và tên tệp của excel để lưu từ người dùng
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 2;

                    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    app.Quit();
                    workbook = null;
                    worksheet = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
