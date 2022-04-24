using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace BTL_QuanLyBanSach2
{
    public partial class TacGia : Form
    {
        public TacGia()
        {
            InitializeComponent();
        }

        string MaTG, TenTG, LienLac;

        public void LayThongTin()
        {
            MaTG = txtMaTG.Text;
            TenTG = txtTenTG.Text;
            LienLac = txtLienLac.Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                string sql = "SELECT * FROM tblTacGia WHERE sMaTG = N'" + txtMaTG.Text + "'";
                if (!KiemTraKhoaChinh(constr, conn, sql))
                {
                    SqlCommand cmd = new SqlCommand(constr, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.proc_ThemTG";
                    cmd.Parameters.AddWithValue("@MaTG", txtMaTG.Text);
                    cmd.Parameters.AddWithValue("@TenTG", txtTenTG.Text);
                    cmd.Parameters.AddWithValue("@LienLac", txtLienLac.Text);
                    int testCmd = cmd.ExecuteNonQuery();
                    if (testCmd > 0)
                    {
                        MessageBox.Show("Thêm thể loại thành công", "Thông báo");
                        load_DS_TacGia(constr);
                    }
                    else
                    {
                        MessageBox.Show("Thêm CTPN thất bại", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Đã tồn tại mã thể loại");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                load_DS_TacGia(constr);
                if (KiemTraDL() == false)
                {
                    MessageBox.Show("Chưa đủ dữ liệu");
                }
                else
                {
                    LayThongTin();
                    SqlCommand cmd = new SqlCommand(constr, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.proc_SuaTG";
                    cmd.Parameters.AddWithValue("@MaTG", txtMaTG.Text);
                    cmd.Parameters.AddWithValue("@TenTG", txtTenTG.Text);
                    cmd.Parameters.AddWithValue("@LienLac", txtLienLac.Text);

                    int testCmd = cmd.ExecuteNonQuery();
                    if (testCmd > 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo");
                        load_DS_TacGia(constr);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                if (txtMaTG.Text == "" || txtTenTG.Text == "" || txtLienLac.Text == "")
                {
                    MessageBox.Show("Chưa đủ dữ liệu");
                }
                else
                {
                    LayThongTin();
                    DialogResult dialogResult;
                    dialogResult = MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SqlCommand cmd = new SqlCommand(constr, conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.proc_XoaTG";
                        cmd.Parameters.AddWithValue("@MaTG", MaTG);

                        int testCmd = cmd.ExecuteNonQuery();
                        if (testCmd > 0)
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo");
                            load_DS_TacGia(constr);
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại", "Thông báo");
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // sự kiện form load
        private void TacGia_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            load_DS_TacGia(constr);
        }

        //view danh sách thể loại
        public void load_DS_TacGia(string constr)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM vwDS_TacGia", conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dgvDS_TacGia.DataSource = dataTable;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDS_TacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDS_TacGia.Rows.Count > 0)
                {
                    txtMaTG.Text = dgvDS_TacGia.CurrentRow.Cells["Mã TG"].Value.ToString();
                    txtTenTG.Text = dgvDS_TacGia.CurrentRow.Cells["Tên TG"].Value.ToString();
                    txtLienLac.Text = dgvDS_TacGia.CurrentRow.Cells["Liên lạc"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // kiểm tra khóa chính
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

        // Hàm kiểm tra dữ liệu trống
        public bool KiemTraDL()
        {
            if (txtMaTG.Text == "" || txtTenTG.Text == "" || txtLienLac.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
