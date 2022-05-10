
namespace BTL_QuanLyBanSach2
{
    partial class BaoCao_PhieuNhap
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_inPhieuNhap = new System.Windows.Forms.Button();
            this.cb_soPhieuNhap = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnIN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.dgvDS = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.dgvDS.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(344, 12);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1132, 493);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_inPhieuNhap);
            this.panel1.Controls.Add(this.cb_soPhieuNhap);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 136);
            this.panel1.TabIndex = 1;
            // 
            // btn_inPhieuNhap
            // 
            this.btn_inPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inPhieuNhap.Location = new System.Drawing.Point(151, 73);
            this.btn_inPhieuNhap.Name = "btn_inPhieuNhap";
            this.btn_inPhieuNhap.Size = new System.Drawing.Size(119, 38);
            this.btn_inPhieuNhap.TabIndex = 2;
            this.btn_inPhieuNhap.Text = "In báo cáo";
            this.btn_inPhieuNhap.UseVisualStyleBackColor = true;
            this.btn_inPhieuNhap.Click += new System.EventHandler(this.btn_inPhieuNhap_Click);
            // 
            // cb_soPhieuNhap
            // 
            this.cb_soPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_soPhieuNhap.FormattingEnabled = true;
            this.cb_soPhieuNhap.Location = new System.Drawing.Point(151, 22);
            this.cb_soPhieuNhap.Name = "cb_soPhieuNhap";
            this.cb_soPhieuNhap.Size = new System.Drawing.Size(119, 28);
            this.cb_soPhieuNhap.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số phiếu nhập";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtThang);
            this.panel2.Controls.Add(this.btnIN);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 179);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 136);
            this.panel2.TabIndex = 3;
            // 
            // btnIN
            // 
            this.btnIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIN.Location = new System.Drawing.Point(151, 73);
            this.btnIN.Name = "btnIN";
            this.btnIN.Size = new System.Drawing.Size(119, 38);
            this.btnIN.TabIndex = 2;
            this.btnIN.Text = "In báo cáo";
            this.btnIN.UseVisualStyleBackColor = true;
            this.btnIN.Click += new System.EventHandler(this.btnIN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tháng";
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(151, 23);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(127, 22);
            this.txtThang.TabIndex = 3;
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Location = new System.Drawing.Point(51, 21);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.RowTemplate.Height = 24;
            this.dgvDanhSach.Size = new System.Drawing.Size(710, 216);
            this.dgvDanhSach.TabIndex = 4;
            // 
            // dgvDS
            // 
            this.dgvDS.Controls.Add(this.dgvDanhSach);
            this.dgvDS.Location = new System.Drawing.Point(99, 530);
            this.dgvDS.Name = "dgvDS";
            this.dgvDS.Size = new System.Drawing.Size(792, 256);
            this.dgvDS.TabIndex = 5;
            this.dgvDS.TabStop = false;
            this.dgvDS.Text = "Danh sách";
            // 
            // BaoCao_PhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 798);
            this.Controls.Add(this.dgvDS);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "BaoCao_PhieuNhap";
            this.Text = "BaoCao_PhieuNhap";
            this.Load += new System.EventHandler(this.BaoCao_PhieuNhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.dgvDS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_inPhieuNhap;
        private System.Windows.Forms.ComboBox cb_soPhieuNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.Button btnIN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.GroupBox dgvDS;
    }
}