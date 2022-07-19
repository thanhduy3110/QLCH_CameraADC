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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
            
        }

        NhanVien_BUS bus = new NhanVien_BUS();
        NhanVien nv = new NhanVien();
        LoaiNV_BUS lnv = new LoaiNV_BUS();
        int flag=0;
        int GT;

        public void LoadData()
        {
            dgvDSNhanVien.DataSource = bus.GetData("");
        }

        public void clear()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtCMND.Clear();
            rtxtDiaChi.Clear();
            txtMatKhau.Clear();
            pichHinh.Controls.Clear();
        }

        public  void HienThiTextbox(Boolean t)
        {
            txtHoTen.ReadOnly = t;
            txtSDT.ReadOnly = t;
            txtCMND.ReadOnly = t;
            txtEmail.ReadOnly = t;
            txtMatKhau.ReadOnly = t;
            rtxtDiaChi.ReadOnly = t;
        }

        public void xulychucnang(Boolean b1)
        {
            btnThem.Enabled = !b1;
            btnHuy.Enabled = b1;
            btnChonAnh.Enabled = b1;
            btnSua.Enabled = b1;
            btnXoa.Enabled = b1;
        }
        public void xulychucnang1(Boolean b1)
        {
            btnThem.Enabled = b1;
            btnSua.Enabled = b1;
            btnXoa.Enabled = b1;
            btnHuy.Enabled = !b1;
            btnChonAnh.Enabled = !b1;
        }

        public void xulychucnangthem(Boolean b1)
        {
            btnThem.Enabled = b1;
            btnChonAnh.Enabled = b1;
            btnHuy.Enabled = b1;
            btnSua.Enabled = !b1;
            btnXoa.Enabled = !b1;
        }

        public void xulychucnangsua(Boolean b1)
        {
            btnThem.Enabled = !b1;
            btnSua.Enabled = b1;
            btnChonAnh.Enabled = b1;
            btnHuy.Enabled = b1;
            btnXoa.Enabled = !b1;
        }

        public void HienThiLoaiNV()
        {
            cboLoaiNV.DataSource = lnv.GetData("");
            cboLoaiNV.DisplayMember = "TenLoaiNV";
            cboLoaiNV.ValueMember = "MaLoaiNV";
        }

        private String GetMD5(string txt)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }

        String TenHinh = "";

        public void LuuAnh()
        {
            try
            {
                File.Copy(TenHinh, Application.StartupPath + @"\ImageNV\" + Path.GetFileName(pichHinh.ImageLocation));
            }
            catch
            {

            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            HienThiLoaiNV();
            if (flag == 0)
            {
                clear();
                HienThiTextbox(false);
                int dem = bus.GetTong("").Rows.Count;
                if (dem == 0)
                {
                    txtMaNV.Text = "NV001";
                }
                else if (dem < 9)
                {
                    dem = dem + 1;
                    txtMaNV.Text = "NV00" + dem;
                }
                else
                {
                    dem = dem + 1;
                    txtMaNV.Text = "NV0" + dem;
                }
                xulychucnangthem(true);
                flag = 1;
            }
            else if (flag == 1)
            {
                nv.MaNV = txtMaNV.Text;
                nv.HoTen = txtHoTen.Text;
                nv.SDT = txtSDT.Text;
                nv.Email = txtEmail.Text;
                nv.CMND = int.Parse(txtCMND.Text);
                nv.DiaChi = rtxtDiaChi.Text;
                nv.NgaySinh = dtpNgaySinh.Value.Date;
                nv.MatKhau = GetMD5(txtMatKhau.Text);
                nv.MaLoaiNV = cboLoaiNV.SelectedValue.ToString();

                if (radioNam.Checked == true)
                {
                    GT = 1;
                }
                else if (radioNu.Checked == true)
                {
                    GT = 0;
                }

                nv.GioiTinh = GT;
                if (pichHinh.Image == null)
                {
                    nv.HinhAnh = "Không";
                }
                else
                {
                    nv.HinhAnh = Path.GetFileName(pichHinh.ImageLocation);
                    LuuAnh();
                }
                //Bẫy lỗi
                if (txtHoTen.Text == "")
                {
                    MessageBox.Show("? Tên nhân viên không thể để trống");
                    return;
                }
                if (txtCMND.Text == "")
                {
                    MessageBox.Show("? CMND nhân viên không thể để trống");
                    return;
                }
                if (txtSDT.Text == "")
                {
                    MessageBox.Show("? Số điện thoại nhân viên không thể để trống");
                    return;
                }
                if (txtMatKhau.Text == "")
                {
                    MessageBox.Show("? Mật Khẩu nhân viên không thể để trống");
                    return;
                }
                for (int i = 0; i < dgvDSNhanVien.Rows.Count - 0; i++)
                {
                    if (txtSDT.Text == dgvDSNhanVien.Rows[i].Cells["sdt"].Value.ToString())
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại");
                        return;
                    }
                }
                for (int i = 0; i < dgvDSNhanVien.Rows.Count - 0; i++)
                {
                    if (txtCMND.Text == dgvDSNhanVien.Rows[i].Cells["CMND"].Value.ToString())
                    {
                        MessageBox.Show("CMND đã tồn tại");
                        return;
                    }
                }
                //Két thúc bẫy lỗi
                nv.TrangThai = 1;
                bus.AddData(nv);
                MessageBox.Show("Lưu thành công");
                HienThiTextbox(true);
                LoadData();
                flag = 0;
                txtMatKhau.Text="";
                xulychucnang1(true);
            }
        }

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

        private void dgvDSNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HienThiLoaiNV();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            try
            {
                DataGridViewRow row = dgvDSNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["manv"].Value.ToString();
                cboLoaiNV.Text = row.Cells["tenloainv"].Value.ToString();
                txtSDT.Text = row.Cells["sdt"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                
                rtxtDiaChi.Text = row.Cells["diachi"].Value.ToString();
                txtHoTen.Text = row.Cells["hoten"].Value.ToString();
                dtpNgaySinh.Text = row.Cells["ngaysinh"].Value.ToString();
                txtCMND.Text = row.Cells["cmnd"].Value.ToString();

                string GT = row.Cells["gioitinh"].Value.ToString();
                if (GT == "Nam")
                {
                    radioNam.Checked = true;
                }
                else if (GT == "Nữ")
                {
                    radioNu.Checked = true;
                }

                //load anh
                pichHinh.Controls.Clear();
                string[] b = row.Cells["hinhanh"].Value.ToString().Split(';');

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
                        Bitmap a = new Bitmap(Application.StartupPath + @"\ImageNV\" + b[i]);
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
                HienThiTextbox(false);
                xulychucnangsua(true);
                flag = 1;
            }
            else if (flag == 1)
            {
                int vitri = dgvDSNhanVien.CurrentCell.RowIndex;
                int KiemTra = 0;
                if (TenHinh == dgvDSNhanVien.Rows[vitri].Cells["hinhanh"].Value.ToString())
                {
                    // Bỏ Qua
                    KiemTra = 1;
                }

                nv.MaNV = txtMaNV.Text;
                nv.HoTen = txtHoTen.Text;
                nv.SDT = txtSDT.Text;
                nv.Email = txtEmail.Text;
                nv.CMND = int.Parse(txtCMND.Text);
                nv.DiaChi = rtxtDiaChi.Text;
                nv.NgaySinh = dtpNgaySinh.Value.Date;
                if (txtMatKhau.Text == "")
                {
                    nv.MatKhau = dgvDSNhanVien.Rows[vitri].Cells["matkhau"].Value.ToString();
                }
                else
                {
                    nv.MatKhau = txtMatKhau.Text;
                }
               
                nv.MaLoaiNV = cboLoaiNV.SelectedValue.ToString();

                if (radioNam.Checked == true)
                {
                    GT = 1;
                }
                else if (radioNu.Checked == true)
                {
                    GT = 0;
                }

                nv.GioiTinh = GT;
                if (KiemTra == 1)
                {
                    nv.HinhAnh = TenHinh;
                }
                else
                {
                    nv.HinhAnh = Path.GetFileName(pichHinh.ImageLocation);
                    LuuAnh();
                }
                //Bẫy lỗi
                if (txtHoTen.Text == "")
                {
                    MessageBox.Show("? Tên nhân viên không thể để trống");
                    return;
                }
                if (txtCMND.Text == "")
                {
                    MessageBox.Show("? CMND nhân viên không thể để trống");
                    return;
                }
                if (txtSDT.Text == "")
                {
                    MessageBox.Show("? Số điện thoại nhân viên không thể để trống");
                    return;
                }
              
                nv.TrangThai = 1;
                bus.EditData(nv);
                MessageBox.Show("Sửa thành công");
                HienThiTextbox(true);
                LoadData();
                xulychucnang1(true);
                flag = 0;
            }
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            txtMaNV.Enabled = false;
            xulychucnang(false);
            HienThiTextbox(true);
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //DialogResult KQ = MessageBox.Show("Bạn có muốn xóa hay không ?", "Thông Báo !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (KQ == DialogResult.Yes)
            //{
            //    if (cboChucVu.SelectedValue.ToString() == "CV01")
            //    {
            //        MessageBox.Show("Không thể xóa");
            //        return;
            //    }
            //    else
            //    {
            //        nv.MaNV = txtMaNV.Text;
            //        bus.DeleteData(nv);
            //        MessageBox.Show("Xóa Nhân Viên Thành Công");
            //        xulychucnang(true, false, false);
            //        Clear();
            //        xulytextbox(false, true);
            //    }
            //    Display();
            //}


            DialogResult KQ = MessageBox.Show("Bạn có muốn xóa hay không ?", "Thông Báo !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (KQ == DialogResult.Yes)
            {
                nv.MaNV = txtMaNV.Text;
                bus.DeleteData(nv);
                MessageBox.Show("Xóa Nhân Viên Thành Công");
                clear();
                
            }
            LoadData();

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            flag = 0;
            clear();
            HienThiTextbox(true);
            xulychucnang(false);
        }

        //Tìm kiếm nhân viên
        private void txtTimKiem_TextChange(object sender, EventArgs e)
        {
            string Condition = txtTimKiem.Text;
            dgvDSNhanVien.DataSource = bus.TimKiem(Condition);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }
    }
}
