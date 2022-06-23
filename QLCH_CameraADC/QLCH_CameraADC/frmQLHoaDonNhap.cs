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
    public partial class frmQLHoaDonNhap : Form
    {
        public frmQLHoaDonNhap()
        {
            InitializeComponent();
        }

        HoaDonNhap_BUS bus = new HoaDonNhap_BUS();
        HoaDonBan_BUS busBan = new HoaDonBan_BUS();
        HoaDonNhap hdn = new HoaDonNhap();
        CTHD_Nhap cthdn = new CTHD_Nhap();
        int flag = 0;
        string MaSP, MaNV, MaNCC, MaHD;

        public void HienThiSP()
        {
            cboTenSP.DataSource = busBan.GetSP("");
            cboTenSP.DisplayMember = "TenSP";
            cboTenSP.ValueMember = "MaSP";
        }

        public void HienThiNCC()
        {
            cboTenNCC.DataSource = bus.GetNCC("");
            cboTenNCC.DisplayMember = "TenNCC";
            cboTenNCC.ValueMember = "MaNCC";
        }

        public void HienThiNV()
        {
            cboTenNV.DataSource = busBan.GetNV("");
            cboTenNV.DisplayMember = "HoTen";
            cboTenNV.ValueMember = "MaNV";
        }

        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvDSHD.Rows[e.RowIndex];
                MaNV = row.Cells["manv1"].Value.ToString();
                MaHD = row.Cells["mahdn"].Value.ToString();
                string MaHDN = row.Cells["mahdn"].Value.ToString();
                txtMaHD.Text = row.Cells["mahdn"].Value.ToString();
                cboTenNV.Text = row.Cells["tennv"].Value.ToString();
               
                txtTongTien.Text = row.Cells["tongtien"].Value.ToString();
                txtTongTien.Text = string.Format("{0:#,##0}", double.Parse(txtTongTien.Text));
                dtpNgayLap.Text = row.Cells["ngaylap"].Value.ToString();
                CTHD_TheoHD(MaHDN);

            }
            catch
            {

            }
        }

        private void dgvDSCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvDSCTHD.Rows[e.RowIndex];
                MaSP = row.Cells["maspp"].Value.ToString();
                cboTenSP.Text = row.Cells["tensp"].Value.ToString();
                cboTenNCC.Text = row.Cells["tenncc"].Value.ToString();
                txtSL.Text = row.Cells["soluong"].Value.ToString();
                txtGiaNhap.Text = row.Cells["gianhap"].Value.ToString();
                txtGiaNhap.Text = string.Format("{0:#,##0}", double.Parse(txtGiaNhap.Text));
                txtThanhTien.Text = row.Cells["thanhtien"].Value.ToString();
                txtThanhTien.Text = string.Format("{0:#,##0}", double.Parse(txtThanhTien.Text));

                rtxtGhiChu.Text= row.Cells["ghichu"].Value.ToString();

            }
            catch

            {

            }
        }

     

        private void frmQLHoaDonNhap_Load(object sender, EventArgs e)
        {
            dgvDSHD.DataSource = bus.HienThiHDN("");
            HienThiSP();
            HienThiNV();
            HienThiNCC();
        }

        public void CTHD_TheoHD(string MaHDN)
        {
            dgvDSCTHD.DataSource = bus.HienThiCTHDNH("select CTHD_Nhap.MaSP as MaSP,CTHD_Nhap.MaNCC as MaNCC,TenSP,TenNCC,SoLuong,GiaNhap,ThanhTien,CTHD_Nhap.GhiChu,CTHD_Nhap.TrangThai from CTHD_Nhap,SanPham,NhaCungCap where CTHD_Nhap.MaSP=SanPham.MaSP and CTHD_Nhap.MaNCC=NhaCungCap.MaNCC and MaHDN='" + MaHDN + "'");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                flag = 1;
            }
            else if (flag == 1)
            {
                ThanhTienSP();
                cthdn.MaHDN = txtMaHD.Text;
                cthdn.MaSP = cboTenSP.SelectedValue.ToString();
                cthdn.MaNCC = cboTenNCC.SelectedValue.ToString();
                cthdn.SoLuong = int.Parse(txtSL.Text);
                cthdn.GiaNhap = float.Parse(txtGiaNhap.Text);
                cthdn.ThanhTien = float.Parse(txtThanhTien.Text);
                cthdn.GhiChu=rtxtGhiChu.Text;
                cthdn.TrangThai = 1;
                bus.AddCTHD(cthdn);
                CTHD_TheoHD(MaHD);
                TongThanhToan();
                MessageBox.Show("Sửa thanh cong");
                hdn.MaHDN = txtMaHD.Text;
                hdn.MaNV = cboTenNV.SelectedValue.ToString();
                hdn.NgayLap = dtpNgayLap.Value.Date;
                hdn.TongTien = float.Parse(txtTongTien.Text);
                hdn.TrangThai = 1;
                bus.UpdateHD(hdn);
                dgvDSHD.DataSource = bus.HienThiHDN("");
                flag = 0;
            }
        }

        public void ThanhTienSP()
        {
            decimal ThanhTienSP;
           
            ThanhTienSP = decimal.Parse(txtGiaNhap.Text) * decimal.Parse(txtSL.Text) ;
            txtThanhTien.Text = ThanhTienSP.ToString();
        }

        public void TongThanhToan()
        {
            decimal TongThanhToan = 0;
            for (int i = 0; i < dgvDSCTHD.Rows.Count - 0; i++)
            {
                decimal TT = decimal.Parse(dgvDSCTHD.Rows[i].Cells["thanhtien"].Value.ToString());
                TongThanhToan += TT;
                txtTongTien.Text = TongThanhToan.ToString();
                txtTongTien.Text = string.Format("{0:#,##0}", decimal.Parse(txtTongTien.Text));
            }
        }
    }
}
