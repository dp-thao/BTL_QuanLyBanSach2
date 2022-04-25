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
    public partial class HoaDonBan : Form
    {
        public HoaDonBan()
        {
            InitializeComponent();
        }

        string SoHD, NgayBan, MaSach, TenSach, SLBan, GiaBan;

        public void LayThongTin()
        {
            SoHD = txtSoHD.Text;
            NgayBan = dateNgayBan.Text;
            MaSach = cbTenSach.SelectedValue.ToString();
            TenSach = cbTenSach.Text;
            SLBan = txtSLBan.Text;
            GiaBan = txtGiaBan.Text;
        }

        public void LamSach()
        {
            txtSoHD.Clear();
            txtMaSach.Clear();
            txtSLBan.Clear();
            txtGiaBan.Clear();
        }

        // Hàm kiểm tra dữ liệu trống
        public bool KiemTraDL()
        {
            if (txtSoHD.Text == "" || txtSLBan.Text == "" || txtGiaBan.Text == "")
            {
                return false;
            }
            else
            {
                return true;
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

        // Hóa đơn
        public void ThemHoaDon(string constr, SqlConnection conn)
        {
            try
            {
                string sql = "SELECT * FROM tblHoaDon WHERE sSoHD = '" + txtSoHD.Text + "'";

                if (!KiemTraKhoaChinh(constr, conn, sql))
                {
                    SqlCommand cmd_PhieuNhap = new SqlCommand(constr, conn);
                    cmd_PhieuNhap.CommandType = CommandType.StoredProcedure;
                    cmd_PhieuNhap.CommandText = "dbo.Proc_ThemHoaDon";
                    cmd_PhieuNhap.Parameters.AddWithValue("@SoHD", SoHD);
                    cmd_PhieuNhap.Parameters.AddWithValue("@NgayBan", NgayBan);
                    cmd_PhieuNhap.Parameters.AddWithValue("@MaNV", session.MaNhanVien);
                    int testCmd_PhieuNhap = cmd_PhieuNhap.ExecuteNonQuery();
                    if (testCmd_PhieuNhap > 0)
                    {
                        ThemCTHD(constr, conn);
                    }
                    else
                    {
                        MessageBox.Show("Thêm Hóa đơn thất bại", "Thông báo");
                    }
                }
                else
                {
                    ThemCTHD(constr, conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Chi tiết hóa đơn
        public void ThemCTHD(string constr, SqlConnection conn)
        {
            try
            {
                string sql = "SELECT * FROM tblChiTietHoaDon WHERE sSoHD = N'" + txtSoHD.Text + "' AND sMaSach = N'" + txtMaSach.Text + "'";
                if (!KiemTraKhoaChinh(constr, conn, sql))
                {
                    SqlCommand cmd_CTPN = new SqlCommand(constr, conn);
                    cmd_CTPN.CommandType = CommandType.StoredProcedure;
                    cmd_CTPN.CommandText = "dbo.Proc_ThemCTHD";
                    cmd_CTPN.Parameters.AddWithValue("@SoHD", @SoHD);
                    cmd_CTPN.Parameters.AddWithValue("@MaSach", MaSach);
                    cmd_CTPN.Parameters.AddWithValue("@SoLuongBan", SLBan);
                    cmd_CTPN.Parameters.AddWithValue("@GiaBan", GiaBan);

                    int testCmd_CTPN = cmd_CTPN.ExecuteNonQuery();
                    if (testCmd_CTPN > 0)
                    {
                        MessageBox.Show("Thêm CTHD thành công", "Thông báo");
                        load_DS_CTHD(constr);
                    }
                    else
                    {
                        MessageBox.Show("Thêm CTHD thất bại", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Đã tồn tại hóa đơn");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //vwDS_CTPN
        public void load_DS_CTHD(string constr)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM vwDS_CTHD", conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dgvDS_HoaDon.DataSource = dataTable;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        // sự kiện form load
        private void HoaDonBan_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            load_DS_CTHD(constr);
            HienDS_ComboBox_Sach();
        }

        // sự kiện chọn tên sách
        private void cbTenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaSach.Text = cbTenSach.SelectedValue.ToString();
        }

        private void dgvDS_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDS_HoaDon.Rows.Count > 0)
                {
                    txtSoHD.Text = dgvDS_HoaDon.CurrentRow.Cells["Số HD"].Value.ToString();
                    txtMaSach.Text = dgvDS_HoaDon.CurrentRow.Cells["Mã sách"].Value.ToString();
                    txtSLBan.Text = dgvDS_HoaDon.CurrentRow.Cells["Số lượng"].Value.ToString();
                    txtGiaBan.Text = dgvDS_HoaDon.CurrentRow.Cells["Giá bán"].Value.ToString();
                    cbTenSach.Text = dgvDS_HoaDon.CurrentRow.Cells["Tên sách"].Value.ToString();
                    dateNgayBan.Text = dgvDS_HoaDon.CurrentRow.Cells["Ngày Bán"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // sự kiện Ghi phiếu
        private void btnGhiPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaSach.Clear();
                txtSLBan.Clear();
                txtGiaBan.Clear();
                if (txtSoHD.Text != "")
                {
                    txtSoHD.Enabled = false;
                    dateNgayBan.Enabled = false;
                    txtSLBan.Focus();
                }
                else
                {
                    txtSoHD.Focus();
                }
                txtTongTien.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // sự kiện Lập phiếu
        private void btnLapPhieuMoi_Click(object sender, EventArgs e)
        {
            try
            {
                LamSach();
                txtSoHD.Focus();
                if (txtSoHD.Text == "")
                {
                    txtSoHD.Enabled = true;
                    dateNgayBan.Enabled = true;
                }
                txtTongTien.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // sự kiện tính tiền
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            try
            {
                double tongTien = 0;
                for (int i = 0; i < dgvDS_HoaDon.Rows.Count; ++i)
                {
                    tongTien += Convert.ToDouble(dgvDS_HoaDon.Rows[i].Cells[7].Value);
                }
                txtTongTien.Text = tongTien.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // sự kiện Thêm hóa đơn
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                load_DS_CTHD(constr);

                if (KiemTraDL() == false)
                {
                    MessageBox.Show("Chưa đủ dữ liệu");
                }
                else
                {
                    LayThongTin();
                    ThemHoaDon(constr, conn);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // sự kiện Sửa hóa đơn
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                load_DS_CTHD(constr);

                if (KiemTraDL() == false)
                {
                    MessageBox.Show("Chưa đủ dữ liệu");
                }
                else
                {
                    LayThongTin();
                    SqlCommand cmd = new SqlCommand(constr, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.Proc_CapNhat_CTHD";
                    cmd.Parameters.AddWithValue("@SoHD", SoHD);
                    cmd.Parameters.AddWithValue("@MaSach", MaSach);
                    cmd.Parameters.AddWithValue("@SoLuongBan", SLBan);
                    cmd.Parameters.AddWithValue("@GiaBan", GiaBan);

                    int testCmd = cmd.ExecuteNonQuery();
                    if (testCmd > 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo");
                        txtTongTien.Text = "";
                        txtSoHD.Enabled = true;
                        txtMaSach.Enabled = true;
                        HienDS_ComboBox_Sach();
                        load_DS_CTHD(constr);
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

        // sự kiện Xóa hóa đơn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                if (txtSoHD.Text == "" || txtMaSach.Text == "")
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
                        cmd.CommandText = "dbo.Proc_Xoa_CTHD";
                        cmd.Parameters.AddWithValue("@SoHD", SoHD);
                        cmd.Parameters.AddWithValue("@MaSach", MaSach);

                        int testCmd = cmd.ExecuteNonQuery();
                        if (testCmd > 0)
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo");
                            HienDS_ComboBox_Sach();
                            load_DS_CTHD(constr);
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
    }
}
