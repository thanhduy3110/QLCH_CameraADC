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
    public partial class frmQLHoaDon : Form
    {
        public frmQLHoaDon()
        {
            InitializeComponent();
        }

        HoaDonBan_BUS bus = new HoaDonBan_BUS();
        HoaDonBan hdb = new HoaDonBan();
        CTHD_Ban cthdb = new CTHD_Ban();
        int flag = 0;
        string MaSP, MaNV, MaKH, MaHD;

        private void frmQLHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            dgvDSHD.DataSource = bus.GetData("");
        }

        public void CTHD_TheoHD(string MaHDB)
        {
            dgvDSCTHD.DataSource = bus.GetCTHD("select CTHD_Ban.MaSP as MaSP,TenSP,SoLuong,GiaSP,CTHD_Ban.KhuyenMai,ThanhTien,CTHD_Ban.TrangThai from CTHD_Ban,SanPham where CTHD_Ban.MaSP=SanPham.MaSP and MaHDB='" + MaHDB + "'");
        }

        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvDSHD.Rows[e.RowIndex];
                MaNV = row.Cells["manv"].Value.ToString();
                MaKH = row.Cells["makh"].Value.ToString();
                MaHD = row.Cells["mahdb"].Value.ToString();
                string MaHDB = row.Cells["mahdb"].Value.ToString();
                txtMaHD.Text = row.Cells["mahdb"].Value.ToString();
                txtTenNV.Text = row.Cells["tennv"].Value.ToString();
                txtTenKH.Text = row.Cells["tenkh"].Value.ToString();
                txtTongTien.Text = row.Cells["tongtien"].Value.ToString();
                txtTongTien.Text = string.Format("{0:#,##0}", double.Parse(txtTongTien.Text));
                dtpNgayLap.Text = row.Cells["ngaylap"].Value.ToString();
                CTHD_TheoHD(MaHDB);

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
            }
            else if (flag == 1)
            {
                ThanhTienSP();
                cthdb.MaHDB = txtMaHD.Text;
                cthdb.MaSP = MaSP;
                cthdb.SoLuong = int.Parse(txtSL.Text);
                cthdb.GiaSP = float.Parse(txtDonGia.Text);
                cthdb.ThanhTien = float.Parse(txtThanhTien.Text);
                cthdb.KhuyenMai = txtKhuyenMai.Text;
                cthdb.TrangThai = 1;
                bus.UpDateCTHD(cthdb);
                CTHD_TheoHD(MaHD);
                TongThanhToan();
                MessageBox.Show("Sửa thanh cong");
                hdb.MaHDB = txtMaHD.Text;
                hdb.MaNV = MaNV;
                hdb.MaKH = MaKH;
                hdb.NgayLap = dtpNgayLap.Value.Date;
                hdb.TongTien = float.Parse(txtTongTien.Text);
                hdb.TrangThai = 1;
                bus.UpDateHD(hdb);
                LoadData();
                flag = 0;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void dgvDSCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvDSCTHD.Rows[e.RowIndex];
                MaSP = row.Cells["maspp"].Value.ToString();
                txtTenSP.Text = row.Cells["tensp"].Value.ToString();
                txtSL.Text = row.Cells["soluong"].Value.ToString();
                txtDonGia.Text = row.Cells["giasp"].Value.ToString();
                txtDonGia.Text = string.Format("{0:#,##0}", double.Parse(txtDonGia.Text));
                txtKhuyenMai.Text = row.Cells["khuyenmai"].Value.ToString();
                txtThanhTien.Text = row.Cells["thanhtien"].Value.ToString();
                txtThanhTien.Text = string.Format("{0:#,##0}", double.Parse(txtThanhTien.Text));

            }
            catch

            {

            }
        }
    

        

        public void ThanhTienSP()
        {
            decimal ThanhTienSP;
            decimal KM = decimal.Parse(txtSL.Text) * decimal.Parse(txtDonGia.Text) * decimal.Parse(txtKhuyenMai.Text) / 100;
            ThanhTienSP = decimal.Parse(txtDonGia.Text) * decimal.Parse(txtSL.Text) - KM;
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
