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

        private void dSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            dmk.MdiParent = this;
            dmk.Show();
        }

        private void nhậpThểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TheLoai tl = new TheLoai();
            tl.MdiParent = this;
            tl.Show();
        }

        private void nhậpTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TacGia tg = new TacGia();
            tg.MdiParent = this;
            tg.Show();
        }

        private void tìmKiếmPhiếuNhậpSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiem_CTPN timKiem_CTPN = new TimKiem_CTPN();
            timKiem_CTPN.MdiParent = this;
            timKiem_CTPN.Show();
        }

        private void tìmKiếmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiem_Sach timKiem_Sach = new TimKiem_Sach();
            timKiem_Sach.MdiParent = this;
            timKiem_Sach.Show();
        }

        private void hóaĐơnBánSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonBan hdb = new HoaDonBan();
            hdb.MdiParent = this;
            hdb.Show();
        }

        private void tìmKiếmHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiem_CTHD timKiem_CTHD = new TimKiem_CTHD();
            timKiem_CTHD.MdiParent = this;
            timKiem_CTHD.Show();
        }

        private void phiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report ds = new Report();
            ds.MdiParent = this;
            ds.Show();
        }
    }
}
