
namespace BTL_QuanLyBanSach2
{
    partial class timkiem_ctpn_2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDS_PhieuNhapSach = new System.Windows.Forms.DataGridView();
            this.dateNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.btnTim = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS_PhieuNhapSach)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(369, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(366, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(348, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tìm kiếm phiếu nhập sách";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDS_PhieuNhapSach);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1072, 312);
            this.groupBox1.TabIndex = 7;
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
            this.dgvDS_PhieuNhapSach.Size = new System.Drawing.Size(1066, 286);
            this.dgvDS_PhieuNhapSach.TabIndex = 4;
            // 
            // dateNgayNhap
            // 
            this.dateNgayNhap.CustomFormat = "";
            this.dateNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayNhap.Location = new System.Drawing.Point(466, 85);
            this.dateNgayNhap.Name = "dateNgayNhap";
            this.dateNgayNhap.Size = new System.Drawing.Size(137, 27);
            this.dateNgayNhap.TabIndex = 39;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(628, 81);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(98, 39);
            this.btnTim.TabIndex = 40;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // timkiem_ctpn_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 450);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.dateNgayNhap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "timkiem_ctpn_2";
            this.Text = "timkiem_ctpn_2";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS_PhieuNhapSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDS_PhieuNhapSach;
        private System.Windows.Forms.DateTimePicker dateNgayNhap;
        private System.Windows.Forms.Button btnTim;
    }
}