
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_soPhieuNhap = new System.Windows.Forms.ComboBox();
            this.btn_inPhieuNhap = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(418, 12);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1058, 775);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_inPhieuNhap);
            this.panel1.Controls.Add(this.cb_soPhieuNhap);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 192);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số phiếu nhập";
            // 
            // cb_soPhieuNhap
            // 
            this.cb_soPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_soPhieuNhap.FormattingEnabled = true;
            this.cb_soPhieuNhap.Location = new System.Drawing.Point(151, 68);
            this.cb_soPhieuNhap.Name = "cb_soPhieuNhap";
            this.cb_soPhieuNhap.Size = new System.Drawing.Size(228, 28);
            this.cb_soPhieuNhap.TabIndex = 1;
            // 
            // btn_inPhieuNhap
            // 
            this.btn_inPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inPhieuNhap.Location = new System.Drawing.Point(118, 136);
            this.btn_inPhieuNhap.Name = "btn_inPhieuNhap";
            this.btn_inPhieuNhap.Size = new System.Drawing.Size(152, 38);
            this.btn_inPhieuNhap.TabIndex = 2;
            this.btn_inPhieuNhap.Text = "In báo cáo";
            this.btn_inPhieuNhap.UseVisualStyleBackColor = true;
            this.btn_inPhieuNhap.Click += new System.EventHandler(this.btn_inPhieuNhap_Click);
            // 
            // BaoCao_PhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 798);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "BaoCao_PhieuNhap";
            this.Text = "BaoCao_PhieuNhap";
            this.Load += new System.EventHandler(this.BaoCao_PhieuNhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_inPhieuNhap;
        private System.Windows.Forms.ComboBox cb_soPhieuNhap;
        private System.Windows.Forms.Label label1;
    }
}