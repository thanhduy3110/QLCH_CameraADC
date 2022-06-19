using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;


namespace QLCH_CameraADC
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }

        SanPham sp = new SanPham();
        SanPham_BUS bus = new SanPham_BUS();
        NhaCungCap_BUS ncc = new NhaCungCap_BUS();
        LoaiSP_BUS lsp = new LoaiSP_BUS();
        int flag = 0;
        public void LoadData()
        {
            dgvDSSanPham.DataSource = bus.GetData("");
        }

        public void clear()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtTenNSX.Clear();
            txtGia.Clear();
            rtxtMoTa.Clear();
            txtSoLuong.Clear();
            txtDVT.Clear();
            pichHinh.Controls.Clear();
        }

        public void HienThiLoaiSP()
        {
            cboMaLoaiSP.DataSource = lsp.GetData("");
            cboMaLoaiSP.DisplayMember = "TenLoaiSP";
            cboMaLoaiSP.ValueMember = "MaLoaiSP";
        }
        String TenHinh = "";
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            pichHinh.Controls.Clear();
            OpenFileDialog opFile = new OpenFileDialog();
            opFile.Title = "Select a Image";
            opFile.Filter = "Files|*.jpg;*.jpeg;*.png;....";
            if (opFile.ShowDialog() == DialogResult.OK)
            {
                TenHinh = opFile.FileName;
                pichHinh.Image = new Bitmap(opFile.FileName);
                pichHinh.ImageLocation = opFile.FileName;
                pichHinh.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        public void LuuAnh()
        {
            try
            {
                File.Copy(TenHinh, Application.StartupPath + @"\ImageSP\" + Path.GetFileName(pichHinh.ImageLocation));
            }
            catch
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                clear();
                int dem = bus.GetTong("").Rows.Count;
                if (dem == 0)
                {
                    txtMaSP.Text = "SP01";
                }
                else if (dem < 10)
                {
                    dem = dem + 1;
                    txtMaSP.Text = "SP0" + dem;
                }
                else
                {
                    dem = dem + 1;
                    txtMaSP.Text = "SP" + dem;
                }
                flag = 1;
            }
            else if (flag == 1)
            {
                sp.MaSP = txtMaSP.Text;
                sp.MaLoaiSP = txtMaSP.Text;
                sp.TenSP = txtTenSP.Text;
                sp.MaLoaiSP = cboMaLoaiSP.SelectedValue.ToString();
                sp.TenNSX=txtTenNSX.Text;
                sp.Gia = int.Parse(txtGia.Text);
                sp.SL = int.Parse(txtSoLuong.Text);
                sp.DVT = txtDVT.Text;
                sp.MoTa = rtxtMoTa.Text;
                sp.KhuyenMai = txtKhuyenMai.Text;

                if (pichHinh.Image == null)
                {
                    sp.Hinh = "Không";
                }
                else
                {
                    sp.Hinh = Path.GetFileName(pichHinh.ImageLocation);
                    LuuAnh();
                }

                sp.TrangThai = 1;
                bus.AddData(sp);
                MessageBox.Show("Thêm thành công");
                LoadData();
                flag = 0;
            }
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
            HienThiLoaiSP();
        }

        private void dgvDSSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvDSSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["masp"].Value.ToString();
                cboMaLoaiSP.Text = row.Cells["tenloaisp"].Value.ToString();
                txtTenSP.Text = row.Cells["tensp"].Value.ToString();
                txtTenNSX.Text = row.Cells["tennsx"].Value.ToString();
                txtGia.Text = row.Cells["gia"].Value.ToString();
                rtxtMoTa.Text = row.Cells["mota"].Value.ToString();
                txtKhuyenMai.Text = row.Cells["khuyenmai"].Value.ToString();
                txtSoLuong.Text = row.Cells["sl"].Value.ToString();
                txtDVT.Text = row.Cells["dvt"].Value.ToString();

                //load anh
               
                string[] b = row.Cells["hinh"].Value.ToString().Split(';');
                pichHinh.Controls.Clear();
                try
                {
                    int n;
                    if (b.Length == 1)
                        n = b.Length;
                    else
                        n = b.Length - 1;
                    for (int i = 0; i < n; i++)
                    {
                        PictureBox p = new PictureBox();
                        Size s = new Size(200, 200);
                        p.Size = s;
                        p.SizeMode = PictureBoxSizeMode.StretchImage;
                        pichHinh.Controls.Add(p);
                        Bitmap a = new Bitmap(Application.StartupPath + @"\ImageSP\" + b[i]);
                        p.Image = a;
                        TenHinh = b[i];
                    }
                }
                catch
                {
                    TenHinh = "Không";
                }
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
                int vitri = dgvDSSanPham.CurrentCell.RowIndex;
                int KiemTra = 0;
                if (TenHinh == dgvDSSanPham.Rows[vitri].Cells["hinh"].Value.ToString())
                {
                    // Bỏ Qua
                    KiemTra = 1;
                }
                sp.MaSP = txtMaSP.Text;
                sp.MaLoaiSP = txtMaSP.Text;
                sp.TenSP = txtTenSP.Text;
                sp.MaLoaiSP = cboMaLoaiSP.SelectedValue.ToString();
                sp.TenNSX = txtTenNSX.Text;
                sp.Gia = int.Parse(txtGia.Text);
                sp.SL = int.Parse(txtSoLuong.Text);
                sp.DVT = txtDVT.Text;
                sp.MoTa = rtxtMoTa.Text;
                sp.KhuyenMai = txtKhuyenMai.Text;
                if (KiemTra == 1)
                {
                    sp.Hinh = TenHinh;
                }
                else
                {
                    sp.Hinh = Path.GetFileName(pichHinh.ImageLocation);
                    LuuAnh();
                }

                sp.TrangThai = 1;
                bus.EditData(sp);
                LoadData();
                flag = 0;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult KQ = MessageBox.Show("Bạn có muốn xóa hay không ?", "Thông Báo !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (KQ == DialogResult.Yes)
            {
                sp.MaSP = txtMaSP.Text;
                bus.DeleteData(sp);
                MessageBox.Show("Xóa sản phẩm thành công");
                clear();

            }
            LoadData();
        }
    }
}
