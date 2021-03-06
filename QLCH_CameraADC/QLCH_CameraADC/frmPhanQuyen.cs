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
    public partial class frmPhanQuyen : Form
    {
        public frmPhanQuyen()
        {
            InitializeComponent();
        }

        LoaiNV_BUS bus = new LoaiNV_BUS();
        LoaiNV loainv = new LoaiNV();

        int flag = 0;

        public void HienThiDSLoaiNV()
        {
            dgvDSLoaiNhanVien.DataSource = bus.GetData("");
        }

        public void clear()
        {
            txtMaLoaiNV.Clear();
            txtTenLoaiNV.Clear();
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                xulychucnangthem(true);
                txtTenLoaiNV.Enabled = true;
                int dem = bus.GetTong().Rows.Count;
                if (dem == 0)
                {
                    txtMaLoaiNV.Text = "LoaiNV001";
                }
                else if (dem < 10)
                {
                    dem = dem + 1;
                    txtMaLoaiNV.Text = "LoaNVP00" + dem;
                }
                else
                {
                    dem = dem + 1;
                    txtMaLoaiNV.Text = "LoaiNV0" + dem;
                }
                flag = 1;
              
            }else if(flag == 1)
            {
                loainv.MaLoaiNV = txtMaLoaiNV.Text;
                loainv.TenLoaiNV = txtTenLoaiNV.Text;
                loainv.NhanVien = checkNhanVien.Checked;
                loainv.KhachHang = checkKhachHang.Checked;
                loainv.SanPham = checkSP.Checked;
                loainv.BanHang = checkBanHang.Checked;
                loainv.NhaCungCap = checkNCC.Checked;
                loainv.LoaiSP = checkLoaiSP.Checked;
                loainv.NhapHang = checkNhapHang.Checked;
                loainv.PhanQuyen = checkPhanQuyen.Checked;
                loainv.ThongKe = checkThongKe.Checked;
                loainv.HoaDonBan = checkHoaDonBan.Checked;
                loainv.HoaDonNhap = checkHoaDonNhap.Checked;
                loainv.TrangThai = 1;
                bus.AddChucVu(loainv);
                MessageBox.Show("Thành Công");
                HienThiDSLoaiNV();
                flag = 0;
                txtTenLoaiNV.Enabled = false;
                xulychucnang1(true);
            }    
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            HienThiDSLoaiNV();
            txtMaLoaiNV.Enabled = false;
            txtTenLoaiNV.Enabled = false;
           
            xulychucnang(false);
        }

        private void dgvDSLoaiNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            xulychucnang(true);
            try
            {
                DataGridViewRow row = dgvDSLoaiNhanVien.Rows[e.RowIndex];
                txtMaLoaiNV.Text = row.Cells["maloainv"].Value.ToString();
                txtTenLoaiNV.Text = row.Cells["tenloainv"].Value.ToString();
                checkNhanVien.Checked = Convert.ToBoolean(row.Cells["nhanvien"].Value.ToString());
                checkKhachHang.Checked = Convert.ToBoolean(row.Cells["khachhang"].Value.ToString());
                checkNCC.Checked = Convert.ToBoolean(row.Cells["nhacungcap"].Value.ToString());
                checkLoaiSP.Checked = Convert.ToBoolean(row.Cells["loaisp"].Value.ToString());
                checkSP.Checked = Convert.ToBoolean(row.Cells["sanpham"].Value.ToString());
                checkBanHang.Checked = Convert.ToBoolean(row.Cells["banhang"].Value.ToString());
                checkNhapHang.Checked = Convert.ToBoolean(row.Cells["nhaphang"].Value.ToString());
                checkHoaDonBan.Checked = Convert.ToBoolean(row.Cells["hoadonban"].Value.ToString());
                checkHoaDonNhap.Checked = Convert.ToBoolean(row.Cells["hoadonnhap"].Value.ToString());
                checkThongKe.Checked = Convert.ToBoolean(row.Cells["thongke"].Value.ToString());
                checkPhanQuyen.Checked = Convert.ToBoolean(row.Cells["phanquyen"].Value.ToString());
              
               
            }
            catch
            {

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                flag = 1;
                txtTenLoaiNV.Enabled = true;
                xulychucnangsua(true);
            }
            else if(flag == 1)
            {
                loainv.MaLoaiNV = txtMaLoaiNV.Text;
                loainv.TenLoaiNV = txtTenLoaiNV.Text;
                loainv.NhanVien = checkNhanVien.Checked;
                loainv.KhachHang = checkKhachHang.Checked;
                loainv.SanPham = checkSP.Checked;
                loainv.BanHang = checkBanHang.Checked;
                loainv.NhaCungCap = checkNCC.Checked;
                loainv.LoaiSP = checkLoaiSP.Checked;
                loainv.NhapHang = checkNhapHang.Checked;
                loainv.PhanQuyen = checkPhanQuyen.Checked;
                loainv.ThongKe = checkThongKe.Checked;
                loainv.HoaDonBan = checkHoaDonBan.Checked;
                loainv.HoaDonNhap = checkHoaDonNhap.Checked;
                loainv.TrangThai = 1;
                bus.EditCV(loainv);
                MessageBox.Show("Thành Công");
                HienThiDSLoaiNV();
                flag = 0;
                txtTenLoaiNV.Enabled = false;
                xulychucnang1(true);
            }    
        }

        private void dgvDSLoaiNhanVien_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvDSLoaiNhanVien.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
            xulychucnang1(true);
        }
    }
}
