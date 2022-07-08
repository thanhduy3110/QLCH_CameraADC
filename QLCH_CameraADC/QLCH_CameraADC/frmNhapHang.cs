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
        public string sTenNV;
        public string sMaNV;
        public frmNhapHang(string TenNV, string MaNV)
        {
            InitializeComponent();
            this.sTenNV = TenNV;
            this.sMaNV = MaNV;

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
            tensp.DataSource = bus.GetData("");
            tensp.DisplayMember = "TenSP";
            tensp.ValueMember = "MaSP";
        }

      

        public void HienThiNCC()
        {
            tenncc.DataSource = bus.GetNCC("");
            tenncc.DisplayMember = "TenNCC";
            tenncc.ValueMember = "MaNCC";
        }

       

       
      

        public void TongTienSP()
        {
            decimal sum = 0;
            for (int i = 0; i < dgvDSCTHD.Rows.Count-1; ++i)
            {
                sum += decimal.Parse(dgvDSCTHD.Rows[i].Cells["ThanhTien"].Value.ToString());
            }
            txtTongTien.Text = sum.ToString();
            txtTongTien.Text = string.Format("{0:#,##0}", decimal.Parse(txtTongTien.Text));


        }
        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
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
            btnLuu.Enabled = true;
            flag = 1;
        }

        public string MaSP = "";
        int SoLuongTon;
        int SoLuongConLai;


      

     

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            HienThiSanPham();
           
            HienThiNCC();

            lblTenNV.Text = this.sTenNV;
            txtMaHD.Enabled = false;
            txtTongTien.Enabled= false;
            btnLuu.Enabled = false;
            btnInHD.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                //for (int i = 0; i < dgvDSCTHD.Rows.Count - 1; i++)
                //{
                //    string masp1 = dgvDSCTHD.Rows[i].Cells["tensp"].Value.ToString();
                //    int sl1 = int.Parse(dgvDSCTHD.Rows[i].Cells["soluong"].Value.ToString());
                //    for (int j = i + 1; j < dgvDSCTHD.Rows.Count - 1; j++)
                //    {
                //        string masp2 = dgvDSCTHD.Rows[j].Cells["tensp"].Value.ToString();
                //        int sl2 = int.Parse(dgvDSCTHD.Rows[j].Cells["soluong"].Value.ToString());
                //        if (masp1 == masp2)
                //        {
                //            dgvDSCTHD.Rows[i].Cells["soluong"].Value = sl1 + sl2;
                //            dgvDSCTHD.Rows.RemoveAt(j);
                //        }

                //    }


                //}
               


           

                hdn.MaHDN = txtMaHD.Text;
                hdn.MaNV = this.sMaNV;
                hdn.NgayLap = dtpNgayLap.Value;
                hdn.TongTien = float.Parse(txtTongTien.Text);
                hdn.TrangThai = 1;
                bus.AddHoaDon(hdn);


                for (int i = 0; i < dgvDSCTHD.Rows.Count - 1; i++)
                {
                    string masp = dgvDSCTHD.Rows[i].Cells["tensp"].Value.ToString();
                    int soluong = int.Parse(dgvDSCTHD.Rows[i].Cells["soluong"].Value.ToString());
                    float gianhap = float.Parse(dgvDSCTHD.Rows[i].Cells["gianhap"].Value.ToString());
                    string mancc = dgvDSCTHD.Rows[i].Cells["tenncc"].Value.ToString();
                    float thanhtien = float.Parse(dgvDSCTHD.Rows[i].Cells["thanhtien"].Value.ToString());
                    string ghichu = dgvDSCTHD.Rows[i].Cells["ghichu"].Value.ToString();
                    DataTable DSSP = bus.LayDSSP("Select * From SanPham Where MaSP='" + masp + "'");

                    int slconlai = int.Parse(DSSP.Rows[0]["SL"].ToString()) + soluong;
                    cthdn.MaHDN = txtMaHD.Text;
                    cthdn.MaSP = masp;
                    cthdn.MaNCC = mancc;
                    cthdn.SoLuong = soluong;
                    cthdn.GiaNhap = gianhap;
                    cthdn.GhiChu = ghichu;
                    cthdn.ThanhTien = thanhtien;
                    cthdn.TrangThai = 1;
                    sp.MaSP = masp;
                    sp.SL = slconlai;
                    bus.CapNhatSLTon(sp);
                    bus.AddCTHD(cthdn);

                }
                btnInHD.Enabled = true;
                flag = 0;

            }
        }

        private void dgvDSCTHD_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            double TongTien = 0;
            if (dgvDSCTHD.Rows[e.RowIndex].Cells["tensp"].Value?.ToString() == null|| dgvDSCTHD.Rows[e.RowIndex].Cells["tenncc"].Value?.ToString() == null)
            {
                return;
            }
            else
            {
                int soluong = int.Parse(dgvDSCTHD.Rows[e.RowIndex].Cells["soluong"].Value.ToString());
                int gianhap = int.Parse(dgvDSCTHD.Rows[e.RowIndex].Cells["gianhap"].Value.ToString());
                dgvDSCTHD.Rows[e.RowIndex].Cells["thanhtien"].Value = soluong * gianhap;

                if(dgvDSCTHD.Rows[e.RowIndex].Cells["ghichu"].Value?.ToString() == null)
                {
                    dgvDSCTHD.Rows[e.RowIndex].Cells["ghichu"].Value = "không có";
                }    

                for (int i = 0; i < dgvDSCTHD.Rows.Count - 1; i++)
                {
                    int sl = int.Parse(dgvDSCTHD.Rows[i].Cells["soluong"].Value.ToString());
                    int gia = int.Parse(dgvDSCTHD.Rows[i].Cells["gianhap"].Value.ToString());
                    double thanhtien = sl * gia;
                    TongTien = TongTien + thanhtien;
                    txtTongTien.Text = TongTien.ToString();
                }
               

            }
            }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            frmInHD_Nhap inHD = new frmInHD_Nhap(this.sMaNV, txtMaHD.Text);
            inHD.Show();
        }
    }
}
