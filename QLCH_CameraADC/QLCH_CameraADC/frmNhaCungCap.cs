using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLCH_CameraADC
{
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        NhaCungCap_BUS bus = new NhaCungCap_BUS();
        NhaCungCap ncc = new NhaCungCap();
        int flag = 0;

        public void LoadData()
        {
            dgvDSNCC.DataSource = bus.GetData("");
        }

        public void clear()
        {
            txtTenNCC.Clear();
            txtMaNCC.Clear();
            rtxtDiaChi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            rtxtGhiChu.Clear();
        }

        public void HienthiTextbox(Boolean b1)
        {

            txtTenNCC.ReadOnly=b1;
            txtEmail.ReadOnly=b1;
            txtSDT.ReadOnly=b1;
            rtxtDiaChi.ReadOnly = b1;
            rtxtGhiChu.ReadOnly = b1;
        }

        public void xulychucnang(Boolean b1)
        {
            btnThem.Enabled = !b1;
            btnHuy.Enabled = b1;
            btnSua.Enabled = b1;
            btnXoa.Enabled = b1;
        }
        public void xulychucnang1(Boolean b1)
        {
            btnThem.Enabled = b1;
            btnSua.Enabled = b1;
            btnXoa.Enabled = b1;
            btnHuy.Enabled = !b1;
            
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
                HienthiTextbox(false);
                xulychucnangthem(true);
                int dem = bus.PhatSinhMa("").Rows.Count;
                if (dem == 0)
                {
                    txtMaNCC.Text = "NCC001";
                }
                else if (dem < 9)
                {
                    dem = dem + 1;
                    txtMaNCC.Text = "NCC00" + dem;
                }
                else
                {
                    dem = dem + 1;
                    txtMaNCC.Text = "NCC0" + dem;
                }
                flag = 1;
            }
            else if (flag == 1)
            {

                for (int i = 0; i < dgvDSNCC.Rows.Count - 0; i++)
                {
                    if (txtSDT.Text == dgvDSNCC.Rows[i].Cells["sdt"].Value.ToString())
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại");
                        return;
                    }
                }
                ncc.MaNCC = txtMaNCC.Text;
                ncc.TenNCC = txtTenNCC.Text;
                ncc.Email = txtEmail.Text;
                ncc.SDT=txtSDT.Text;
                ncc.GhiChu = rtxtGhiChu.Text;
                ncc.DiaChi = rtxtDiaChi.Text;
                ncc.TrangThai = 1;
                bus.AddData(ncc);
                MessageBox.Show("Thêm thành công");
                LoadData();
                HienthiTextbox(true);
                xulychucnang1(true);
                flag = 0;

            }
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            txtMaNCC.ReadOnly = true;
            LoadData();
            xulychucnang(false);
            HienthiTextbox(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult KQ = MessageBox.Show("Bạn có muốn xóa hay không ?", "Thông Báo !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (KQ == DialogResult.Yes)
            {
                ncc.MaNCC = txtMaNCC.Text;
                bus.DeleteData(ncc);
                MessageBox.Show("Xóa Dữ Liệu Thành Công");
                clear();

            }
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (flag == 0)
            {
                HienthiTextbox(false);
                xulychucnangsua(true);
                flag = 1;
            }
            else if (flag == 1)
            {
                ncc.MaNCC = txtMaNCC.Text;
                ncc.TenNCC = txtTenNCC.Text;
                ncc.Email = txtEmail.Text;
                ncc.SDT = txtSDT.Text;
                ncc.GhiChu = rtxtGhiChu.Text;
                ncc.DiaChi = rtxtDiaChi.Text;
                ncc.TrangThai = 1;
                bus.EditData(ncc);
                MessageBox.Show("Sửa thành công");
                LoadData();
                HienthiTextbox(true);
                xulychucnang1(true);
                flag = 0;
            }
        }

        private void dgvDSNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                DataGridViewRow row = dgvDSNCC.Rows[e.RowIndex];
                txtMaNCC.Text = row.Cells["mancc"].Value.ToString();
                txtTenNCC.Text = row.Cells["tenncc"].Value.ToString();
                rtxtDiaChi.Text = row.Cells["diachi"].Value.ToString();
                txtSDT.Text = row.Cells["sdt"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                rtxtGhiChu.Text = row.Cells["ghichu"].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
            xulychucnang(false);
        }

        private void txtTimKiem_TextChange(object sender, EventArgs e)
        {
            string condition =txtTimKiem.Text;
            dgvDSNCC.DataSource = bus.Timkiem(condition);
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
                    for (int i = 0; i < dgvDSNCC.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgvDSNCC.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dgvDSNCC.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvDSNCC.Columns.Count; j++)
                        {
                            if (dgvDSNCC.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dgvDSNCC.Rows[i].Cells[j].Value.ToString();
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
