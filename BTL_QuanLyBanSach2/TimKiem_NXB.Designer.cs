
namespace BTL_QuanLyBanSach2
{
    partial class TimKiem_NXB
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
            this.cbSach_NXB = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvDSSach_NXB = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSach_NXB)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(193, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm Sách Theo Nhà Xuất Bản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chọn nhà xuất bản";
            // 
            // cbSach_NXB
            // 
            this.cbSach_NXB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSach_NXB.FormattingEnabled = true;
            this.cbSach_NXB.Location = new System.Drawing.Point(201, 95);
            this.cbSach_NXB.Name = "cbSach_NXB";
            this.cbSach_NXB.Size = new System.Drawing.Size(230, 30);
            this.cbSach_NXB.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(445, 91);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 38);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvDSSach_NXB
            // 
            this.dgvDSSach_NXB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSSach_NXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSSach_NXB.Location = new System.Drawing.Point(3, 26);
            this.dgvDSSach_NXB.Name = "dgvDSSach_NXB";
            this.dgvDSSach_NXB.RowHeadersWidth = 51;
            this.dgvDSSach_NXB.RowTemplate.Height = 24;
            this.dgvDSSach_NXB.Size = new System.Drawing.Size(724, 192);
            this.dgvDSSach_NXB.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDSSach_NXB);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(42, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 221);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách Sách theo Nhà xuất bản";
            // 
            // TimKiem_NXB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 468);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.cbSach_NXB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TimKiem_NXB";
            this.Text = "TimKiem_NXB";
            this.Load += new System.EventHandler(this.TimKiem_NXB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSach_NXB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSach_NXB;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvDSSach_NXB;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}