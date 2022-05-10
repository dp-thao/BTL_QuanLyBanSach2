using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QuanLyBanSach2
{
    public partial class FormThatBai : Form
    {
        public FormThatBai()
        {
            InitializeComponent();
        }
        int i, n;

        private void FormThatBai_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            i = 100;
            n = i;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Maximum = n;
            i--;
            this.LbDemlui.Text = " Thời gian còn lại: " + i.ToString() + "Giây";
            if (i >= 0)
            {
                progressBar1.Value = i;
            }
            if (i < 0)
            {
                this.timer1.Enabled = false;
                DangNhap fm = new DangNhap();
                fm.Show();
                this.Hide();
            }
        }
    }
}
