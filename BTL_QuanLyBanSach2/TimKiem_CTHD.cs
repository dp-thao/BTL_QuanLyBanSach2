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
    public partial class TimKiem_CTHD : Form
    {
        public TimKiem_CTHD()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtSoHD.Text == "") && (txtTenSach.Text == "") && (txtNam.Text == "") && (txtTenNV.Text == "") && (txtThang.Text == ""))
                {
                    MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string sql =
                   "SELECT ROW_NUMBER() OVER (ORDER BY tblChiTietHoaDon.sSoHD) AS [STT], sTenSach AS [Tên sách], dNgayBan AS[Ngày bán], sTenNV AS[Tên NV], fSoLuongBan AS[Số lượng bán], fGiaBan AS[Giá bán], (fSoLuongBan * fGiaBan) AS[Thành tiền] FROM dbo.tblChiTietHoaDon JOIN dbo.tblSach ON dbo.tblChiTietHoaDon.sMaSach = dbo.tblSach.sMaSach JOIN dbo.tblHoaDon ON dbo.tblHoaDon.sSoHD = dbo.tblChiTietHoaDon.sSoHD JOIN tblNhanVien ON tblNhanVien.sMaNV = tblHoaDon.sMaNV WHERE 1=1";
                if (txtSoHD.Text != "")
                {
                    sql = sql + " AND tblChiTietHoaDon.sSoHD Like N'%" + txtSoHD.Text + "%'";
                }
                if (txtTenSach.Text != "")
                {
                    sql = sql + " AND tblSach.sTenSach Like N'%" + txtTenSach.Text + "%'";
                }
                if (txtThang.Text != "")
                {
                    sql = sql + " AND MONTH(tblHoaDon.dNgayBan) =" + txtThang.Text;
                }
                if (txtNam.Text != "")
                {
                    sql = sql + " AND YEAR(tblHoaDon.dNgayBan) =" + txtNam.Text;
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
                    dgvDS_HoaDonBan.DataSource = dataTable;
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
