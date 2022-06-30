namespace QLCH_CameraADC
{
    partial class frmThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKe));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXem = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.radioKHMuaNhieuNam = new System.Windows.Forms.RadioButton();
            this.radioKHMuaNhieuThang = new System.Windows.Forms.RadioButton();
            this.radioSPTonKho = new System.Windows.Forms.RadioButton();
            this.radioButKhanChiNam = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioBanNhieuMonth = new System.Windows.Forms.RadioButton();
            this.radioMuaNhieuYear = new System.Windows.Forms.RadioButton();
            this.radioBanNhieuYear = new System.Windows.Forms.RadioButton();
            this.radioMuaNhieuMonth = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvThongKe = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboloinhuan = new System.Windows.Forms.ComboBox();
            this.cboDoanhThu = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxChi = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1739, 50);
            this.label1.TabIndex = 5;
            this.label1.Text = "Quản lý thống kê";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 486);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Doanh Thu";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1739, 459);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnXem);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboNam);
            this.panel1.Controls.Add(this.cboThang);
            this.panel1.Controls.Add(this.radioKHMuaNhieuNam);
            this.panel1.Controls.Add(this.radioKHMuaNhieuThang);
            this.panel1.Controls.Add(this.radioSPTonKho);
            this.panel1.Controls.Add(this.radioButKhanChiNam);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.radioBanNhieuMonth);
            this.panel1.Controls.Add(this.radioMuaNhieuYear);
            this.panel1.Controls.Add(this.radioBanNhieuYear);
            this.panel1.Controls.Add(this.radioMuaNhieuMonth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1109, 436);
            this.panel1.TabIndex = 7;
            // 
            // btnXem
            // 
            this.btnXem.AllowAnimations = true;
            this.btnXem.AllowMouseEffects = true;
            this.btnXem.AllowToggling = false;
            this.btnXem.AnimationSpeed = 200;
            this.btnXem.AutoGenerateColors = false;
            this.btnXem.AutoRoundBorders = false;
            this.btnXem.AutoSizeLeftIcon = true;
            this.btnXem.AutoSizeRightIcon = true;
            this.btnXem.BackColor = System.Drawing.Color.Transparent;
            this.btnXem.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnXem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXem.BackgroundImage")));
            this.btnXem.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnXem.ButtonText = "Xem";
            this.btnXem.ButtonTextMarginLeft = 0;
            this.btnXem.ColorContrastOnClick = 45;
            this.btnXem.ColorContrastOnHover = 45;
            this.btnXem.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnXem.CustomizableEdges = borderEdges1;
            this.btnXem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnXem.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnXem.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnXem.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnXem.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXem.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnXem.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnXem.IconMarginLeft = 11;
            this.btnXem.IconPadding = 10;
            this.btnXem.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXem.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnXem.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnXem.IconSize = 25;
            this.btnXem.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnXem.IdleBorderRadius = 1;
            this.btnXem.IdleBorderThickness = 1;
            this.btnXem.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnXem.IdleIconLeftImage = null;
            this.btnXem.IdleIconRightImage = null;
            this.btnXem.IndicateFocus = false;
            this.btnXem.Location = new System.Drawing.Point(744, 372);
            this.btnXem.Name = "btnXem";
            this.btnXem.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnXem.OnDisabledState.BorderRadius = 1;
            this.btnXem.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnXem.OnDisabledState.BorderThickness = 1;
            this.btnXem.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnXem.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnXem.OnDisabledState.IconLeftImage = null;
            this.btnXem.OnDisabledState.IconRightImage = null;
            this.btnXem.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnXem.onHoverState.BorderRadius = 1;
            this.btnXem.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnXem.onHoverState.BorderThickness = 1;
            this.btnXem.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnXem.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnXem.onHoverState.IconLeftImage = null;
            this.btnXem.onHoverState.IconRightImage = null;
            this.btnXem.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnXem.OnIdleState.BorderRadius = 1;
            this.btnXem.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnXem.OnIdleState.BorderThickness = 1;
            this.btnXem.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnXem.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnXem.OnIdleState.IconLeftImage = null;
            this.btnXem.OnIdleState.IconRightImage = null;
            this.btnXem.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnXem.OnPressedState.BorderRadius = 1;
            this.btnXem.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnXem.OnPressedState.BorderThickness = 1;
            this.btnXem.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnXem.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnXem.OnPressedState.IconLeftImage = null;
            this.btnXem.OnPressedState.IconRightImage = null;
            this.btnXem.Size = new System.Drawing.Size(150, 39);
            this.btnXem.TabIndex = 29;
            this.btnXem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnXem.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnXem.TextMarginLeft = 0;
            this.btnXem.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnXem.UseDefaultRadiusAndThickness = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(408, 378);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 28);
            this.label5.TabIndex = 28;
            this.label5.Text = "Năm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(120, 378);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 28);
            this.label3.TabIndex = 27;
            this.label3.Text = "Tháng";
            // 
            // cboNam
            // 
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(482, 380);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(168, 31);
            this.cboNam.TabIndex = 26;
            // 
            // cboThang
            // 
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboThang.Location = new System.Drawing.Point(220, 380);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(153, 31);
            this.cboThang.TabIndex = 26;
            // 
            // radioKHMuaNhieuNam
            // 
            this.radioKHMuaNhieuNam.AutoSize = true;
            this.radioKHMuaNhieuNam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioKHMuaNhieuNam.Location = new System.Drawing.Point(657, 75);
            this.radioKHMuaNhieuNam.Margin = new System.Windows.Forms.Padding(4);
            this.radioKHMuaNhieuNam.Name = "radioKHMuaNhieuNam";
            this.radioKHMuaNhieuNam.Size = new System.Drawing.Size(328, 32);
            this.radioKHMuaNhieuNam.TabIndex = 20;
            this.radioKHMuaNhieuNam.TabStop = true;
            this.radioKHMuaNhieuNam.Text = "Khách hàng mua nhiều trong năm\r\n";
            this.radioKHMuaNhieuNam.UseVisualStyleBackColor = true;
            // 
            // radioKHMuaNhieuThang
            // 
            this.radioKHMuaNhieuThang.AutoSize = true;
            this.radioKHMuaNhieuThang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioKHMuaNhieuThang.Location = new System.Drawing.Point(657, 23);
            this.radioKHMuaNhieuThang.Margin = new System.Windows.Forms.Padding(4);
            this.radioKHMuaNhieuThang.Name = "radioKHMuaNhieuThang";
            this.radioKHMuaNhieuThang.Size = new System.Drawing.Size(341, 32);
            this.radioKHMuaNhieuThang.TabIndex = 21;
            this.radioKHMuaNhieuThang.TabStop = true;
            this.radioKHMuaNhieuThang.Text = "Khách hàng mua nhiều trong tháng";
            this.radioKHMuaNhieuThang.UseVisualStyleBackColor = true;
            // 
            // radioSPTonKho
            // 
            this.radioSPTonKho.AutoSize = true;
            this.radioSPTonKho.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSPTonKho.Location = new System.Drawing.Point(657, 190);
            this.radioSPTonKho.Margin = new System.Windows.Forms.Padding(4);
            this.radioSPTonKho.Name = "radioSPTonKho";
            this.radioSPTonKho.Size = new System.Drawing.Size(193, 32);
            this.radioSPTonKho.TabIndex = 23;
            this.radioSPTonKho.TabStop = true;
            this.radioSPTonKho.Text = "Sản phẩm tồn kho";
            this.radioSPTonKho.UseVisualStyleBackColor = true;
            // 
            // radioButKhanChiNam
            // 
            this.radioButKhanChiNam.AutoSize = true;
            this.radioButKhanChiNam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButKhanChiNam.Location = new System.Drawing.Point(657, 136);
            this.radioButKhanChiNam.Margin = new System.Windows.Forms.Padding(4);
            this.radioButKhanChiNam.Name = "radioButKhanChiNam";
            this.radioButKhanChiNam.Size = new System.Drawing.Size(158, 32);
            this.radioButKhanChiNam.TabIndex = 24;
            this.radioButKhanChiNam.TabStop = true;
            this.radioButKhanChiNam.Text = "Xem lợi nhuận";
            this.radioButKhanChiNam.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(546, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 337);
            this.label2.TabIndex = 19;
            // 
            // radioBanNhieuMonth
            // 
            this.radioBanNhieuMonth.AutoSize = true;
            this.radioBanNhieuMonth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBanNhieuMonth.Location = new System.Drawing.Point(61, 23);
            this.radioBanNhieuMonth.Margin = new System.Windows.Forms.Padding(4);
            this.radioBanNhieuMonth.Name = "radioBanNhieuMonth";
            this.radioBanNhieuMonth.Size = new System.Drawing.Size(362, 32);
            this.radioBanNhieuMonth.TabIndex = 14;
            this.radioBanNhieuMonth.TabStop = true;
            this.radioBanNhieuMonth.Text = "Top 3 sản phẩm bán nhiều theo tháng";
            this.radioBanNhieuMonth.UseVisualStyleBackColor = true;
            // 
            // radioMuaNhieuYear
            // 
            this.radioMuaNhieuYear.AutoSize = true;
            this.radioMuaNhieuYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMuaNhieuYear.Location = new System.Drawing.Point(61, 193);
            this.radioMuaNhieuYear.Margin = new System.Windows.Forms.Padding(4);
            this.radioMuaNhieuYear.Name = "radioMuaNhieuYear";
            this.radioMuaNhieuYear.Size = new System.Drawing.Size(369, 32);
            this.radioMuaNhieuYear.TabIndex = 15;
            this.radioMuaNhieuYear.TabStop = true;
            this.radioMuaNhieuYear.Text = "Top 3 sản phẩm nhập nhiều trong năm\r\n";
            this.radioMuaNhieuYear.UseVisualStyleBackColor = true;
            // 
            // radioBanNhieuYear
            // 
            this.radioBanNhieuYear.AutoSize = true;
            this.radioBanNhieuYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBanNhieuYear.Location = new System.Drawing.Point(61, 80);
            this.radioBanNhieuYear.Margin = new System.Windows.Forms.Padding(4);
            this.radioBanNhieuYear.Name = "radioBanNhieuYear";
            this.radioBanNhieuYear.Size = new System.Drawing.Size(358, 32);
            this.radioBanNhieuYear.TabIndex = 16;
            this.radioBanNhieuYear.TabStop = true;
            this.radioBanNhieuYear.Text = "Top 3 sản phẩm bán nhiều trong năm";
            this.radioBanNhieuYear.UseVisualStyleBackColor = true;
            // 
            // radioMuaNhieuMonth
            // 
            this.radioMuaNhieuMonth.AutoSize = true;
            this.radioMuaNhieuMonth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMuaNhieuMonth.Location = new System.Drawing.Point(61, 136);
            this.radioMuaNhieuMonth.Margin = new System.Windows.Forms.Padding(4);
            this.radioMuaNhieuMonth.Name = "radioMuaNhieuMonth";
            this.radioMuaNhieuMonth.Size = new System.Drawing.Size(373, 32);
            this.radioMuaNhieuMonth.TabIndex = 17;
            this.radioMuaNhieuMonth.TabStop = true;
            this.radioMuaNhieuMonth.Text = "Top 3 sản phẩm nhập nhiều theo tháng";
            this.radioMuaNhieuMonth.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvThongKe);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1109, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 193);
            this.panel2.TabIndex = 8;
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowCustomTheming = false;
            this.dgvThongKe.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvThongKe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThongKe.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThongKe.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongKe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThongKe.ColumnHeadersHeight = 40;
            this.dgvThongKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvThongKe.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvThongKe.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvThongKe.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvThongKe.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvThongKe.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvThongKe.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvThongKe.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvThongKe.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgvThongKe.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvThongKe.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThongKe.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dgvThongKe.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvThongKe.CurrentTheme.Name = null;
            this.dgvThongKe.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongKe.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvThongKe.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvThongKe.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvThongKe.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThongKe.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongKe.EnableHeadersVisualStyles = false;
            this.dgvThongKe.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvThongKe.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvThongKe.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvThongKe.HeaderForeColor = System.Drawing.Color.White;
            this.dgvThongKe.Location = new System.Drawing.Point(0, 0);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.RowHeadersVisible = false;
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 40;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(630, 193);
            this.dgvThongKe.TabIndex = 0;
            this.dgvThongKe.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.dgvThongKe.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvThongKe_RowPostPaint);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 35.31699F;
            this.Column1.HeaderText = "STT";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.comboloinhuan);
            this.panel3.Controls.Add(this.cboDoanhThu);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.comboBoxChi);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1109, 243);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(630, 243);
            this.panel3.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(95, 163);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 28);
            this.label8.TabIndex = 50;
            this.label8.Text = "Lợi Nhuận";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(95, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 28);
            this.label4.TabIndex = 51;
            this.label4.Text = "Doanh Thu";
            // 
            // comboloinhuan
            // 
            this.comboloinhuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboloinhuan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboloinhuan.ForeColor = System.Drawing.Color.Red;
            this.comboloinhuan.FormattingEnabled = true;
            this.comboloinhuan.Location = new System.Drawing.Point(234, 154);
            this.comboloinhuan.Margin = new System.Windows.Forms.Padding(4);
            this.comboloinhuan.Name = "comboloinhuan";
            this.comboloinhuan.Size = new System.Drawing.Size(232, 34);
            this.comboloinhuan.TabIndex = 47;
            // 
            // cboDoanhThu
            // 
            this.cboDoanhThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDoanhThu.ForeColor = System.Drawing.Color.Red;
            this.cboDoanhThu.FormattingEnabled = true;
            this.cboDoanhThu.Location = new System.Drawing.Point(234, 102);
            this.cboDoanhThu.Margin = new System.Windows.Forms.Padding(4);
            this.cboDoanhThu.Name = "cboDoanhThu";
            this.cboDoanhThu.Size = new System.Drawing.Size(232, 34);
            this.cboDoanhThu.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(95, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 28);
            this.label7.TabIndex = 52;
            this.label7.Text = "Khoản Chi";
            // 
            // comboBoxChi
            // 
            this.comboBoxChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBoxChi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxChi.ForeColor = System.Drawing.Color.Red;
            this.comboBoxChi.FormattingEnabled = true;
            this.comboBoxChi.Location = new System.Drawing.Point(234, 43);
            this.comboBoxChi.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxChi.Name = "comboBoxChi";
            this.comboBoxChi.Size = new System.Drawing.Size(232, 34);
            this.comboBoxChi.TabIndex = 49;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1739, 945);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongKe";
            this.Text = "frmThongKe";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvThongKe;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnXem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.RadioButton radioKHMuaNhieuNam;
        private System.Windows.Forms.RadioButton radioKHMuaNhieuThang;
        private System.Windows.Forms.RadioButton radioSPTonKho;
        private System.Windows.Forms.RadioButton radioButKhanChiNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioBanNhieuMonth;
        private System.Windows.Forms.RadioButton radioMuaNhieuYear;
        private System.Windows.Forms.RadioButton radioBanNhieuYear;
        private System.Windows.Forms.RadioButton radioMuaNhieuMonth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboloinhuan;
        private System.Windows.Forms.ComboBox cboDoanhThu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}