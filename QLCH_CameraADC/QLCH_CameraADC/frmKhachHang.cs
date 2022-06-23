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

        public void xulychucnang(Boolean b1)
        {
            btnThem.Enabled = b1;
            btnSua.Enabled = b1;
            btnXoa.Enabled = b1;
        }

        public void xulychucnangthem(Boolean b1)
        {
            btnThem.Enabled = b1;
            btnSua.Enabled = !b1;
            btnXoa.Enabled = !b1;
        }

        public void xulychucnangsua(Boolean b1)
        {
            btnThem.Enabled = !b1;
            btnSua.Enabled = b1;
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
                int dem = bus.GetTong("").Rows.Count;
                if (dem == 0)
                {
                    txtMaKH.Text = "KH001";
                }
                else if (dem < 10)
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
                kh.MaKH = txtMaKH.Text;
                kh.HoTen = txtTenKH.Text;
                kh.SDT = txtSDT.Text;
                kh.GioiTinh = GT;
                kh.GhiChu = rtxtGhiChu.Text;
                kh.TrangThai = 1;
                bus.AddData(kh);
                MessageBox.Show("Thêm thành công");
                LoadData();
                flag = 0;
            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            radioNam.Checked = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
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
                LoadData();
                flag = 0;
            }
        }

        private void dgvDSKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
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
    }
}
