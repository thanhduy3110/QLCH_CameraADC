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
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();
        }

        int GT;
        int SoLuongTon;
        int SoluongConLai = 0;
        int SoLuongTonNguyen;
        float tongtien = 0;
        string MaSP = "";

        KhachHang_BUS kh_bus = new KhachHang_BUS();
        HoaDonBan_BUS bus = new HoaDonBan_BUS();

        SanPham sp = new SanPham();
        KhachHang kh = new KhachHang();
        HoaDonBan hdb = new HoaDonBan();
        CTHD_Ban cthd = new CTHD_Ban();

        public void LoadData()
        {
            
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            DataTable DSKH_Them = bus.GetDSkH("Select * From KhachHang Where SDT=N'" + txtSDT.Text + "'");
            {
                try
                {
                    if (DSKH_Them.Rows.Count > 0)
                    {
                        if (txtSDT.Text == DSKH_Them.Rows[0]["SDT"].ToString())
                        {
                            MessageBox.Show("Số điện thoại đã tồn tại");
                            return;
                        }
                    }
                    else
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
                        kh_bus.AddData(kh);
                        MessageBox.Show("Thêm Khách Hàng Thành Công");
                    }
                }
                catch
                {

                }


            }
        }

        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable DSKH = bus.GetDSkH("Select * From KhachHang Where SDT=N'" + txtSDT.Text + "'");
                if (DSKH.Rows.Count > 0)
                {
                    if (txtSDT.Text == DSKH.Rows[0]["SDT"].ToString())
                    {

                        txtTenKH.Text = DSKH.Rows[0]["HoTen"].ToString();

                        txtMaKH.Text = DSKH.Rows[0]["MaKH"].ToString();
                        string t = DSKH.Rows[0]["GioiTinh"].ToString();
                        if (t == "True")
                            radioNam.Checked = true;
                        else
                            radioNu.Checked = true;
                    }

                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng");
                    txtTenKH.Clear();
                    txtSDT.Clear();
                    int dem = kh_bus.GetTong("").Rows.Count;
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
                }
            }
        }


        public void HienThiNhanVien(string condition)
        {
            cboTenNV.DataSource = bus.GetNhanVien("Select MaNV,HoTen From NhanVien Where MaNV=N'" + condition + "'");
            cboTenNV.DisplayMember = "HoTen";
            cboTenNV.ValueMember = "MaNV";
        }

        public void HienThiTimKiemSP(string condition)
        {
            cboTenSP.DataSource = bus.GetTimKiemSP("select TenSP,MaSP From SanPham Where TenSP Like N'%" + condition + "%'");
            cboTenSP.DisplayMember = "TenSP";
            cboTenSP.ValueMember = "MaSP";
        }

        private void txtSearchSP_TextChange(object sender, EventArgs e)
        {
            string condition = txtSearchSP.Text;
            HienThiTimKiemSP(condition);
        }

        public void ThanhTienSanPham()
        {
            float ThanhTien;
            //float ChietKhau;
            //ChietKhau = (int.Parse(txtKhuyenMai.Text) * float.Parse(txtDonGia.Text) * (((int)NumreicSL.Value)) / 100);
            ThanhTien = float.Parse(txtGiaSP.Text) * (((int)NumreicSL.Value));
            lblThanhTien.Text = ThanhTien.ToString();
            lblThanhTien.Text = string.Format("{0:#,##0}", float.Parse(lblThanhTien.Text));

        }

        private void cboTenSP_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable DSSP = bus.LaySP("Select * From SanPham Where TenSP=N'" + cboTenSP.Text + "'");
            if (DSSP.Rows.Count > 0)
            {
                if (cboTenSP.Text == DSSP.Rows[0]["TenSP"].ToString())
                {
                    if (int.Parse(DSSP.Rows[0]["SL"].ToString()) == 0)
                    {
                        MessageBox.Show("Sản Phẩm Này Đã Hết Hàng");
                        return;
                    }
                    else
                    {
                        txtGiaSP.Text = DSSP.Rows[0]["Gia"].ToString();
                        txtGiaSP.Text = string.Format("{0:#,##0}", double.Parse(txtGiaSP.Text));
                        //txtKhuyenMai.Text = DSSP.Rows[0]["KhuyenMai"].ToString();
                        //txtKhuyenMai.Text = string.Format("{0:#,##0}", double.Parse(txtKhuyenMai.Text));
                        NumreicSL.Value = 1;
                        SoLuongTon = int.Parse(DSSP.Rows[0]["SL"].ToString());
                        SoLuongTonNguyen = int.Parse(DSSP.Rows[0]["SL"].ToString());
                        txtKhuyenMai.Text = DSSP.Rows[0]["KhuyenMai"].ToString();
                        ThanhTienSanPham();
                    }
                }
            }
        }

        private void NumreicSL_MouseUp(object sender, MouseEventArgs e)
        {
            ThanhTienSanPham();
        }

        private void NumreicSL_MouseDown(object sender, MouseEventArgs e)
        {
            ThanhTienSanPham();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (((int)NumreicSL.Value) > SoLuongTon)
            {
                MessageBox.Show("Sản Phẩm Này Chỉ Còn " + SoLuongTon);
                return;
            }

            int KiemTra = 0;
            int vitri = 0;
            float KM;
            float tt = 0;
            tongtien += tt;
            //KM = (int.Parse(txtKhuyenMai.Text) * float.Parse(txtDonGia.Text) * (((int)NumreicSL.Value)) / 100);
            tt = float.Parse(txtGiaSP.Text) * (((int)NumreicSL.Value));
            SoluongConLai = SoLuongTon - (((int)NumreicSL.Value));
            tongtien += tt;
            lblThanhTien.Text = tt.ToString();
            lblThanhTien.Text = string.Format("{0:#,##0}", float.Parse(lblThanhTien.Text));
            for (int i = 0; i < dgvDSSPChon.Rows.Count - 0; i++)
            {
                if (cboTenSP.Text == dgvDSSPChon.Rows[i].Cells["TenSP"].Value.ToString())
                {
                    KiemTra = 1;
                    vitri = i;
                    break;
                }
            }
            if (KiemTra == 1)
            {

                int SL = ((int)NumreicSL.Value) + int.Parse(dgvDSSPChon.Rows[vitri].Cells["SoLuong"].Value.ToString());
                dgvDSSPChon.Rows[vitri].Cells["SoLuong"].Value = SL.ToString();
                int SLConLaiMoi = int.Parse(dgvDSSPChon.Rows[vitri].Cells["SLConLai"].Value.ToString()) - ((int)NumreicSL.Value);
                dgvDSSPChon.Rows[vitri].Cells["SLConLai"].Value = SLConLaiMoi.ToString();
                float ThanhTienMoi = tt + float.Parse(dgvDSSPChon.Rows[vitri].Cells["ThanhTien"].Value.ToString());
                dgvDSSPChon.Rows[vitri].Cells["ThanhTien"].Value = ThanhTienMoi.ToString();
                dgvDSSPChon.Rows[vitri].Cells["ThanhTien"].Value = string.Format("{0:#,##0}", float.Parse(ThanhTienMoi.ToString()));
            }

            else
            {
                MaSP += cboTenSP.SelectedValue.ToString() + ";";
                Add_Datagrid(cboTenSP.Text, (((int)NumreicSL.Value)), float.Parse(txtGiaSP.Text), float.Parse(txtKhuyenMai.Text), float.Parse(lblThanhTien.Text), SoLuongTonNguyen, SoluongConLai);
                TongTienSP();
            }
        }

        private void Add_Datagrid(string tensp, int soluong, float dongia, float khuyenmai, float thanhtien, int soluongconlai, int soluongnguyen)
        {
            try
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvDSSPChon);
                newRow.Cells[0].Value = tensp;
                newRow.Cells[1].Value = soluong;
                newRow.Cells[2].Value = dongia;
                newRow.Cells[3].Value = khuyenmai;
                newRow.Cells[4].Value = thanhtien;
                newRow.Cells[5].Value = soluongconlai;
                newRow.Cells[6].Value = soluongnguyen;
                dgvDSSPChon.Rows.Add(newRow);
            }
            catch
            {

            }
        }

        
        public void TongTienSP()
        {
            float sum = 0;
            for (int i = 0; i < dgvDSSPChon.Rows.Count; ++i)
            {
                sum += float.Parse(dgvDSSPChon.Rows[i].Cells["ThanhTien"].Value.ToString());
            }
            txtTongTT.Text = sum.ToString();
            txtTongTT.Text = string.Format("{0:#,##0}", float.Parse(txtTongTT.Text));
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            string search = "NV001";
            HienThiNhanVien(search);
        }

        int flag = 0;
        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            int dem = bus.PhatSinhMaHD("").Rows.Count;
            if (dem == 0)
            {
                txtMaHD.Text = "HD001";
            }
            else if (dem < 10)
            {
                dem = dem + 1;
                txtMaHD.Text = "HD00" + dem;
            }
            else
            {
                dem = dem + 1;
                txtMaHD.Text = "HD0" + dem;
            }

            flag = 1;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                hdb.MaHDB = txtMaHD.Text;
                hdb.MaKH = txtMaKH.Text;
                hdb.MaNV = cboTenNV.SelectedValue.ToString();
                hdb.NgayLap = dtpNgayLap.Value;
                hdb.TongTien = float.Parse(txtTongTT.Text);
                hdb.TrangThai = 1;
                bus.AddHD(hdb);

                string[] b = MaSP.Split(';');
                for (int i = 0; i < dgvDSSPChon.Rows.Count - 0; i++)
                {
                    string masp = b[i];
                    int soluong = int.Parse(dgvDSSPChon.Rows[i].Cells["soluong"].Value.ToString());
                    float dongia = float.Parse(dgvDSSPChon.Rows[i].Cells["dongia"].Value.ToString());
                    string khuyenmai = dgvDSSPChon.Rows[i].Cells["khuyenmai"].Value.ToString();
                    float thanhtien = float.Parse(dgvDSSPChon.Rows[i].Cells["thanhtien"].Value.ToString());
                    int slconlai = int.Parse(dgvDSSPChon.Rows[i].Cells["slconlai"].Value.ToString());
                    cthd.MaHDB = txtMaHD.Text;
                    cthd.MaSP = masp;
                    cthd.SoLuong = soluong;
                    cthd.GiaSP = dongia;
                    cthd.KhuyenMai = khuyenmai;
                    cthd.ThanhTien = thanhtien;
                    cthd.TrangThai = 1;
                    sp.MaSP = masp;
                    sp.SL = slconlai;
                    bus.CapNhatSLTon(sp);
                    bus.AddCTHD(cthd);
                }
                MessageBox.Show("Thanh Toán Thành Công");
                flag = 0;
            }
        }

        private void txtTienKhachDua_TextChange(object sender, EventArgs e)
        {
            try
            {
                decimal TienThua = 0;
                TienThua = decimal.Parse(txtTienKhachDua.Text) - decimal.Parse(txtTongTT.Text);
                txtTienThoiLai.Text = TienThua.ToString();
                txtTienThoiLai.Text = string.Format("{0:#,##0}", float.Parse(txtTienThoiLai.Text));

            }
            catch
            {

            }
        }
    }
}
