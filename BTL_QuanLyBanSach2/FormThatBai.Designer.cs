
namespace BTL_QuanLyBanSach2
{
    partial class FormThatBai
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
            this.LbDemlui = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // LbDemlui
            // 
            this.LbDemlui.AutoSize = true;
            this.LbDemlui.Location = new System.Drawing.Point(196, 295);
            this.LbDemlui.Name = "LbDemlui";
            this.LbDemlui.Size = new System.Drawing.Size(175, 17);
            this.LbDemlui.TabIndex = 9;
            this.LbDemlui.Text = "Thời gian đềm lùi ( còn lại)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(414, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Bạn đã sử dụng hết số lần đăng nhập, Vui lòng chờ hết thòi gian";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(203, 235);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(405, 27);
            this.progressBar1.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormThatBai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LbDemlui);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Name = "FormThatBai";
            this.Text = "FormThatBai";
            this.Load += new System.EventHandler(this.FormThatBai_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbDemlui;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}