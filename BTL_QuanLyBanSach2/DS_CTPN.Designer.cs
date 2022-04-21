
namespace BTL_QuanLyBanSach2
{
    partial class DS_CTPN
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
            this.dgvDS_CTPN = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS_CTPN)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(377, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách chi tiết phiếu nhập";
            // 
            // dgvDS_CTPN
            // 
            this.dgvDS_CTPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDS_CTPN.Location = new System.Drawing.Point(12, 107);
            this.dgvDS_CTPN.Name = "dgvDS_CTPN";
            this.dgvDS_CTPN.RowHeadersWidth = 51;
            this.dgvDS_CTPN.RowTemplate.Height = 24;
            this.dgvDS_CTPN.Size = new System.Drawing.Size(1160, 267);
            this.dgvDS_CTPN.TabIndex = 1;
            this.dgvDS_CTPN.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDS_CTPN_CellContentClick);
            // 
            // DS_CTPN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 569);
            this.Controls.Add(this.dgvDS_CTPN);
            this.Controls.Add(this.label1);
            this.Name = "DS_CTPN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DS_CTPN";
            this.Load += new System.EventHandler(this.DS_CTPN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS_CTPN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDS_CTPN;
    }
}