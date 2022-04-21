
namespace BTL_QuanLyBanSach2
{
    partial class Report
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
            this.btnSLNhap = new System.Windows.Forms.Button();
            this.txtSLNhap = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(343, 3);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1308, 650);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // btnSLNhap
            // 
            this.btnSLNhap.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSLNhap.Location = new System.Drawing.Point(222, 81);
            this.btnSLNhap.Name = "btnSLNhap";
            this.btnSLNhap.Size = new System.Drawing.Size(101, 36);
            this.btnSLNhap.TabIndex = 1;
            this.btnSLNhap.Text = "Xác nhận";
            this.btnSLNhap.UseVisualStyleBackColor = true;
            this.btnSLNhap.Click += new System.EventHandler(this.btnSLNhap_Click);
            // 
            // txtSLNhap
            // 
            this.txtSLNhap.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLNhap.Location = new System.Drawing.Point(12, 84);
            this.txtSLNhap.Name = "txtSLNhap";
            this.txtSLNhap.Size = new System.Drawing.Size(174, 30);
            this.txtSLNhap.TabIndex = 2;
            // 
            // DSHoaDonNhapSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 654);
            this.Controls.Add(this.txtSLNhap);
            this.Controls.Add(this.btnSLNhap);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "DSHoaDonNhapSach";
            this.Text = "DSHoaDonNhapSach";
            this.Load += new System.EventHandler(this.DSHoaDonNhapSach_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btnSLNhap;
        private System.Windows.Forms.TextBox txtSLNhap;
    }
}