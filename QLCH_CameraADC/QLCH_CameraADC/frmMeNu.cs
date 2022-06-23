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
        public string sTenNV;
        public string sMaNV;
        public frmMeNu()
        {
            InitializeComponent();
            flag_QL = 1;
            flag_QLHD = 1;
            panelQL.Visible = false;
            panelHD.Visible = false;
        }

        public frmMeNu(string TenNV,string MaNV)
        {
            InitializeComponent();
            this.sTenNV = TenNV;
            this.sMaNV= MaNV;
            flag_QL = 1;
            flag_QLHD = 1;
            panelQL.Visible = false;
            panelHD.Visible = false;
            
        }

        public Form activeForm = null;
        int flag_QL,flag_QLHD;
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
            openChildForm(new frmBanHang(this.sTenNV,this.sMaNV));
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhapHang(this.sTenNV, this.sMaNV));
        }

        private void btnQLHoaDon_Click(object sender, EventArgs e)
        {
            openChildForm(new frmQLHoaDon());
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            if(flag_QL==1)
            {
                panelQL.Visible = false;
                flag_QL = 0;
            }  
            else if(flag_QL==0)
            {
                panelQL.Visible = true;
                flag_QL = 1;
            }    
        }

        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            openChildForm(new frmQLHoaDonNhap());
        }

        private void btnQLHD_Click(object sender, EventArgs e)
        {
            if (flag_QLHD == 1)
            {
                panelHD.Visible = false;
                flag_QLHD = 0;
            }
            else if (flag_QLHD == 0)
            {
                panelHD.Visible = true;
                flag_QLHD = 1;
            }
        }
    }
}
