
namespace BTL_QuanLyBanSach2
{
    partial class TimKiem_CTPN
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
            this.label2 = new System.Windows.Forms.Label();
            this.dateNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDS_PhieuNhapSach = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS_PhieuNhapSach)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(475, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm kiếm phiếu nhập sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(609, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày nhập sách";
            // 
            // dateNgayNhap
            // 
            this.dateNgayNhap.CalendarForeColor = System.Drawing.SystemColors.Control;
            this.dateNgayNhap.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateNgayNhap.Location = new System.Drawing.Point(626, 144);
            this.dateNgayNhap.Name = "dateNgayNhap";
            this.dateNgayNhap.Size = new System.Drawing.Size(206, 27);
            this.dateNgayNhap.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(1049, 86);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 39);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDS_PhieuNhapSach);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(63, 287);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 312);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách phiếu nhập sách";
            // 
            // dgvDS_PhieuNhapSach
            // 
            this.dgvDS_PhieuNhapSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDS_PhieuNhapSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDS_PhieuNhapSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDS_PhieuNhapSach.Location = new System.Drawing.Point(3, 23);
            this.dgvDS_PhieuNhapSach.Name = "dgvDS_PhieuNhapSach";
            this.dgvDS_PhieuNhapSach.RowHeadersWidth = 51;
            this.dgvDS_PhieuNhapSach.RowTemplate.Height = 24;
            this.dgvDS_PhieuNhapSach.Size = new System.Drawing.Size(947, 286);
            this.dgvDS_PhieuNhapSach.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Số PN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mã sách\r\n";
            // 
            // TimKiem_CTPN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 611);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.dateNgayNhap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TimKiem_CTPN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimKiem_CTPN";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS_PhieuNhapSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateNgayNhap;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDS_PhieuNhapSach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}