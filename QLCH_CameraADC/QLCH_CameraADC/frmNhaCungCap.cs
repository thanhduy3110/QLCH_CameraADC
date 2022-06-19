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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                clear();
               
                int dem = bus.PhatSinhMa("").Rows.Count;
                if (dem == 0)
                {
                    txtMaNCC.Text = "NCC001";
                }
                else if (dem < 10)
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

                flag = 0;

            }
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
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
            
                flag = 0;
            }
        }

        private void dgvDSNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
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
    }
}
