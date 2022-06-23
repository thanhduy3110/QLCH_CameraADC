﻿using System;
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
        int flag;
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

        public void HienThiLoaiNV()
        {
            cboLoaiNV.DataSource = lnv.GetData("");
            cboLoaiNV.DisplayMember = "TenLoaiNV";
            cboLoaiNV.ValueMember = "MaLoaiNV";
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
            if (flag == 0)
            {
                clear();
                int dem = bus.GetTong("").Rows.Count;
                if (dem == 0)
                {
                    txtMaNV.Text = "NV01";
                }
                else if (dem < 10)
                {
                    dem = dem + 1;
                    txtMaNV.Text = "NV0" + dem;
                }
                else
                {
                    dem = dem + 1;
                    txtMaNV.Text = "NV" + dem;
                }
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
                nv.MatKhau = txtMatKhau.Text;
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

                nv.TrangThai = 1;
                bus.AddData(nv);
                MessageBox.Show("Lưu thành công");
                LoadData();
                flag = 0;
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
            try
            {
                DataGridViewRow row = dgvDSNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["manv"].Value.ToString();
                cboLoaiNV.Text = row.Cells["tenloainv"].Value.ToString();
                txtSDT.Text = row.Cells["sdt"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtMatKhau.Text = row.Cells["matkhau"].Value.ToString();
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
                nv.MatKhau = txtMatKhau.Text;
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

                nv.TrangThai = 1;
                bus.EditData(nv);
                MessageBox.Show("Sửa thành công");
                LoadData();
                flag = 0;
            }
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            HienThiLoaiNV();
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
        }
}
