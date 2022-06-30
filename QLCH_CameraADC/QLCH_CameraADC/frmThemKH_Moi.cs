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
    public partial class frmThemKH_Moi : Form
    {
        public frmThemKH_Moi()
        {
            InitializeComponent();
        }
        public delegate void TruyenCHoCTHD_Nhap(string makh, string tenkh, string sdt);
        public TruyenCHoCTHD_Nhap truyenData;

        KhachHang_BUS kh_bus = new KhachHang_BUS();
        HoaDonBan_BUS bus = new HoaDonBan_BUS();
        KhachHang kh = new KhachHang();
        int GT;
        string makh,tenkh,sdt;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThemKH_Moi_Load(object sender, EventArgs e)
        {
            txtTenKH.ReadOnly = true;
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

                        tenkh = DSKH.Rows[0]["HoTen"].ToString();

                        makh = DSKH.Rows[0]["MaKH"].ToString();

                        sdt = DSKH.Rows[0]["SDT"].ToString();

                        truyenData(makh, tenkh, sdt);

                        this.Close();
                    } 
                }
                else
                {
                    txtTenKH.Clear();
                    txtSDT.Clear();
                    if (MessageBox.Show("Không tìm thấy khách hàng, bạn có muốn thêm khách hàng mới", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int dem = kh_bus.GetTong("").Rows.Count;
                        if (dem == 0)
                        {
                            makh = "KH001";
                        }
                        else if (dem < 10)
                        {
                            dem = dem + 1;
                            makh = "KH00" + dem;
                        }
                        else
                        {
                            dem = dem + 1;
                            makh = "KH0" + dem;
                        }

                    }
                  
                  
                }
            }
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
                        kh.MaKH = makh;
                        kh.HoTen = txtTenKH.Text;
                        tenkh = txtTenKH.Text;
                        kh.SDT = txtSDT.Text;
                        sdt= txtSDT.Text;
                        kh.GioiTinh = GT;
                        kh.GhiChu = rtxtGhiChu.Text;
                        kh.TrangThai = 1;
                        kh_bus.AddData(kh);
                        truyenData(makh, tenkh, sdt);
                        this.Close();
                    }
                }
                catch
                {

                }
            }
        }
    }
}
