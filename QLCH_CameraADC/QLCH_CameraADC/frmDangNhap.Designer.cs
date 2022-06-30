namespace QLCH_CameraADC
{
    partial class frmDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnThoat = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnDangNhap = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản lý cửa hàng Camera ADC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 323);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 28);
            this.label3.TabIndex = 20;
            this.label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 244);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 28);
            this.label2.TabIndex = 21;
            this.label2.Text = "Tên đăng nhập";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(25, 358);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatKhau.Multiline = true;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(352, 36);
            this.txtMatKhau.TabIndex = 16;
            this.txtMatKhau.Text = "123456";
            this.txtMatKhau.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTenDN
            // 
            this.txtTenDN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDN.Location = new System.Drawing.Point(25, 277);
            this.txtTenDN.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenDN.Multiline = true;
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(352, 36);
            this.txtTenDN.TabIndex = 15;
            this.txtTenDN.Text = "NV001";
            this.txtTenDN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QLCH_CameraADC.Properties.Resources.HinhADC;
            this.pictureBox1.Location = new System.Drawing.Point(6, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(398, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.AllowAnimations = true;
            this.btnThoat.AllowMouseEffects = true;
            this.btnThoat.AllowToggling = false;
            this.btnThoat.AnimationSpeed = 200;
            this.btnThoat.AutoGenerateColors = false;
            this.btnThoat.AutoRoundBorders = false;
            this.btnThoat.AutoSizeLeftIcon = true;
            this.btnThoat.AutoSizeRightIcon = true;
            this.btnThoat.BackColor = System.Drawing.Color.Transparent;
            this.btnThoat.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(163)))), ((int)(((byte)(140)))));
            this.btnThoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.BackgroundImage")));
            this.btnThoat.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnThoat.ButtonText = "";
            this.btnThoat.ButtonTextMarginLeft = 0;
            this.btnThoat.ColorContrastOnClick = 45;
            this.btnThoat.ColorContrastOnHover = 45;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnThoat.CustomizableEdges = borderEdges1;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnThoat.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnThoat.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnThoat.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnThoat.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.IconLeftAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnThoat.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnThoat.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnThoat.IconMarginLeft = 11;
            this.btnThoat.IconPadding = 10;
            this.btnThoat.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnThoat.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnThoat.IconSize = 25;
            this.btnThoat.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(163)))), ((int)(((byte)(140)))));
            this.btnThoat.IdleBorderRadius = 1;
            this.btnThoat.IdleBorderThickness = 1;
            this.btnThoat.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(163)))), ((int)(((byte)(140)))));
            this.btnThoat.IdleIconLeftImage = global::QLCH_CameraADC.Properties.Resources.cancel1;
            this.btnThoat.IdleIconRightImage = null;
            this.btnThoat.IndicateFocus = false;
            this.btnThoat.Location = new System.Drawing.Point(228, 420);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnThoat.OnDisabledState.BorderRadius = 1;
            this.btnThoat.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnThoat.OnDisabledState.BorderThickness = 1;
            this.btnThoat.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnThoat.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnThoat.OnDisabledState.IconLeftImage = null;
            this.btnThoat.OnDisabledState.IconRightImage = null;
            this.btnThoat.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnThoat.onHoverState.BorderRadius = 1;
            this.btnThoat.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnThoat.onHoverState.BorderThickness = 1;
            this.btnThoat.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnThoat.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnThoat.onHoverState.IconLeftImage = null;
            this.btnThoat.onHoverState.IconRightImage = null;
            this.btnThoat.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(163)))), ((int)(((byte)(140)))));
            this.btnThoat.OnIdleState.BorderRadius = 1;
            this.btnThoat.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnThoat.OnIdleState.BorderThickness = 1;
            this.btnThoat.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(163)))), ((int)(((byte)(140)))));
            this.btnThoat.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnThoat.OnIdleState.IconLeftImage = global::QLCH_CameraADC.Properties.Resources.cancel1;
            this.btnThoat.OnIdleState.IconRightImage = null;
            this.btnThoat.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnThoat.OnPressedState.BorderRadius = 1;
            this.btnThoat.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnThoat.OnPressedState.BorderThickness = 1;
            this.btnThoat.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnThoat.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnThoat.OnPressedState.IconLeftImage = null;
            this.btnThoat.OnPressedState.IconRightImage = null;
            this.btnThoat.Size = new System.Drawing.Size(144, 76);
            this.btnThoat.TabIndex = 22;
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnThoat.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnThoat.TextMarginLeft = 0;
            this.btnThoat.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnThoat.UseDefaultRadiusAndThickness = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.AllowAnimations = true;
            this.btnDangNhap.AllowMouseEffects = true;
            this.btnDangNhap.AllowToggling = false;
            this.btnDangNhap.AnimationSpeed = 200;
            this.btnDangNhap.AutoGenerateColors = false;
            this.btnDangNhap.AutoRoundBorders = false;
            this.btnDangNhap.AutoSizeLeftIcon = true;
            this.btnDangNhap.AutoSizeRightIcon = true;
            this.btnDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.btnDangNhap.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(163)))), ((int)(((byte)(140)))));
            this.btnDangNhap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDangNhap.BackgroundImage")));
            this.btnDangNhap.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDangNhap.ButtonText = "";
            this.btnDangNhap.ButtonTextMarginLeft = 0;
            this.btnDangNhap.ColorContrastOnClick = 45;
            this.btnDangNhap.ColorContrastOnHover = 45;
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnDangNhap.CustomizableEdges = borderEdges2;
            this.btnDangNhap.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDangNhap.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDangNhap.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnDangNhap.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnDangNhap.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.IconLeftAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDangNhap.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnDangNhap.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnDangNhap.IconMarginLeft = 11;
            this.btnDangNhap.IconPadding = 10;
            this.btnDangNhap.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDangNhap.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnDangNhap.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnDangNhap.IconSize = 25;
            this.btnDangNhap.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(163)))), ((int)(((byte)(140)))));
            this.btnDangNhap.IdleBorderRadius = 1;
            this.btnDangNhap.IdleBorderThickness = 1;
            this.btnDangNhap.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(163)))), ((int)(((byte)(140)))));
            this.btnDangNhap.IdleIconLeftImage = global::QLCH_CameraADC.Properties.Resources.login1;
            this.btnDangNhap.IdleIconRightImage = null;
            this.btnDangNhap.IndicateFocus = false;
            this.btnDangNhap.Location = new System.Drawing.Point(27, 420);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDangNhap.OnDisabledState.BorderRadius = 1;
            this.btnDangNhap.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDangNhap.OnDisabledState.BorderThickness = 1;
            this.btnDangNhap.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnDangNhap.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnDangNhap.OnDisabledState.IconLeftImage = null;
            this.btnDangNhap.OnDisabledState.IconRightImage = null;
            this.btnDangNhap.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnDangNhap.onHoverState.BorderRadius = 1;
            this.btnDangNhap.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDangNhap.onHoverState.BorderThickness = 1;
            this.btnDangNhap.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnDangNhap.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.onHoverState.IconLeftImage = null;
            this.btnDangNhap.onHoverState.IconRightImage = null;
            this.btnDangNhap.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(163)))), ((int)(((byte)(140)))));
            this.btnDangNhap.OnIdleState.BorderRadius = 1;
            this.btnDangNhap.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDangNhap.OnIdleState.BorderThickness = 1;
            this.btnDangNhap.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(163)))), ((int)(((byte)(140)))));
            this.btnDangNhap.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.OnIdleState.IconLeftImage = global::QLCH_CameraADC.Properties.Resources.login1;
            this.btnDangNhap.OnIdleState.IconRightImage = null;
            this.btnDangNhap.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnDangNhap.OnPressedState.BorderRadius = 1;
            this.btnDangNhap.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDangNhap.OnPressedState.BorderThickness = 1;
            this.btnDangNhap.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnDangNhap.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.OnPressedState.IconLeftImage = null;
            this.btnDangNhap.OnPressedState.IconRightImage = null;
            this.btnDangNhap.Size = new System.Drawing.Size(144, 76);
            this.btnDangNhap.TabIndex = 22;
            this.btnDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDangNhap.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDangNhap.TextMarginLeft = 0;
            this.btnDangNhap.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnDangNhap.UseDefaultRadiusAndThickness = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(404, 515);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenDN);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDangNhap";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTenDN;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnDangNhap;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnThoat;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}