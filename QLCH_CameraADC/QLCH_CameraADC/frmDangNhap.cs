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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        Login_BUS bus = new Login_BUS();
        NhanVien nv = new NhanVien();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDN.Text;
            string password = txtMatKhau.Text;

            int count = bus.DangNhap(username, password).Rows.Count;
            string TenNV= bus.DangNhap(username, password).Rows[0]["HoTen"].ToString();

            if (count == 0)
            {
                MessageBox.Show("Tên Đăng Nhập Hoặc mật khẩu không đúng"); 
            } 
            else if(count==1)
            {
                frmMeNu frm = new frmMeNu(TenNV,username);
                frm.ShowDialog();
            }    
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
