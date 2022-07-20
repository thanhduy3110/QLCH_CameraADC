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
        private string sMaNV;
        private string sTenNV;
        public frmQLHoaDon()
        {
            InitializeComponent();
        }

        public frmQLHoaDon(string TenNV,string MaNV)
        {
            InitializeComponent();
            this.sTenNV = TenNV;
            this.sMaNV = MaNV;
        }

        HoaDonBan_BUS bus = new HoaDonBan_BUS();
        HoaDonBan hdb = new HoaDonBan();
        CTHD_Ban cthdb = new CTHD_Ban();
        SanPham sp = new SanPham();
        int flag = 0;
        string MaSP, MaNV, MaKH, MaHD;

        private void frmQLHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnInHD.Enabled = false;
            txtMaHD.Enabled = false;
            txtTongTien.Enabled = false;
            txtThanhTien.Enabled = false;
            txtDonGia.Enabled = false;
            txtKhuyenMai.Enabled = false;
            Hienthitextbox(false);
           
        }

        public void clear()
        {
            txtMaHD.Clear();
            cboTenKH.Text = "";
            txtTongTien.Clear();
            cboTenNV.Text = "";
            dtpNgayLap.Text = "";
            cboTenSP.Text = "";
            txtSL.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();
            txtKhuyenMai.Clear();
        }
        public void Hienthitextbox(Boolean b)
        {
           
            dtpNgayLap.Enabled = b;
            txtSL.Enabled = b;
          
            
            cboTenSP.Enabled = b;
            cboTenNV.Enabled = b;
            cboTenKH.Enabled = b;
        }
        public void LoadData()
        {
            dgvDSHD.DataSource = bus.GetData("");
        }

        public void HienThiSP()
        {
            cboTenSP.DataSource = bus.GetSP("");
            cboTenSP.DisplayMember = "TenSP";
            cboTenSP.ValueMember = "MaSP";
        }

        public void HienThiKH()
        {
            cboTenKH.DataSource = bus.GetKH("");
            cboTenKH.DisplayMember = "HoTen";
            cboTenKH.ValueMember = "MaKH";
        }

        public void HienThiNV()
        {
            cboTenNV.DataSource = bus.GetNV("");
            cboTenNV.DisplayMember = "HoTen";
            cboTenNV.ValueMember = "MaNV";
        }

      

        public void CTHD_TheoHD(string MaHDB)
        {
            dgvDSCTHD.DataSource = bus.GetCTHD("select CTHD_Ban.MaSP as MaSP,TenSP,SoLuong,GiaSP,CTHD_Ban.KhuyenMai,ThanhTien,CTHD_Ban.TrangThai from CTHD_Ban,SanPham where CTHD_Ban.MaSP=SanPham.MaSP and MaHDB='" + MaHDB + "'");
        }

        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                HienThiKH();
                HienThiNV();
               
                DataGridViewRow row = dgvDSHD.Rows[e.RowIndex];
                MaNV = row.Cells["manv"].Value.ToString();
                MaKH = row.Cells["makh"].Value.ToString();
                MaHD = row.Cells["mahdb"].Value.ToString();
                string MaHDB = row.Cells["mahdb"].Value.ToString();
                txtMaHD.Text = row.Cells["mahdb"].Value.ToString();
                cboTenNV.Text = row.Cells["tennv"].Value.ToString();
                cboTenKH.Text = row.Cells["tenkh"].Value.ToString();
                txtTongTien.Text = row.Cells["tongtien"].Value.ToString();
                txtTongTien.Text = string.Format("{0:#,##0}", double.Parse(txtTongTien.Text));
                dtpNgayLap.Text = row.Cells["ngaylap"].Value.ToString();
                CTHD_TheoHD(MaHDB);

            }
            catch
            {

            }
        }

      

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult KQ = MessageBox.Show("Bạn có muốn xóa hay không ?", "Thông Báo !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (KQ == DialogResult.Yes)
            {
                hdb.MaHDB = txtMaHD.Text;
                bus.DeleteHD(hdb);
                MessageBox.Show("Xóa sản phẩm thành công");
               

            }
            clear();
            LoadData();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            frmInHD_Ban inHD = new frmInHD_Ban(this.sMaNV, MaHD);
            inHD.Show();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                Hienthitextbox(true);
                btnInHD.Enabled = false;
                btnXoa.Enabled = false;
                flag = 1;
            }
            else if (flag == 1)
            {
                int sl, slconlai;
                ThanhTienSP();
                cthdb.MaHDB = txtMaHD.Text;
                cthdb.MaSP = cboTenSP.SelectedValue.ToString();

                DataTable DSCTHDB = bus.GetCTHD("select * from CTHD_Ban where MaSP = '" + cboTenSP.SelectedValue.ToString() + "' and MaHDB='" + txtMaHD.Text + "'");
                DataTable DSSP = bus.LaySP("Select * From SanPham Where MaSP='" + cboTenSP.SelectedValue.ToString() + "'");


                if (int.Parse(txtSL.Text) >= int.Parse(DSCTHDB.Rows[0]["SoLuong"].ToString()))
                {
                    sl = int.Parse(txtSL.Text) - int.Parse(DSCTHDB.Rows[0]["SoLuong"].ToString());
                    slconlai = int.Parse(DSSP.Rows[0]["SL"].ToString()) + sl;
                }
                else
                {
                    sl = int.Parse(DSCTHDB.Rows[0]["SoLuong"].ToString()) - int.Parse(txtSL.Text);
                    slconlai = int.Parse(DSSP.Rows[0]["SL"].ToString()) - sl;
                }
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
                hdb.MaNV = cboTenNV.SelectedValue.ToString();
                hdb.MaKH = cboTenKH.SelectedValue.ToString();
                hdb.NgayLap = dtpNgayLap.Value.Date;
                hdb.TongTien = float.Parse(txtTongTien.Text);
                hdb.TrangThai = 1;
                bus.UpDateHD(hdb);
                sp.MaSP = cboTenSP.SelectedValue.ToString();
                sp.SL = slconlai;
                bus.CapNhatSLTon(sp);
                LoadData();
                flag = 0;
                Hienthitextbox(false);
                btnInHD.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void btnXuatEXL_Click(object sender, EventArgs e)
        {

        }

        private void dgvDSCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                HienThiSP();
                btnSua.Enabled = true;
                btnInHD.Enabled = true;
                btnXoa.Enabled = true;
                DataGridViewRow row = dgvDSCTHD.Rows[e.RowIndex];
                MaSP = row.Cells["maspp"].Value.ToString();
                cboTenSP.Text = row.Cells["tensp"].Value.ToString();
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
          
            ThanhTienSP = decimal.Parse(txtKhuyenMai.Text) * decimal.Parse(txtSL.Text) ;
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
