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
namespace QLCH_CameraADC
{
    public partial class frmMeNu : Form
    {
        public string sTenNV;
        public string sMaNV;
        int flag_QL=1, flag_QLHD=1;
        Login_BUS bus = new Login_BUS();
        //public frmMeNu()
        //{
        //    InitializeComponent();
        //    flag_QL = 1;
        //    flag_QLHD = 1;
        //    panelQL.Visible = false;
        //    panelHD.Visible = false;
        //}

        public frmMeNu(string TenNV,string MaNV)
        {
            InitializeComponent();
            this.sTenNV = TenNV;
            this.sMaNV= MaNV;
           
            panelQL.Visible = false;
            panelHD.Visible = false;
            
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



        public bool PhanQuyen(int col)
        {
            bool KiemTra = false;
            for (int i = 0; i < bus.GetLogin1(this.sMaNV).Rows.Count; i++)
            {
                if (bus.GetLogin1(this.sMaNV).Rows[i][col].ToString() == "True")
                    return KiemTra = true;
            }

            return KiemTra;
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
            openChildForm(new frmQLHoaDon(this.sTenNV, this.sMaNV));
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            if(flag_QL==1)
            {
                panelQL.Visible = true;
                flag_QL = 0;
            }  
            else if(flag_QL==0)
            {
                panelQL.Visible = false;
                flag_QL = 1;
            }    
        }

        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            openChildForm(new frmQLHoaDonNhap(this.sTenNV, this.sMaNV));
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            openChildForm(new frmThongKe());
        }

        private void frmMeNu_Load(object sender, EventArgs e)
        {
            if (PhanQuyen(15)) btnNhanVien.Enabled = true; else btnNhanVien.Visible = false;
            if (PhanQuyen(16)) btnKhachHang.Enabled = true; else btnKhachHang.Visible = false;
            if (PhanQuyen(17)) btnNhaCungCap.Enabled = true; else btnNhaCungCap.Visible = false;
            if (PhanQuyen(18)) btnLoaiSP.Enabled = true; else btnLoaiSP.Visible = false;
            if (PhanQuyen(19)) btnSanPham.Enabled = true; else btnSanPham.Visible = false;
            if (PhanQuyen(20)) btnBanHang.Enabled = true; else btnBanHang.Visible = false;
            if (PhanQuyen(21)) btnNhapHang.Enabled = true; else btnNhapHang.Visible = false;
            if (PhanQuyen(22)) btnQLHoaDon.Enabled = true; else btnQLHoaDon.Visible = false;
            if (PhanQuyen(23)) btnHoaDonNhap.Enabled = true; else btnHoaDonNhap.Visible = false;
            if (PhanQuyen(24)) btnThongKe.Enabled = true; else btnThongKe.Visible = false;
            if (PhanQuyen(25)) btnPhanQuyen.Enabled = true; else btnPhanQuyen.Visible = false;

        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            openChildForm(new frmPhanQuyen());
        }

        private void btnQLHD_Click(object sender, EventArgs e)
        {
            if (flag_QLHD == 1)
            {
                panelHD.Visible = true;
                flag_QLHD = 0;
            }
            else if (flag_QLHD == 0)
            {
                panelHD.Visible = false;
                flag_QLHD = 1;
            }
        }
    }
}
