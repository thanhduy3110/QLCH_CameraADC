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

        //mã hóa pass
        private String GetMD5(string txt)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDN.Text;
            string password = GetMD5(txtMatKhau.Text);

            
            int count = bus.DangNhap(username, password).Rows.Count;
            
            //kiem tra
            if (count == 0)
            {
                MessageBox.Show("Tên Đăng Nhập Hoặc mật khẩu không đúng");
            }
            else if (count == 1)
            {
                //Lấy tên đăng nhập
                string TenNV = bus.DangNhap(username, password).Rows[0]["HoTen"].ToString();
                frmMeNu frm = new frmMeNu(TenNV, username);
                frm.ShowDialog();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtTenDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string username = txtTenDN.Text;
                string password = GetMD5(txtMatKhau.Text);

                int count = bus.DangNhap(username, password).Rows.Count;


                if (count == 0)
                {
                    MessageBox.Show("Tên Đăng Nhập Hoặc mật khẩu không đúng");
                }
                else if (count == 1)
                {
                    string TenNV = bus.DangNhap(username, password).Rows[0]["HoTen"].ToString();
                    frmMeNu frm = new frmMeNu(TenNV, username);
                    frm.ShowDialog();
                }
            }    
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string username = txtTenDN.Text;
                string password = GetMD5(txtMatKhau.Text);

                int count = bus.DangNhap(username, password).Rows.Count;


                if (count == 0)
                {
                    MessageBox.Show("Tên Đăng Nhập Hoặc mật khẩu không đúng");
                }
                else if (count == 1)
                {
                    string TenNV = bus.DangNhap(username, password).Rows[0]["HoTen"].ToString();
                    frmMeNu frm = new frmMeNu(TenNV, username);
                    frm.ShowDialog();
                }
            }    
        }
    }
}
