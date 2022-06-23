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
    public partial class frmTimKiemKH : Form
    {
        public frmTimKiemKH()
        {
            InitializeComponent();
        }
        public delegate void TruyenCHoCTHD_Nhap(string makh,string tenkh,string sdt);
        public TruyenCHoCTHD_Nhap truyenData;

        HoaDonBan_BUS bus = new HoaDonBan_BUS();

        string makh,tenkh,sdt;

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

                        truyenData(makh,tenkh,sdt);

                        this.Close();
                    }
                }
                else
                {
                    if (MessageBox.Show("Không tìm thấy khách hàng, bạn có muốn thêm khách hàng mới", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                       
                       
                    }

                }

            }
        }
    }
}
