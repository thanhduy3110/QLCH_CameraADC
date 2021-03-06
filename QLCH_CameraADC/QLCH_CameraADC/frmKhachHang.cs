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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        KhachHang_BUS bus = new KhachHang_BUS();
        KhachHang kh = new KhachHang();
        int GT;
        int flag = 0;

        public void clear()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
        }

        public void Hienthitextbox(Boolean t)
        {
            txtSDT.ReadOnly = t;
            txtTenKH.ReadOnly = t;
            rtxtGhiChu.ReadOnly = t;
        }
        public void xulychucnang(Boolean b1)
        {
            btnThem.Enabled = b1;
            btnSua.Enabled = b1;
            btnXoa.Enabled = b1;
            btnHuy.Enabled = b1;
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
        public void LoadData()
        {
            dgvDSKhachHang.DataSource = bus.GetData("");
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                clear();
                Hienthitextbox(false);
                xulychucnangthem(true);
                int dem = bus.GetTong("").Rows.Count;
                if (dem == 0)
                {
                    txtMaKH.Text = "KH001";
                }
                else if (dem < 9)
                {
                    dem = dem + 1;
                    txtMaKH.Text = "KH00" + dem;
                }
                else
                {
                    dem = dem + 1;
                    txtMaKH.Text = "KH0" + dem;
                }


                flag = 1;
            }
            else if (flag == 1)
            {
                if (radioNam.Checked == true)
                {
                    GT = 1;
                }
                else if (radioNu.Checked == true)
                {
                    GT = 0;
                }
                for (int i = 0; i < dgvDSKhachHang.Rows.Count - 0; i++)
                {
                    if (txtSDT.Text == dgvDSKhachHang.Rows[i].Cells["sdt"].Value.ToString())
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại");
                        return;
                    }
                }
                kh.MaKH = txtMaKH.Text;
                kh.HoTen = txtTenKH.Text;
                kh.SDT = txtSDT.Text;
                kh.GioiTinh = GT;
                kh.GhiChu = rtxtGhiChu.Text;
                kh.TrangThai = 1;
                bus.AddData(kh);
                MessageBox.Show("Thêm thành công");
                Hienthitextbox(true);
                xulychucnang1(true);
                LoadData();
                flag = 0;
            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            radioNam.Checked = true;
            txtMaKH.ReadOnly = true;
            Hienthitextbox(true);
            xulychucnang(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                Hienthitextbox(false);
                xulychucnangsua(true);
                flag = 1;
            }
            else if (flag == 1)
            {
                if (radioNam.Checked == true)
                {
                    GT = 1;
                }
                else if (radioNu.Checked == true)
                {
                    GT = 0;
                }
                kh.MaKH = txtMaKH.Text;
                kh.HoTen = txtTenKH.Text;
                kh.SDT = txtSDT.Text;
                kh.GioiTinh = GT;
                kh.GhiChu = rtxtGhiChu.Text;
                kh.TrangThai = 1;
                bus.EditData(kh);
                MessageBox.Show("Sửa thành công");
                Hienthitextbox(true);
                xulychucnang1(true);
                LoadData();
                flag = 0;
            }
        }

        private void dgvDSKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                DataGridViewRow row = dgvDSKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["makh"].Value.ToString();
                txtTenKH.Text = row.Cells["hoten"].Value.ToString();
                txtSDT.Text = row.Cells["sdt"].Value.ToString();
                string GT = row.Cells["gioitinh"].Value.ToString();
                if (GT == "Nam")
                {
                    radioNam.Checked = true;
                }
                else if (GT == "Nữ")
                {
                    radioNu.Checked = true;
                }
            }
            catch
            {

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult KQ = MessageBox.Show("Bạn có muốn xóa hay không ?", "Thông Báo !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (KQ == DialogResult.Yes)
            {
                kh.MaKH = txtMaKH.Text;
                bus.DeleteData(kh);
                MessageBox.Show("Xóa Dữ Liệu Thành Công");
                clear();
            }
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
            xulychucnang1(true);
        }

        private void txtTimKiem_TextChange(object sender, EventArgs e)
        {
            string conditon = txtTimKiem.Text;
            dgvDSKhachHang.DataSource = bus.TimKiemTheoSDT(conditon);
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
                    for (int i = 0; i < dgvDSKhachHang.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgvDSKhachHang.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dgvDSKhachHang.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvDSKhachHang.Columns.Count; j++)
                        {
                            if (dgvDSKhachHang.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dgvDSKhachHang.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "";
                            }
                        }
                    }

                    //Lấy vị trí và tên tệp của excel để lưu từ người 
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
