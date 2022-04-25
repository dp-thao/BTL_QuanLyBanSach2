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
    public partial class Sach : Form
    {
        public Sach()
        {
            InitializeComponent();
        }

        string MaSach, TenSach, MaTL, MaTG, MaNXB;

        public void LayThongTin()
        {
            MaSach = txtMaSach.Text;
            TenSach = txtTenSach.Text;
            MaTL = cbTheLoai.SelectedValue.ToString();
            MaTG = cbTacGia.SelectedValue.ToString();
            MaNXB = cbNXB.SelectedValue.ToString();
        }

        public void LamSach()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
        }

        // Hàm hiện danh sách Thể loại vào ComboBox
        public void HienDS_ComboBox_MaTL()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tblTheLoai", conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                cbTheLoai.DisplayMember = "sTenTL";
                cbTheLoai.ValueMember = "sMaTL";
                cbTheLoai.DataSource = dataTable;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Hàm hiện danh sách Tác giả vào ComboBox
        public void HienDS_ComboBox_MaTG()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tblTacGia", conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                cbTacGia.DisplayMember = "sTenTG";
                cbTacGia.ValueMember = "sMaTG";
                cbTacGia.DataSource = dataTable;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Hàm hiện danh sách Tác giả vào ComboBox
        public void HienDS_ComboBox_MaNXB()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tblNhaXuatBan", conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                cbNXB.DisplayMember = "sTenNXB";
                cbNXB.ValueMember = "sMaNXB";
                cbNXB.DataSource = dataTable;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // sự kiện form load
        private void Sach_Load(object sender, EventArgs e)
        {
            HienDS_ComboBox_MaTL();
            HienDS_ComboBox_MaTG();
            HienDS_ComboBox_MaNXB();
            load_DS_Sach();
        }

        //viewDS_Sach
        public void load_DS_Sach()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM vwDS_Sach", conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dgvDS_Sach.DataSource = dataTable;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDS_Sach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDS_Sach.Rows.Count > 0)
                {
                    txtMaSach.Text = dgvDS_Sach.CurrentRow.Cells["Mã sách"].Value.ToString();
                    txtTenSach.Text = dgvDS_Sach.CurrentRow.Cells["Tên sách"].Value.ToString();
                    cbNXB.Text = dgvDS_Sach.CurrentRow.Cells["Tên NXB"].Value.ToString();
                    cbTheLoai.Text = dgvDS_Sach.CurrentRow.Cells["Tên TL"].Value.ToString();
                    cbTacGia.Text = dgvDS_Sach.CurrentRow.Cells["Tên TG"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSLTon_TextChanged(object sender, EventArgs e)
        {

        }

        // sự kiện thêm sách
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                LayThongTin();
                string sql = "SELECT * FROM tblSach WHERE sMaSach = N'" + txtMaSach.Text + "'";
                if (!KiemTraKhoaChinh(constr, conn, sql))
                {
                    SqlCommand cmd = new SqlCommand(constr, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.proc_ThemSach";
                    cmd.Parameters.AddWithValue("@MaSach", MaSach);
                    cmd.Parameters.AddWithValue("@TenSach", TenSach);
                    cmd.Parameters.AddWithValue("@MaTL", MaTL);
                    cmd.Parameters.AddWithValue("@MaNXB", MaNXB);
                    cmd.Parameters.AddWithValue("@MaTG", MaTG);

                    int testCmd_CTPN = cmd.ExecuteNonQuery();
                    if (testCmd_CTPN > 0)
                    {
                        MessageBox.Show("Thêm Sách thành công", "Thông báo");
                        load_DS_Sach();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Sách thất bại", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Đã tồn tại phiếu nhập");
                }
                conn.Close();
            }
            catch(Exception ex)
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
                load_DS_Sach();

                if (KiemTraDL() == false)
                {
                    MessageBox.Show("Chưa đủ dữ liệu");
                }
                else
                {
                    LayThongTin();
                    SqlCommand cmd = new SqlCommand(constr, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.proc_SuaSach";
                    cmd.Parameters.AddWithValue("@MaSach", MaSach);
                    cmd.Parameters.AddWithValue("@TenSach", TenSach);
                    cmd.Parameters.AddWithValue("@MaTL", MaTL);
                    cmd.Parameters.AddWithValue("@MaNXB", MaNXB);
                    cmd.Parameters.AddWithValue("@MaTG", MaTG);

                    int testCmd = cmd.ExecuteNonQuery();
                    if (testCmd > 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo");
                        load_DS_Sach();
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

                if (txtMaSach.Text == "" || txtTenSach.Text == "")
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
                        cmd.CommandText = "dbo.proc_XoaSach";
                        cmd.Parameters.AddWithValue("@MaSach", MaSach);

                        int testCmd = cmd.ExecuteNonQuery();
                        if (testCmd > 0)
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo");
                            load_DS_Sach();
                            LamSach();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại", "Thông báo");
                        }
                    }
                }
                conn.Close();
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
            if (txtMaSach.Text == "" || txtTenSach.Text == "")
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
