
namespace BTL_QuanLyBanSach2
{
    partial class NhaXuatBan
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDS_NXB = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSuaNXB = new System.Windows.Forms.Button();
            this.btnXoaNXB = new System.Windows.Forms.Button();
            this.btnThemNXB = new System.Windows.Forms.Button();
            this.txtDienThoaiNXB = new System.Windows.Forms.TextBox();
            this.txtDiaChiNXB = new System.Windows.Forms.TextBox();
            this.txtTenNXB = new System.Windows.Forms.TextBox();
            this.txtMaNXB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS_NXB)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(298, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhà Xuất Bản";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtDienThoaiNXB);
            this.groupBox1.Controls.Add(this.txtDiaChiNXB);
            this.groupBox1.Controls.Add(this.txtTenNXB);
            this.groupBox1.Controls.Add(this.txtMaNXB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 466);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvDS_NXB);
            this.groupBox3.Location = new System.Drawing.Point(45, 223);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(680, 223);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách NXB";
            // 
            // dgvDS_NXB
            // 
            this.dgvDS_NXB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDS_NXB.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDS_NXB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDS_NXB.Location = new System.Drawing.Point(6, 29);
            this.dgvDS_NXB.Name = "dgvDS_NXB";
            this.dgvDS_NXB.RowHeadersWidth = 51;
            this.dgvDS_NXB.RowTemplate.Height = 24;
            this.dgvDS_NXB.Size = new System.Drawing.Size(668, 188);
            this.dgvDS_NXB.TabIndex = 0;
            this.dgvDS_NXB.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDS_NXB_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSuaNXB);
            this.groupBox2.Controls.Add(this.btnXoaNXB);
            this.groupBox2.Controls.Add(this.btnThemNXB);
            this.groupBox2.Location = new System.Drawing.Point(536, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 188);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // btnSuaNXB
            // 
            this.btnSuaNXB.Location = new System.Drawing.Point(21, 80);
            this.btnSuaNXB.Name = "btnSuaNXB";
            this.btnSuaNXB.Size = new System.Drawing.Size(89, 38);
            this.btnSuaNXB.TabIndex = 3;
            this.btnSuaNXB.Text = "Sửa";
            this.btnSuaNXB.UseVisualStyleBackColor = true;
            this.btnSuaNXB.Click += new System.EventHandler(this.btnSuaNXB_Click);
            // 
            // btnXoaNXB
            // 
            this.btnXoaNXB.Location = new System.Drawing.Point(21, 131);
            this.btnXoaNXB.Name = "btnXoaNXB";
            this.btnXoaNXB.Size = new System.Drawing.Size(89, 38);
            this.btnXoaNXB.TabIndex = 1;
            this.btnXoaNXB.Text = "Xóa";
            this.btnXoaNXB.UseVisualStyleBackColor = true;
            this.btnXoaNXB.Click += new System.EventHandler(this.btnXoaNXB_Click);
            // 
            // btnThemNXB
            // 
            this.btnThemNXB.Location = new System.Drawing.Point(21, 29);
            this.btnThemNXB.Name = "btnThemNXB";
            this.btnThemNXB.Size = new System.Drawing.Size(89, 38);
            this.btnThemNXB.TabIndex = 0;
            this.btnThemNXB.Text = "Thêm";
            this.btnThemNXB.UseVisualStyleBackColor = true;
            this.btnThemNXB.Click += new System.EventHandler(this.btnThemNXB_Click);
            // 
            // txtDienThoaiNXB
            // 
            this.txtDienThoaiNXB.Location = new System.Drawing.Point(226, 161);
            this.txtDienThoaiNXB.Name = "txtDienThoaiNXB";
            this.txtDienThoaiNXB.Size = new System.Drawing.Size(249, 27);
            this.txtDienThoaiNXB.TabIndex = 7;
            // 
            // txtDiaChiNXB
            // 
            this.txtDiaChiNXB.Location = new System.Drawing.Point(226, 122);
            this.txtDiaChiNXB.Name = "txtDiaChiNXB";
            this.txtDiaChiNXB.Size = new System.Drawing.Size(249, 27);
            this.txtDiaChiNXB.TabIndex = 6;
            // 
            // txtTenNXB
            // 
            this.txtTenNXB.Location = new System.Drawing.Point(226, 84);
            this.txtTenNXB.Name = "txtTenNXB";
            this.txtTenNXB.Size = new System.Drawing.Size(249, 27);
            this.txtTenNXB.TabIndex = 5;
            // 
            // txtMaNXB
            // 
            this.txtMaNXB.Location = new System.Drawing.Point(226, 43);
            this.txtMaNXB.Name = "txtMaNXB";
            this.txtMaNXB.Size = new System.Drawing.Size(249, 27);
            this.txtMaNXB.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Địa chỉ NXB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên NXB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã NXB";
            // 
            // NhaXuatBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(806, 558);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NhaXuatBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NhaXuatBan";
            this.Load += new System.EventHandler(this.NhaXuatBan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS_NXB)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDS_NXB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSuaNXB;
        private System.Windows.Forms.Button btnXoaNXB;
        private System.Windows.Forms.Button btnThemNXB;
        private System.Windows.Forms.TextBox txtDienThoaiNXB;
        private System.Windows.Forms.TextBox txtDiaChiNXB;
        private System.Windows.Forms.TextBox txtTenNXB;
        private System.Windows.Forms.TextBox txtMaNXB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}