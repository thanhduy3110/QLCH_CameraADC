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
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }

        HoaDonNhap_BUS bus = new HoaDonNhap_BUS();
        HoaDonNhap hdn = new HoaDonNhap();
        CTHD_Nhap cthdn = new CTHD_Nhap();
        SanPham_BUS bus_sp = new SanPham_BUS();
        SanPham sp = new SanPham();

        int flag = 0;
        bool addnew = false;

        public void HienThiSanPham()
        {
            cboTenSP.DataSource = bus.GetData("");
            cboTenSP.DisplayMember = "TenSP";
            cboTenSP.ValueMember = "MaSP";
        }

        public void HienThiNhanVien()
        {
            cboTenNV.DataSource = bus.GetNhanVien("Select MaNV,HoTen From NhanVien Where MaNV='NV001'");
            cboTenNV.DisplayMember = "HoTen";
            cboTenNV.ValueMember = "MaNV";
        }

        public void HienThiNCC()
        {
            cboTenNCC.DataSource = bus.GetNCC("");
            cboTenNCC.DisplayMember = "TenNCC";
            cboTenNCC.ValueMember = "MaNCC";
        }

        public void HienThiHoaDonN()
        {
            dgvDSHD.DataSource = bus.HienThiHDN("");
        }

        public void HienThiCTHD()
        {
            dgvDSCTHD.DataSource = bus.HienThiCTHDNH("select TenSP,TenNCC,CTHD.SoLuong,CTHD.GiaNhap,CTHD.ThanhTien,CTHD.GhiChu,CTHD.TrangThai,CTHD.MaNCC from CTHD_Nhap CTHD,NhaCungCap NCC,SanPham SP where CTHD.MaSP=SP.MaSP and CTHD.MaNCC=NCC.MaNCC and MaHDN='" + txtMaHD.Text + "' ");
        }

        public void ClearTexBox()
        {
            txtMaHD.Clear();
            txtTongTien.Clear();
            txtSoLuong.Clear();
            txtGiaNhap.Clear();
            txtThanhTien.Clear();
            rtxtGhiChu.Clear();
        }

        public void TongTienSP()
        {
            decimal sum = 0;
            for (int i = 0; i < dgvDSCTHD.Rows.Count; ++i)
            {
                sum += decimal.Parse(dgvDSCTHD.Rows[i].Cells["ThanhTien"].Value.ToString());
            }
            txtTongTien.Text = sum.ToString();
            txtTongTien.Text = string.Format("{0:#,##0}", decimal.Parse(txtTongTien.Text));
        }
        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            ClearTexBox();
            int dem = bus.PhatSinhMa("").Rows.Count;
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

        public string MaSP = "";
        int SoLuongTon;
        int SoLuongConLai;


        private void Add_Datagrid(string tensp, string tenncc,int soluong, decimal dongia, decimal thanhtien,string ghichu, int soluongcuakho,string mancc)
        {
            try
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvDSCTHD);
                newRow.Cells[0].Value = tensp;
                newRow.Cells[1].Value = tenncc;
                newRow.Cells[2].Value = soluong;
                newRow.Cells[3].Value = dongia;
                newRow.Cells[4].Value = thanhtien;
                newRow.Cells[5].Value = ghichu;
                newRow.Cells[6].Value = soluongcuakho;
                newRow.Cells[7].Value = mancc;
                dgvDSCTHD.Rows.Add(newRow);
            }
            catch
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int KiemTra = 0;
            int vitri = 0;
            decimal KM = 0;
            decimal tt = 0;
            DataTable DSSP = bus.LayDSSP("select * From SanPham Where TenSP='" + cboTenSP.Text + "'");
            if (DSSP.Rows.Count > 0)
            {
                try
                {
                    if (cboTenSP.Text == DSSP.Rows[0]["TenSP"].ToString())
                    {
                        SoLuongTon = int.Parse(DSSP.Rows[0]["SL"].ToString());
                    }
                    else
                    {

                    }
                    SoLuongConLai = SoLuongTon + int.Parse(txtSoLuong.Text);
                }
                catch
                {

                }
            }

            
            tt = decimal.Parse(txtGiaNhap.Text) * int.Parse(txtSoLuong.Text);
            txtThanhTien.Text = tt.ToString();
            txtThanhTien.Text = string.Format("{0:#,##0}", double.Parse(txtThanhTien.Text));


            for (int i = 0; i < dgvDSCTHD.Rows.Count - 0; i++)
            {
                if (cboTenSP.Text == dgvDSCTHD.Rows[i].Cells["tensp"].Value.ToString())
                {
                    KiemTra = 1;
                    vitri = i;
                    break;
                }
            }

            if (KiemTra == 1)
            {
                int SL = int.Parse(txtSoLuong.Text) + int.Parse(dgvDSCTHD.Rows[vitri].Cells["soluong"].Value.ToString());
                dgvDSCTHD.Rows[vitri].Cells["soluong"].Value = SL.ToString();
                //decimal KMM = decimal.Parse(dataGridViewCTHDNH.Rows[vitri].Cells["KhuyenMai"].Value.ToString()) + KM;
                //dataGridViewCTHDNH.Rows[vitri].Cells["KhuyenMai"].Value = KMM.ToString("0,00");
                //int SLTonMoi = int.Parse(dgvDSCTHD.Rows[vitri].Cells["SLConLai"].Value.ToString()) + int.Parse(txtSoLuong.Text);
                //dgvDSCTHD.Rows[vitri].Cells["SLConLai"].Value = SLTonMoi.ToString();
                decimal ThanhTienMoi = tt + decimal.Parse(dgvDSCTHD.Rows[vitri].Cells["ThanhTien"].Value.ToString());
                dgvDSCTHD.Rows[vitri].Cells["ThanhTien"].Value = ThanhTienMoi.ToString();
            }
            else
            {
                MaSP += cboTenSP.SelectedValue.ToString() + ";";
                //object[] t = { comboBoxTenLK.Text, textBoxSoLuong.Text, textBoxDonGia.Text, KM.ToString(), labelThanhTien.Text, SoLuongConLai };
                //dataGridViewCTHDNH.Rows.Add(t);
                Add_Datagrid(cboTenSP.Text,cboTenNCC.Text, int.Parse(txtSoLuong.Text), decimal.Parse(txtGiaNhap.Text),  decimal.Parse(txtThanhTien.Text), rtxtGhiChu.Text, SoLuongConLai,cboTenNCC.SelectedValue.ToString());
            }
            TongTienSP();
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            HienThiSanPham();
            HienThiNhanVien();
            HienThiNCC();
            HienThiHoaDonN();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(flag==1)
            {
                hdn.MaHDN = txtMaHD.Text;
                hdn.MaNV = cboTenNV.SelectedValue.ToString();
                hdn.NgayLap = dtpNgayLap.Value;
                hdn.TongTien = float.Parse(txtTongTien.Text);
                hdn.TrangThai = 1;
                bus.AddHoaDon(hdn);
                string[] b = MaSP.Split(';');
                for (int i = 0; i < dgvDSCTHD.Rows.Count - 0; i++)
                {
                    string masp = b[i];
                    int soluong = int.Parse(dgvDSCTHD.Rows[i].Cells["SoLuong"].Value.ToString());
                    float gianhap = float.Parse(dgvDSCTHD.Rows[i].Cells["GiaNhap"].Value.ToString());
                    float thanhtien = float.Parse(dgvDSCTHD.Rows[i].Cells["ThanhTien"].Value.ToString());
                    string mancc = dgvDSCTHD.Rows[i].Cells["mancc"].Value.ToString();
                    cthdn.MaHDN = txtMaHD.Text;
                    cthdn.MaSP = masp;
                    cthdn.SoLuong = soluong;
                    cthdn.GiaNhap = gianhap;
                    cthdn.MaNCC = mancc;
                    cthdn.ThanhTien = thanhtien;
                    cthdn.TrangThai = 1;
                    //LK.MaLK = malk;
                    //LK.SoLuongTon = SoLuongKho;
                    //LK.DonGia = dongia;
                    //bus.CapNhatSLKho(LK);
                    bus.AddCTHD(cthdn);
                }
                MessageBox.Show("Tạo Hóa Đơn Thành Công ");
                HienThiHoaDonN();
                HienThiCTHD();

            }    
        }
    }
}
