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
    public partial class frmMeNu : Form
    {
        public frmMeNu()
        {
            InitializeComponent();
        }

        public Form activeForm = null;
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMid.Controls.Add(childForm);
            panelMid.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhanVien());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmKhachHang());
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhaCungCap());
        }

        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            openChildForm(new frmLoaiSP());
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new frmSanPham());
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmBanHang());
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhapHang());
        }

        private void btnQLHoaDon_Click(object sender, EventArgs e)
        {
            openChildForm(new frmQLHoaDon());
        }
    }
}
