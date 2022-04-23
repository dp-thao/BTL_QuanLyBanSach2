
namespace BTL_QuanLyBanSach2
{
    partial class PhieuNhapSach
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDS_PhieuNhap = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnCTPN = new System.Windows.Forms.Button();
            this.btnPhieuNhapSach = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dateNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLapPhieuMoi = new System.Windows.Forms.Button();
            this.btnGhiPhieu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTheLoai = new System.Windows.Forms.TextBox();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.cbTenSach = new System.Windows.Forms.ComboBox();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.txtSoLuongNhap = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoPhieuNhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtNXB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS_PhieuNhap)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvDS_PhieuNhap);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 387);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1125, 273);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách Phiếu nhập";
            // 
            // dgvDS_PhieuNhap
            // 
            this.dgvDS_PhieuNhap.AllowUserToAddRows = false;
            this.dgvDS_PhieuNhap.AllowUserToDeleteRows = false;
            this.dgvDS_PhieuNhap.AllowUserToResizeColumns = false;
            this.dgvDS_PhieuNhap.AllowUserToResizeRows = false;
            this.dgvDS_PhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDS_PhieuNhap.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDS_PhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDS_PhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDS_PhieuNhap.Location = new System.Drawing.Point(3, 23);
            this.dgvDS_PhieuNhap.Name = "dgvDS_PhieuNhap";
            this.dgvDS_PhieuNhap.ReadOnly = true;
            this.dgvDS_PhieuNhap.RowHeadersWidth = 51;
            this.dgvDS_PhieuNhap.RowTemplate.Height = 24;
            this.dgvDS_PhieuNhap.Size = new System.Drawing.Size(1119, 247);
            this.dgvDS_PhieuNhap.TabIndex = 13;
            this.dgvDS_PhieuNhap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDS_CTPN_CellClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(851, 674);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Tổng tiền:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(951, 666);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(183, 27);
            this.txtTongTien.TabIndex = 15;
            // 
            // btnCTPN
            // 
            this.btnCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTPN.Location = new System.Drawing.Point(225, 18);
            this.btnCTPN.Name = "btnCTPN";
            this.btnCTPN.Size = new System.Drawing.Size(196, 34);
            this.btnCTPN.TabIndex = 41;
            this.btnCTPN.Text = "DS CTPN";
            this.btnCTPN.UseVisualStyleBackColor = true;
            this.btnCTPN.Click += new System.EventHandler(this.btnCTPN_Click);
            // 
            // btnPhieuNhapSach
            // 
            this.btnPhieuNhapSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhieuNhapSach.Location = new System.Drawing.Point(8, 18);
            this.btnPhieuNhapSach.Name = "btnPhieuNhapSach";
            this.btnPhieuNhapSach.Size = new System.Drawing.Size(196, 34);
            this.btnPhieuNhapSach.TabIndex = 33;
            this.btnPhieuNhapSach.Text = "DS Phiếu nhập sách";
            this.btnPhieuNhapSach.UseVisualStyleBackColor = true;
            this.btnPhieuNhapSach.Click += new System.EventHandler(this.btnPhieuNhapSach_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnSua);
            this.groupBox4.Controls.Add(this.btnXoa);
            this.groupBox4.Controls.Add(this.btnThem);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(1030, 138);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(104, 162);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(15, 69);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 33);
            this.btnSua.TabIndex = 16;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(15, 114);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 33);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(15, 24);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 33);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dateNgayNhap
            // 
            this.dateNgayNhap.CustomFormat = "";
            this.dateNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayNhap.Location = new System.Drawing.Point(381, 94);
            this.dateNgayNhap.Name = "dateNgayNhap";
            this.dateNgayNhap.Size = new System.Drawing.Size(137, 27);
            this.dateNgayNhap.TabIndex = 38;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnLapPhieuMoi);
            this.groupBox2.Controls.Add(this.btnGhiPhieu);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(802, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 162);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Tính tiền";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLapPhieuMoi
            // 
            this.btnLapPhieuMoi.Location = new System.Drawing.Point(8, 69);
            this.btnLapPhieuMoi.Name = "btnLapPhieuMoi";
            this.btnLapPhieuMoi.Size = new System.Drawing.Size(196, 34);
            this.btnLapPhieuMoi.TabIndex = 1;
            this.btnLapPhieuMoi.Text = "Lập phiếu mới";
            this.btnLapPhieuMoi.UseVisualStyleBackColor = true;
            this.btnLapPhieuMoi.Click += new System.EventHandler(this.btnLapPhieuMoi_Click);
            // 
            // btnGhiPhieu
            // 
            this.btnGhiPhieu.Location = new System.Drawing.Point(8, 25);
            this.btnGhiPhieu.Name = "btnGhiPhieu";
            this.btnGhiPhieu.Size = new System.Drawing.Size(196, 32);
            this.btnGhiPhieu.TabIndex = 0;
            this.btnGhiPhieu.Text = "Ghi phiếu";
            this.btnGhiPhieu.UseVisualStyleBackColor = true;
            this.btnGhiPhieu.Click += new System.EventHandler(this.btnGhiPhieu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTheLoai);
            this.groupBox1.Controls.Add(this.txtTacGia);
            this.groupBox1.Controls.Add(this.cbTenSach);
            this.groupBox1.Controls.Add(this.txtMaSach);
            this.groupBox1.Controls.Add(this.txtGiaNhap);
            this.groupBox1.Controls.Add(this.txtSoLuongNhap);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 162);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sách";
            // 
            // txtTheLoai
            // 
            this.txtTheLoai.Location = new System.Drawing.Point(508, 105);
            this.txtTheLoai.Name = "txtTheLoai";
            this.txtTheLoai.ReadOnly = true;
            this.txtTheLoai.Size = new System.Drawing.Size(235, 27);
            this.txtTheLoai.TabIndex = 24;
            // 
            // txtTacGia
            // 
            this.txtTacGia.Location = new System.Drawing.Point(508, 68);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.ReadOnly = true;
            this.txtTacGia.Size = new System.Drawing.Size(235, 27);
            this.txtTacGia.TabIndex = 23;
            // 
            // cbTenSach
            // 
            this.cbTenSach.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTenSach.FormattingEnabled = true;
            this.cbTenSach.Location = new System.Drawing.Point(508, 28);
            this.cbTenSach.Name = "cbTenSach";
            this.cbTenSach.Size = new System.Drawing.Size(235, 28);
            this.cbTenSach.TabIndex = 21;
            this.cbTenSach.SelectedIndexChanged += new System.EventHandler(this.cbTenSach_SelectedIndexChanged);
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(120, 29);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.ReadOnly = true;
            this.txtMaSach.Size = new System.Drawing.Size(248, 27);
            this.txtMaSach.TabIndex = 11;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(120, 108);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(248, 27);
            this.txtGiaNhap.TabIndex = 7;
            // 
            // txtSoLuongNhap
            // 
            this.txtSoLuongNhap.Location = new System.Drawing.Point(120, 68);
            this.txtSoLuongNhap.Name = "txtSoLuongNhap";
            this.txtSoLuongNhap.Size = new System.Drawing.Size(248, 27);
            this.txtSoLuongNhap.TabIndex = 6;
            this.txtSoLuongNhap.Validating += new System.ComponentModel.CancelEventHandler(this.txtSoLuongNhap_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(418, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 20);
            this.label10.TabIndex = 5;
            this.label10.Text = "Thể loại";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(418, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Tên sách";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(418, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Tác giả";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Giá nhập";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Số lượng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mã sách";
            // 
            // txtSoPhieuNhap
            // 
            this.txtSoPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoPhieuNhap.Location = new System.Drawing.Point(160, 98);
            this.txtSoPhieuNhap.Name = "txtSoPhieuNhap";
            this.txtSoPhieuNhap.Size = new System.Drawing.Size(82, 27);
            this.txtSoPhieuNhap.TabIndex = 35;
            this.txtSoPhieuNhap.Validating += new System.ComponentModel.CancelEventHandler(this.txtSoPhieuNhap_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(560, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "NXB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(282, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "Ngày nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Số phiếu nhập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(449, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 38);
            this.label1.TabIndex = 42;
            this.label1.Text = "Phiếu Nhập Sách";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnCTPN);
            this.groupBox5.Controls.Add(this.btnPhieuNhapSach);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(708, 318);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(432, 63);
            this.groupBox5.TabIndex = 43;
            this.groupBox5.TabStop = false;
            // 
            // txtNXB
            // 
            this.txtNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNXB.Location = new System.Drawing.Point(610, 95);
            this.txtNXB.Name = "txtNXB";
            this.txtNXB.ReadOnly = true;
            this.txtNXB.Size = new System.Drawing.Size(196, 27);
            this.txtNXB.TabIndex = 44;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(846, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 45;
            this.label12.Text = "Tên NV";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNV.Location = new System.Drawing.Point(926, 96);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.ReadOnly = true;
            this.txtTenNV.Size = new System.Drawing.Size(208, 27);
            this.txtTenNV.TabIndex = 46;
            // 
            // PhieuNhapSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1152, 721);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNXB);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dateNgayNhap);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSoPhieuNhap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.HelpButton = true;
            this.Name = "PhieuNhapSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhieuNhapSach";
            this.Load += new System.EventHandler(this.PhieuNhapSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS_PhieuNhap)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnCTPN;
        private System.Windows.Forms.Button btnPhieuNhapSach;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DateTimePicker dateNgayNhap;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLapPhieuMoi;
        private System.Windows.Forms.Button btnGhiPhieu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.TextBox txtSoLuongNhap;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoPhieuNhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDS_PhieuNhap;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbTenSach;
        private System.Windows.Forms.TextBox txtTheLoai;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.TextBox txtNXB;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label label12;
    }
}