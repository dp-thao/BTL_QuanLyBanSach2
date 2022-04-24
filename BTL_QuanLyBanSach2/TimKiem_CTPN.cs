using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace BTL_QuanLyBanSach2
{
    public partial class TimKiem_CTPN : Form
    {
        public TimKiem_CTPN()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtSoPN.Text == "") && (txtMaSach.Text == "") && (txtNam.Text == "") && (txtTenNV.Text == "") && (txtThang.Text == ""))
                {
                    MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string sql =
                   "SELECT ROW_NUMBER() OVER (ORDER BY tblChiTietPhieuNhap.sSoPN) AS [STT], sTenSach AS [Tên sách], sTenTL AS[Tên thể loại], sTenTG AS[Tên tác giả], sTenNXB AS[Tên NXB], sTenNV AS[Tên NV], dNgayNhap AS[Ngày nhập], fSoLuongNhap AS[Số lượng nhập], fGiaNhap AS[Giá nhập], (fSoLuongNhap * fGiaNhap) AS[Thành tiền] FROM dbo.tblChiTietPhieuNhap JOIN dbo.tblSach ON dbo.tblChiTietPhieuNhap.sMaSach = dbo.tblSach.sMaSach JOIN dbo.tblPhieuNhap ON dbo.tblPhieuNhap.sSoPN = dbo.tblChiTietPhieuNhap.sSoPN JOIN tblTheLoai ON tblTheLoai.sMaTL = tblSach.sMaTL JOIN tblTacGia ON tblTacGia.sMaTG = tblSach.sMaTG JOIN tblNhaXuatBan ON tblNhaXuatBan.sMaNXB = tblSach.sMaNXB JOIN tblNhanVien ON tblNhanVien.sMaNV = tblPhieuNhap.sMaNV WHERE 1=1";
                if (txtSoPN.Text != "")
                {
                    sql = sql + " AND tblChiTietPhieuNhap.sSoPN Like N'%" + txtSoPN.Text + "%'";
                }
                if (txtMaSach.Text != "")
                {
                    sql = sql + " AND tblChiTietPhieuNhap.sMaSach Like N'%" + txtMaSach.Text + "%'";
                }
                if (txtThang.Text != "")
                {
                    sql = sql + " AND MONTH(tblPhieuNhap.dNgayNhap) =" + txtThang.Text;
                }
                if (txtNam.Text != "")
                {
                    sql = sql + " AND YEAR(tblPhieuNhap.dNgayNhap) =" + txtNam.Text;
                }
                if (txtTenNV.Text != "")
                {
                    sql = sql + " AND tblNhanVien.sTenNV Like N'%" + txtTenNV.Text + "%'";
                }

                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                SqlCommand cmd = new SqlCommand(constr, conn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = cmd;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvDS_PhieuNhapSach.DataSource = dataTable;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
