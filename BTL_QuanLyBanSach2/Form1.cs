﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void phiếuNhậpSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuNhapSach phieuNhapSach = new PhieuNhapSach();
            phieuNhapSach.MdiParent = this;
            phieuNhapSach.Show();
        }

        private void nhậpNXBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhaXuatBan nhaXuatBan = new NhaXuatBan();
            nhaXuatBan.MdiParent = this;
            nhaXuatBan.Show();
        }

        private void tìmSáchTheoNhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiem_NXB timKiem_NXB = new TimKiem_NXB();
            timKiem_NXB.MdiParent = this;
            timKiem_NXB.Show();
        }

        private void tìmKiếmPhiếuNhậpSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiem_CTPN timKiem_CTPN = new TimKiem_CTPN();
            timKiem_CTPN.MdiParent = this;
            timKiem_CTPN.Show();
        }

        private void dSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report ds = new Report();
            ds.MdiParent = this;
            ds.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            dmk.MdiParent = this;
            dmk.Show();
        }
    }
}
