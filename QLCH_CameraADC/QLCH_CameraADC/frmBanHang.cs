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

        public frmBanHang(string TenNV,string MaNV,string TenKH,string MaKH,string SDT)
        {
            InitializeComponent();
            this.sTenNV = TenNV;
            this.sMaNV = MaNV;
            txtTenKH.Text = TenKH;
            txtSDT.Text = SDT;
            maKH = MaKH;

        }


        public string sTenNV;
        public string sMaNV;
        string maKH;
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

       

        //public void OpenTimKiem()
        //{
        //    frmThemKH_Moi frmcon = new frmThemKH_Moi();
        //    frmcon.truyenData = new frmThemKH_Moi.TruyenCHoCTHD_Nhap(LoadDataTruyen);
        //    frmcon.ShowDialog();
        //}

      
        //public void LoadDataTruyen(string makh, string tenkh, string sdt)
        //{
        //    txtTenKH.Text = tenkh;
        //    txtSDT.Text = sdt;
        //    maKH = makh;
          
        //}

      



       

        public void HienThiSP()
        {
            tensp.DataSource = bus.GetTimKiemSP("select TenSP,MaSP From SanPham");
            tensp.DisplayMember = "TenSP";
            tensp.ValueMember = "MaSP";

           
            
        }



        //public void ThanhTienSanPham()
        //{
        //    float ThanhTien;
        //    //float ChietKhau;
        //    //ChietKhau = (int.Parse(txtKhuyenMai.Text) * float.Parse(txtDonGia.Text) * (((int)NumreicSL.Value)) / 100);
        //    ThanhTien = float.Parse(txtGiaSP.Text) * (((int)NumreicSL.Value));
        //    lblThanhTien.Text = ThanhTien.ToString();
        //    lblThanhTien.Text = string.Format("{0:#,##0}", float.Parse(lblThanhTien.Text));

        //}

     

       

      

        public void TongTienSP()
        {
            float sum = 0;
            for (int i = 0; i < dgvDSSPChon.Rows.Count-1; ++i)
            {
                sum += float.Parse(dgvDSSPChon.Rows[i].Cells["ThanhTien"].Value.ToString());
            }
            txtTongTien.Text = sum.ToString();
            txtTongTien.Text = string.Format("{0:#,##0}", float.Parse(txtTongTien.Text));
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
           
            HienThiSP();
            lblTenNV.Text = this.sTenNV;
            btnThanhToan.Enabled = false;
            btnInHDBan.Enabled = false;
            txtMaHD.Enabled=false;
        }

        int flag = 0;
      

        

        private void btnTaoPhieu_Click_1(object sender, EventArgs e)
        {
            if (flag == 0)
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
          
          
        }

        private void txtTienKhachDua_TextChange(object sender, EventArgs e)
        {
            try
            {
                decimal TienThua = 0;
                TienThua = decimal.Parse(txtTienKhachDua.Text) - decimal.Parse(txtTongTien.Text);
                if(TienThua>=0)
                {
                    btnThanhToan.Enabled = true;
                }    
                txtTienThoiLai.Text = TienThua.ToString();
                txtTienThoiLai.Text = string.Format("{0:#,##0}", float.Parse(txtTienThoiLai.Text));

            }
            catch
            {

            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(flag==1)
            {
               
              


                

                hdb.MaHDB = txtMaHD.Text;
                hdb.MaKH = maKH;
                hdb.MaNV = this.sMaNV;
                hdb.NgayLap = dtpNgayLap.Value;
                hdb.TongTien = float.Parse(txtTongTien.Text);
                hdb.TrangThai = 1;
                bus.AddHD(hdb);


                for (int i = 0; i < dgvDSSPChon.Rows.Count - 1; i++)
                {
                    string masp = dgvDSSPChon.Rows[i].Cells["tensp"].Value.ToString();
                    int soluong = int.Parse(dgvDSSPChon.Rows[i].Cells["soluong"].Value.ToString());
                    float dongia = float.Parse(dgvDSSPChon.Rows[i].Cells["dongia"].Value.ToString());
                    string khuyenmai = dgvDSSPChon.Rows[i].Cells["khuyenmai"].Value.ToString();
                    float thanhtien = float.Parse(dgvDSSPChon.Rows[i].Cells["thanhtien"].Value.ToString());
                    DataTable DSSP = bus.LaySP("Select * From SanPham Where MaSP='" + masp + "'");
                    int slconlai = int.Parse(DSSP.Rows[0]["SL"].ToString()) - soluong;
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
                flag = 0;
                btnInHDBan.Enabled = true;
            }



        }

        private void btnInHDBan_Click(object sender, EventArgs e)
        {
            frmInHD_Ban inHD = new frmInHD_Ban(this.sMaNV, txtMaHD.Text);
            inHD.Show();
        }

        private void dgvDSSPChon_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            double TongTien = 0;
            if (dgvDSSPChon.Rows[e.RowIndex].Cells["tensp"].Value?.ToString() == null)
            {
                return;
            }
            else
            {

                string masp = dgvDSSPChon.Rows[e.RowIndex].Cells["tensp"].Value.ToString();
                int sl = int.Parse(dgvDSSPChon.Rows[e.RowIndex].Cells["soluong"].Value.ToString());

                DataTable DSSP = bus.GetTimKiemSP("Select * from SanPham where MaSP='" + masp + "'");
                
                dgvDSSPChon.Rows[e.RowIndex].Cells["dongia"].Value = DSSP.Rows[0]["Gia"];
                dgvDSSPChon.Rows[e.RowIndex].Cells["khuyenmai"].Value = DSSP.Rows[0]["KhuyenMai"];
                int gia = int.Parse(dgvDSSPChon.Rows[e.RowIndex].Cells["dongia"].Value.ToString());
                dgvDSSPChon.Rows[e.RowIndex].Cells["thanhtien"].Value = sl * gia;


            }

            //for (int i = 0; i < dgvDSSPChon.Rows.Count - 1; i++)
            //{
            //    string masp1 = dgvDSSPChon.Rows[i].Cells["tensp"].Value.ToString();
            //    int sl1 = int.Parse(dgvDSSPChon.Rows[i].Cells["soluong"].Value.ToString());
            //    for (int j = i + 1; j < dgvDSSPChon.Rows.Count - 1; j++)
            //    {
            //        string masp2 = dgvDSSPChon.Rows[j].Cells["tensp"].Value.ToString();
            //        int sl2 = int.Parse(dgvDSSPChon.Rows[j].Cells["soluong"].Value.ToString());
            //        if (masp1 == masp2)
            //        {
            //            dgvDSSPChon.Rows[i].Cells["soluong"].Value = sl1 + sl2;
            //            dgvDSSPChon.Rows.RemoveAt(j);
            //        }

            //    }


            //}

            for (int i = 0; i < dgvDSSPChon.Rows.Count - 1; i++)
            {
                int sl = int.Parse(dgvDSSPChon.Rows[i].Cells["soluong"].Value.ToString());
                int gia = int.Parse(dgvDSSPChon.Rows[i].Cells["dongia"].Value.ToString());
                double thanhtien = sl * gia;
                TongTien = TongTien + thanhtien;
                txtTongTien.Text = TongTien.ToString();
            }
        }


















        //private void btnThemCT_Click_1(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < dgvDSSPChon.Rows.Count - 1; i++)
        //    {
        //        string masp= dgvDSSPChon.Rows[i].Cells["tensp"].Value.ToString();
        //        int soluong = int.Parse(dgvDSSPChon.Rows[i].Cells["soluong"].Value.ToString());
        //        float dongia = float.Parse(dgvDSSPChon.Rows[i].Cells["dongia"].Value.ToString());
        //        string khuyenmai = dgvDSSPChon.Rows[i].Cells["khuyenmai"].Value.ToString();
        //        float thanhtien = float.Parse(dgvDSSPChon.Rows[i].Cells["thanhtien"].Value.ToString());
        //        int slconlai = int.Parse(dgvDSSPChon.Rows[i].Cells["slconlai"].Value.ToString());
        //        cthd.MaHDB = txtMaHD.Text;
        //        cthd.MaSP = masp;
        //        cthd.SoLuong = soluong;
        //        cthd.GiaSP = dongia;
        //        cthd.KhuyenMai = khuyenmai;
        //        cthd.ThanhTien = thanhtien;
        //        cthd.TrangThai = 1;
        //        sp.MaSP = masp;
        //        sp.SL = slconlai;
        //        bus.CapNhatSLTon(sp);
        //        bus.AddCTHD(cthd);

        //    }

        //    TongTienSP();
        //}

        //private void dgvDSSPChon_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        //{

        //    string masp = dgvDSSPChon.Rows[e.RowIndex].Cells["tensp"].Value.ToString();
        //    int soluong = int.Parse(dgvDSSPChon.Rows[e.RowIndex].Cells["soluong"].Value.ToString());
        //    float dongia = float.Parse(dgvDSSPChon.Rows[e.RowIndex].Cells["dongia"].Value.ToString());

        //    string khuyenmai = dgvDSSPChon.Rows[e.RowIndex].Cells["khuyenmai"].Value.ToString();

        //    dgvDSSPChon.Rows[e.RowIndex].Cells["thanhtien"].Value = soluong * dongia;
        //    float thanhtien = float.Parse(dgvDSSPChon.Rows[e.RowIndex].Cells["thanhtien"].Value.ToString());


        //    //DataTable ds = bus.GetTimKiemSP("select TenSP,MaSP From SanPham");
        //    //for (int i = 0; i < ds.Rows.Count-1; i++)
        //    //{
        //    //    if (masp == ds.Rows[i]["MaSP"].ToString())
        //    //    {

        //    //        cthd.MaSP = masp;
        //    //        cthd.SoLuong = soluong;
        //    //        cthd.GiaSP = dongia;
        //    //        cthd.KhuyenMai = khuyenmai;
        //    //        cthd.ThanhTien = thanhtien;
        //    //        cthd.TrangThai = 1;
        //    //        bus.UpDateCTHD(cthd);
        //    //        return;
        //    //    }
        //    //}

        //    //cthd.MaHDB = txtMaHD.Text;
        //    //cthd.MaSP = masp;
        //    //cthd.SoLuong = soluong;
        //    //cthd.GiaSP = dongia;
        //    //cthd.KhuyenMai = khuyenmai;
        //    //cthd.ThanhTien = thanhtien;
        //    //cthd.TrangThai = 1;
        //    //bus.AddCTHD(cthd);
        //}












        //private void btnThanhToan_Click(object sender, EventArgs e)
        //{
        //    if (flag == 1)
        //    {
        //        hdb.MaHDB = txtMaHD.Text;
        //        hdb.MaKH = txtMaKH.Text;
        //        hdb.MaNV = cboTenNV.SelectedValue.ToString();
        //        hdb.NgayLap = dtpNgayLap.Value;
        //        hdb.TongTien = float.Parse(txtTongTT.Text);
        //        hdb.TrangThai = 1;
        //        bus.AddHD(hdb);

        //        string[] b = MaSP.Split(';');
        //        for (int i = 0; i < dgvDSSPChon.Rows.Count - 0; i++)
        //        {
        //            string masp = b[i];
        //            int soluong = int.Parse(dgvDSSPChon.Rows[i].Cells["soluong"].Value.ToString());
        //            float dongia = float.Parse(dgvDSSPChon.Rows[i].Cells["dongia"].Value.ToString());
        //            string khuyenmai = dgvDSSPChon.Rows[i].Cells["khuyenmai"].Value.ToString();
        //            float thanhtien = float.Parse(dgvDSSPChon.Rows[i].Cells["thanhtien"].Value.ToString());
        //            int slconlai = int.Parse(dgvDSSPChon.Rows[i].Cells["slconlai"].Value.ToString());
        //            cthd.MaHDB = txtMaHD.Text;
        //            cthd.MaSP = masp;
        //            cthd.SoLuong = soluong;
        //            cthd.GiaSP = dongia;
        //            cthd.KhuyenMai = khuyenmai;
        //            cthd.ThanhTien = thanhtien;
        //            cthd.TrangThai = 1;
        //            sp.MaSP = masp;
        //            sp.SL = slconlai;
        //            bus.CapNhatSLTon(sp);
        //            bus.AddCTHD(cthd);
        //        }
        //        MessageBox.Show("Thanh Toán Thành Công");
        //        flag = 0;
        //    }
        //}


    }
}
