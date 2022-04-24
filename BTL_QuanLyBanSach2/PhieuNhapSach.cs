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
    public partial class PhieuNhapSach : Form
    {
        public PhieuNhapSach()
        {
            InitializeComponent();
        }

        string SoPN, MaSach, MaNXB, TenSach, MaTG, MaTL;
        DateTime NgayNhap;
        float SoLuongNhap;
        float GiaNhap;

        public void LayThongTin()
        {
            try
            {
                SoPN = txtSoPhieuNhap.Text;
                NgayNhap = DateTime.Parse(dateNgayNhap.Text);
                MaSach = txtMaSach.Text;
                MaNXB = txtNXB.Text;
                SoLuongNhap = float.Parse(txtSoLuongNhap.Text);
                GiaNhap = float.Parse(txtGiaNhap.Text);
                TenSach = cbTenSach.SelectedText.ToString();
                MaTG = txtTacGia.Text;
                MaTL = txtTheLoai.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                load_DS_CTPN(constr);

                if (KiemTraDL() == false)
                {
                    MessageBox.Show("Chưa đủ dữ liệu");
                }
                else
                {
                    LayThongTin();
                    ThemPhieuNhap(constr, conn);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Hàm kiểm tra dữ liệu trống
        public bool KiemTraDL()
        {
            if (txtSoPhieuNhap.Text == "" || txtMaSach.Text == "" || txtSoLuongNhap.Text == ""
                || txtGiaNhap.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Phiếu nhập
        public void ThemPhieuNhap(string constr, SqlConnection conn)
        {
            try
            {
                string sql = "SELECT * FROM tblPhieuNhap WHERE sSoPN = '" + txtSoPhieuNhap.Text + "'";

                SqlCommand cmd = new SqlCommand(constr, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.Proc_NXB_sMaNXB";
                cmd.Parameters.AddWithValue("@masach", cbTenSach.SelectedValue.ToString());
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read() && sqlDataReader.HasRows)
                {
                    int columnNumber = sqlDataReader.GetOrdinal("sMaNXB");
                    MaNXB = sqlDataReader.GetString(columnNumber);
                }
                sqlDataReader.Close();

                if (!KiemTraKhoaChinh(constr, conn, sql))
                {
                    SqlCommand cmd_PhieuNhap = new SqlCommand(constr, conn);
                    cmd_PhieuNhap.CommandType = CommandType.StoredProcedure;
                    cmd_PhieuNhap.CommandText = "dbo.Proc_ThemPhieuNhap";
                    cmd_PhieuNhap.Parameters.AddWithValue("@SoPN", SoPN);
                    cmd_PhieuNhap.Parameters.AddWithValue("@NgayNhap", NgayNhap);
                    cmd_PhieuNhap.Parameters.AddWithValue("@MaNXB", MaNXB);
                    cmd_PhieuNhap.Parameters.AddWithValue("@MaNV", session.MaNhanVien);
                    int testCmd_PhieuNhap = cmd_PhieuNhap.ExecuteNonQuery();
                    if (testCmd_PhieuNhap > 0)
                    {
                        ThemCTPN(constr, conn);
                    }
                    else
                    {
                        MessageBox.Show("Thêm Phiếu nhập thất bại", "Thông báo");
                    }
                }
                else
                {
                    ThemCTPN(constr, conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Chi tiết phiếu nhập
        public void ThemCTPN(string constr, SqlConnection conn)
        {
            try
            {
                string sql = "SELECT * FROM tblChiTietPhieuNhap WHERE sSoPN = N'" + txtSoPhieuNhap.Text + "' AND sMaSach = N'" + txtMaSach.Text + "'";
                if (!KiemTraKhoaChinh(constr, conn, sql))
                {
                    SqlCommand cmd_CTPN = new SqlCommand(constr, conn);
                    cmd_CTPN.CommandType = CommandType.StoredProcedure;
                    cmd_CTPN.CommandText = "dbo.Proc_ThemCTPN";
                    cmd_CTPN.Parameters.AddWithValue("@SoPN", SoPN);
                    cmd_CTPN.Parameters.AddWithValue("@MaSach", MaSach);
                    cmd_CTPN.Parameters.AddWithValue("@SoLuongNhap", SoLuongNhap);
                    cmd_CTPN.Parameters.AddWithValue("@GiaNhap", GiaNhap);

                    int testCmd_CTPN = cmd_CTPN.ExecuteNonQuery();
                    if (testCmd_CTPN > 0)
                    {
                        MessageBox.Show("Thêm CTPN thành công", "Thông báo");
                        load_DS_CTPN(constr);
                    }
                    else
                    {
                        MessageBox.Show("Thêm CTPN thất bại", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Đã tồn tại phiếu nhập");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //vwDS_CTPN
        public void load_DS_CTPN(string constr)
        {
           try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM vwDS_CTPN", conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dgvDS_PhieuNhap.DataSource = dataTable;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sự kiện Form Load danh sách phiếu nhập
        private void PhieuNhapSach_Load(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                load_DS_CTPN(constr);
                HienDS_ComboBox_Sach();
                txtTenNV.Text = session.TenNhanVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sự kiện cập nhật Chi tiết phiếu nhập
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                load_DS_CTPN(constr);

                errorProvider1.SetError(txtSoPhieuNhap, "");

                if (KiemTraDL() == false)
                {
                    MessageBox.Show("Chưa đủ dữ liệu");
                }
                else
                {
                    LayThongTin();
                    SqlCommand cmd = new SqlCommand(constr, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.Proc_CapNhat_CTPN_Sach";
                    cmd.Parameters.AddWithValue("@SoPN", SoPN);
                    cmd.Parameters.AddWithValue("@MaSach", MaSach);
                    cmd.Parameters.AddWithValue("@SoLuongNhap", SoLuongNhap);
                    cmd.Parameters.AddWithValue("@GiaNhap", GiaNhap);

                    int testCmd = cmd.ExecuteNonQuery();
                    if (testCmd > 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo");
                        txtTongTien.Text = "";
                        txtSoPhieuNhap.Enabled = true;
                        txtMaSach.Enabled = true;
                        HienDS_ComboBox_Sach();
                        load_DS_CTPN(constr);
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

        // Sự kiện Xóa Chi tiết phiếu nhập
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                if (txtSoPhieuNhap.Text == "" || txtMaSach.Text == "")
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
                        cmd.CommandText = "dbo.Proc_Xoa_CTPN_Sach_PhieuNhap";
                        cmd.Parameters.AddWithValue("@SoPN", SoPN);
                        cmd.Parameters.AddWithValue("@MaSach", MaSach);

                        int testCmd = cmd.ExecuteNonQuery();
                        if (testCmd > 0)
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo");
                            HienDS_ComboBox_Sach();
                            load_DS_CTPN(constr);
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

        private void dgvDS_CTPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDS_PhieuNhap.Rows.Count > 0)
                {
                    txtSoPhieuNhap.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Số PN"].Value.ToString();
                    txtMaSach.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Mã sách"].Value.ToString();
                    txtSoLuongNhap.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Số lượng"].Value.ToString();
                    txtGiaNhap.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Giá nhập"].Value.ToString();
                    cbTenSach.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Tên sách"].Value.ToString();
                    txtNXB.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Tên NXB"].Value.ToString();
                    txtTheLoai.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Tên thể loại"].Value.ToString();
                    txtTacGia.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Tên tác giả"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sự kiện Ghi phiếu nhập mới
        private void btnGhiPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaSach.Clear();
                txtSoLuongNhap.Clear();
                txtGiaNhap.Clear();
                if (txtSoPhieuNhap.Text != "")
                {
                    txtSoPhieuNhap.Enabled = false;
                    dateNgayNhap.Enabled = false;
                    txtSoLuongNhap.Focus();
                }
                else
                {
                    txtSoPhieuNhap.Focus();
                }
                txtTongTien.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Hàm load dánh sách CTPN Lập phiếu
        public void load_DS_CTPN_LapPhieu()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                SqlCommand cmd = new SqlCommand(constr, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.Proc_DS_CTPN_NgayNhap";
                cmd.Parameters.AddWithValue("@NgayNhap", dateNgayNhap.Text);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = cmd;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dgvDS_PhieuNhap.DataSource = dataTable;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sự kiện Lập phiếu nhập mới
        private void btnLapPhieuMoi_Click(object sender, EventArgs e)
        {
            try
            {
                LamSach();
                txtSoPhieuNhap.Focus();
                if (txtSoPhieuNhap.Text == "")
                {
                    txtSoPhieuNhap.Enabled = true;
                    dateNgayNhap.Enabled = true;
                }
                load_DS_CTPN_LapPhieu();
                txtTongTien.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sự kiện tính Tổng tiền
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double tongTien = 0;
                for (int i = 0; i < dgvDS_PhieuNhap.Rows.Count; ++i)
                {
                    tongTien += Convert.ToDouble(dgvDS_PhieuNhap.Rows[i].Cells[10].Value);
                }
                txtTongTien.Text = tongTien.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Hàm hiển thị danh sách Phiếu nhập sách
        private void btnPhieuNhapSach_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            load_DS_CTPN(constr);
        }

        // Hàm hiển thị danh sách CTPN
        private void btnCTPN_Click(object sender, EventArgs e)
        {
            DS_CTPN dS_CTPN = new DS_CTPN();            
            dS_CTPN.Show();
        }

        // Hàm hiện danh sách Sách vào ComboBox
        public void HienDS_ComboBox_Sach()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tblSach", conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                cbTenSach.DisplayMember = "sTenSach";
                cbTenSach.ValueMember = "sMaSach";
                cbTenSach.DataSource = dataTable;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbTenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaSach.Text = cbTenSach.SelectedValue.ToString();
                //DataTable tblSource = (DataTable)cbTenSach.DataSource;
                //txtMaSach.Text = tblSource.Rows[cbTenSach.SelectedIndex]["sMaSach"].ToString();
                txtTenNXB();
                txtTenTG();
                txtTenTL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void txtTenNXB()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(constr, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.Proc_NXB";
                cmd.Parameters.AddWithValue("@masach", cbTenSach.SelectedValue.ToString());
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read() && sqlDataReader.HasRows)
                {
                    int columnNumber = sqlDataReader.GetOrdinal("sTenNXB");
                    txtNXB.Text = sqlDataReader.GetString(columnNumber);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void txtTenTG()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(constr, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.Proc_TacGia";
                cmd.Parameters.AddWithValue("@masach", cbTenSach.SelectedValue.ToString());
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read() && sqlDataReader.HasRows)
                {
                    int columnNumber = sqlDataReader.GetOrdinal("sTenTG");
                    txtTacGia.Text = sqlDataReader.GetString(columnNumber);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void txtTenTL()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(constr, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.Proc_TheLoai";
                cmd.Parameters.AddWithValue("@masach", cbTenSach.SelectedValue.ToString());
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read() && sqlDataReader.HasRows)
                {
                    int columnNumber = sqlDataReader.GetOrdinal("sTenTL");
                    txtTheLoai.Text = sqlDataReader.GetString(columnNumber);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sự kiện kiểm tra Số lượng nhập
        private void txtSoLuongNhap_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtSoLuongNhap.Text == "")
                {
                    errorProvider1.SetError(txtSoLuongNhap, "Không được bỏ trống");
                }
                else
                {
                    try
                    {
                        if (float.Parse(txtSoLuongNhap.Text) <= 0)
                        {
                            MessageBox.Show("Số lượng nhập phải lớn hơn 0");
                        }
                        else
                        {
                            errorProvider1.SetError(txtSoLuongNhap, "");
                        }
                    }
                    catch
                    {
                        errorProvider1.SetError(txtSoLuongNhap, "Nhập sai định dạng");
                    }
                }
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

        // Sự kiện kiểm tra Mã Phiếu nhập
        private void txtSoPhieuNhap_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                string SoPN = txtSoPhieuNhap.Text;
                string sql = "SELECT * FROM tblPhieuNhap WHERE sSoPN = '" + SoPN + "'";

                if (SoPN == "")
                {
                    errorProvider1.SetError(txtSoPhieuNhap, "Không được bỏ trống!");
                }
                else if (KiemTraKhoaChinh(constr, conn, sql))
                {
                    errorProvider1.SetError(txtSoPhieuNhap, "Mã tồn tại");
                    txtSoPhieuNhap.Focus();
                }
                else
                {
                    errorProvider1.SetError(txtSoPhieuNhap, "");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LamSach()
        {
            txtSoPhieuNhap.Clear();
            txtMaSach.Clear();
            txtSoLuongNhap.Clear();
            txtGiaNhap.Clear();
            txtNXB.Clear();
            txtTacGia.Clear();
            txtTheLoai.Clear();
        }

    }
}
