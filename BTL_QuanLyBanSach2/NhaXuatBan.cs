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
    public partial class NhaXuatBan : Form
    {
        public NhaXuatBan()
        {
            InitializeComponent();
        }

        string MaNXB, TenNXB, DiaChiNXB, DienThoai;

        public void LayThongTin()
        {
            MaNXB = txtMaNXB.Text;
            TenNXB = txtTenNXB.Text;
            DiaChiNXB = txtDiaChiNXB.Text;
            DienThoai = txtDienThoaiNXB.Text;
        }
        private void btnThemNXB_Click(object sender, EventArgs e)
        {
            try
            {
                LayThongTin();
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                string sql = "SELECT * FROM tblNhaXuatBan WHERE sMaNXB = '" + txtMaNXB.Text + "'";
                if (KiemTraKhoaChinh(constr, conn, sql))
                {
                    MessageBox.Show("Đã tồn tại nhà xuất bản", "Thông báo");
                }
                else
                {
                    SqlCommand cmd_NXB = new SqlCommand(constr, conn);
                    cmd_NXB.CommandType = CommandType.StoredProcedure;
                    cmd_NXB.CommandText = "dbo.Proc_ThemNXB";
                    cmd_NXB.Parameters.AddWithValue("@MaNXB", MaNXB);
                    cmd_NXB.Parameters.AddWithValue("@TenNXB", TenNXB);
                    cmd_NXB.Parameters.AddWithValue("@DiaChiNXB", DiaChiNXB);
                    cmd_NXB.Parameters.AddWithValue("@DienThoai", DienThoai);

                    int testCmd_NXB = cmd_NXB.ExecuteNonQuery();
                    if (testCmd_NXB > 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        load_DS_NXB(constr);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo");
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sự kiện sửa Nhà xuất bản
        private void btnSuaNXB_Click(object sender, EventArgs e)
        {
            try
            {
                LayThongTin();
                string maNXB = dgvDS_NXB.CurrentRow.Cells["Mã NXB"].Value.ToString();

                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                if (txtMaNXB.Text == "")
                {
                    MessageBox.Show("Nhập thông tin cần sửa");
                }
                else
                {
                    SqlCommand cmd_NXB = new SqlCommand(constr, conn);
                    cmd_NXB.CommandType = CommandType.StoredProcedure;
                    cmd_NXB.CommandText = "dbo.Proc_CapNhatNXB";
                    cmd_NXB.Parameters.AddWithValue("@MaNXB", maNXB);
                    cmd_NXB.Parameters.AddWithValue("@TenNXB", TenNXB);
                    cmd_NXB.Parameters.AddWithValue("@DiaChiNXB", DiaChiNXB);
                    cmd_NXB.Parameters.AddWithValue("@DienThoai", DienThoai);

                    int testCmd_NXB = cmd_NXB.ExecuteNonQuery();
                    if (testCmd_NXB > 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo");
                        load_DS_NXB(constr);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Thông báo");
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sự kiện Xóa nhà xuất bản
        private void btnXoaNXB_Click(object sender, EventArgs e)
        {
            try
            {
                string maNXB = dgvDS_NXB.CurrentRow.Cells["Mã NXB"].Value.ToString();
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                if (txtMaNXB.Text == "")
                {
                    MessageBox.Show("Nhập thông tin cần xóa");
                }
                else
                {
                    SqlCommand cmd_NXB = new SqlCommand(constr, conn);
                    cmd_NXB.CommandType = CommandType.StoredProcedure;
                    cmd_NXB.CommandText = "dbo.Proc_XoaNXB";
                    cmd_NXB.Parameters.AddWithValue("@MaNXB", maNXB);

                    int testCmd_NXB = cmd_NXB.ExecuteNonQuery();
                    if (testCmd_NXB > 0)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo");
                        load_DS_NXB(constr);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo");
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Kiểm tra khóa chính
        public static bool KiemTraKhoaChinh(string constr, SqlConnection conn, string sql)
        {
            SqlCommand cmd = new SqlCommand(constr, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.Read())
            {
                sqlDataReader.Close();
                return true;
            }
            else
            {
                sqlDataReader.Close();
                return false;
            }
        }

        // Hàm hiển thị danh sách
        public void load_DS_NXB(string constr)
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM vwDS_NXB", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvDS_NXB.DataSource = dataTable;
        }

        // Sự kiện Form Load load danh sách Nhà xuất bản
        private void NhaXuatBan_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            load_DS_NXB(constr);
        }

        private void dgvDS_NXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNXB.Text = dgvDS_NXB.CurrentRow.Cells["Mã NXB"].Value.ToString();
            txtTenNXB.Text = dgvDS_NXB.CurrentRow.Cells["Tên NXB"].Value.ToString();
            txtDiaChiNXB.Text = dgvDS_NXB.CurrentRow.Cells["Địa chỉ NXB"].Value.ToString();
            txtDienThoaiNXB.Text = dgvDS_NXB.CurrentRow.Cells["Điện thoại"].Value.ToString();
        }
    }
}