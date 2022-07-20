using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QLCH_CameraADC
{
    public partial class frmLoaiSP : Form
    {
        public frmLoaiSP()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            dgvDSLoaiSP.DataSource = bus.GetData("");
        }

        LoaiSP loaiSP = new LoaiSP();

        LoaiSP_BUS bus = new LoaiSP_BUS();

        int flag = 0;
        public void clear()
        {
            txtMaLoaiSP.Clear();
            txtTenLoaiSP.Clear();

        }
        public void xulytextbox(Boolean b1)
        {
            
            txtTenLoaiSP.Enabled = b1;
        }

        public void xulychucnang(Boolean b1)
        {
            btnThem.Enabled = !b1;
            btnSua.Enabled = b1;
            btnXoa.Enabled = b1;
            btnHuy.Enabled = b1;
        }

        public void xulychucnangthem(Boolean b1)
        {
            btnThem.Enabled = b1;
            btnHuy.Enabled = b1;
            btnSua.Enabled = !b1;
            btnXoa.Enabled = !b1;
        }

        public void xulychucnangsua(Boolean b1)
        {
            btnThem.Enabled = !b1;
            btnSua.Enabled = b1;
            btnHuy.Enabled = b1;
            btnXoa.Enabled = !b1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                clear();
                xulytextbox(true);
                xulychucnangthem(true);
                int dem = bus.GetData("").Rows.Count;
                if (dem == 0)
                {
                    txtMaLoaiSP.Text = "LoaiSP001";
                }
                else if (dem < 10)
                {
                    dem = dem + 1;
                    txtMaLoaiSP.Text = "LoaiSP00" + dem;
                }
                else
                {
                    dem = dem + 1;
                    txtMaLoaiSP.Text = "LoaiSP0" + dem;
                }
                flag = 1;
            }
            else if (flag == 1)
            {

                loaiSP.MaLoaiSP = txtMaLoaiSP.Text;
                loaiSP.TenLoaiSP = txtTenLoaiSP.Text;
                loaiSP.TrangThai = 1;
                bus.AddData(loaiSP);
                MessageBox.Show("Thêm thành công");
                LoadData();
                xulytextbox(false);
                xulychucnang(false);
                flag = 0;

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                xulytextbox(true);
                xulychucnangsua(true);
                flag = 1;
            }
            else if (flag == 1)
            {
                loaiSP.MaLoaiSP = txtMaLoaiSP.Text;
                loaiSP.TenLoaiSP = txtTenLoaiSP.Text;
                loaiSP.TrangThai = 1;
                bus.Editdata(loaiSP);
                MessageBox.Show("Sửa thành công");
                LoadData();
                xulytextbox(false);
                xulychucnang(false);
                flag = 0;
            }
        }

        private void dgvDSLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                DataGridViewRow row = dgvDSLoaiSP.Rows[e.RowIndex];
                txtMaLoaiSP.Text = row.Cells["maloaisp"].Value.ToString();
                txtTenLoaiSP.Text = row.Cells["tenloaisp"].Value.ToString();
            }
            catch
            {

            }
        }

        private void frmLoaiSP_Load(object sender, EventArgs e)
        {
            txtMaLoaiSP.Enabled=false;
            LoadData();
            xulytextbox(false);
            xulychucnang(false);
          
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult KQ = MessageBox.Show("Bạn có muốn xóa hay không ?", "Thông Báo !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (KQ == DialogResult.Yes)
            {
                loaiSP.MaLoaiSP = txtMaLoaiSP.Text;
                bus.DeleteData(loaiSP);
                MessageBox.Show("Xóa Dữ Liệu Thành Công");
                clear();
                xulychucnang(false);
            }
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            clear();
            xulytextbox(false);
        }

        private void txtTimKiem_TextChange(object sender, EventArgs e)
        {
            string condition = txtTimKiem.Text;
            dgvDSLoaiSP.DataSource=bus.Timkiem(condition);
        }

        private void btnXuatEXL_Click(object sender, EventArgs e)
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
                    for (int i = 0; i < dgvDSLoaiSP.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgvDSLoaiSP.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dgvDSLoaiSP.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvDSLoaiSP.Columns.Count; j++)
                        {
                            if (dgvDSLoaiSP.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dgvDSLoaiSP.Rows[i].Cells[j].Value.ToString();
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
