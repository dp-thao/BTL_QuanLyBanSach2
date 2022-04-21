﻿using System;
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
            SoPN = txtSoPhieuNhap.Text;
            NgayNhap = DateTime.Parse(dateNgayNhap.Text);
            MaSach = txtMaSach.Text;
            MaNXB = cbMaNXB.SelectedValue.ToString();
            SoLuongNhap = float.Parse(txtSoLuongNhap.Text);
            GiaNhap = float.Parse(txtGiaNhap.Text);
            TenSach = txtTenSach.Text;
            MaTG = cbMaTG.SelectedValue.ToString();
            MaTL = cbMaTL.SelectedValue.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
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
                ThemSach(constr, conn);
            }
            conn.Close();
        }

        // Hàm kiểm tra dữ liệu trống
        public bool KiemTraDL()
        {
            if (txtSoPhieuNhap.Text == "" || txtMaSach.Text == "" || txtSoLuongNhap.Text == ""
                || txtGiaNhap.Text == "" || txtTenSach.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Thêm sách
        public void ThemSach(string constr, SqlConnection conn)
        {
            string sql = "SELECT * FROM tblSach WHERE sMaSach = '" + txtMaSach.Text + "'";

            if (!KiemTraKhoaChinh(constr, conn, sql))
            {
                SqlCommand cmd_Sach = new SqlCommand(constr, conn);
                cmd_Sach.CommandType = CommandType.StoredProcedure;
                cmd_Sach.CommandText = "dbo.Proc_ThemSach";
                cmd_Sach.Parameters.AddWithValue("@MaSach", MaSach);
                cmd_Sach.Parameters.AddWithValue("@TenSach", TenSach);
                cmd_Sach.Parameters.AddWithValue("@MaTL", MaTL);
                cmd_Sach.Parameters.AddWithValue("@MaNXB", MaNXB);
                cmd_Sach.Parameters.AddWithValue("@MaTG", MaTG);
                cmd_Sach.Parameters.AddWithValue("@SoLuongTon", SoLuongNhap);
                int testCmd_Sach = cmd_Sach.ExecuteNonQuery();
                if (testCmd_Sach > 0)
                {
                    ThemPhieuNhap(constr, conn);
                    //MessageBox.Show("Thêm Sách thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thêm Sách thất bại", "Thông báo");
                }
            }
        }

        // Phiếu nhập
        public void ThemPhieuNhap(string constr, SqlConnection conn)
        {
            string sql = "SELECT * FROM tblPhieuNhap WHERE sSoPN = '" + txtSoPhieuNhap.Text + "'";

            if (!KiemTraKhoaChinh(constr, conn, sql))
            {
                SqlCommand cmd_PhieuNhap = new SqlCommand(constr, conn);
                cmd_PhieuNhap.CommandType = CommandType.StoredProcedure;
                cmd_PhieuNhap.CommandText = "dbo.Proc_ThemPhieuNhap";
                cmd_PhieuNhap.Parameters.AddWithValue("@SoPN", SoPN);
                cmd_PhieuNhap.Parameters.AddWithValue("@NgayNhap", NgayNhap);
                cmd_PhieuNhap.Parameters.AddWithValue("@MaNXB", MaNXB);
                int testCmd_PhieuNhap = cmd_PhieuNhap.ExecuteNonQuery();
                if (testCmd_PhieuNhap > 0)
                {
                    ThemCTPN(constr, conn);
                    //MessageBox.Show("Thêm Phiếu nhập thành công", "Thông báo");
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

        // Chi tiết phiếu nhập
        public void ThemCTPN(string constr, SqlConnection conn)
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

        //vwDS_CTPN
        public void load_DS_CTPN(string constr)
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

        // Sự kiện Form Load danh sách phiếu nhập
        private void PhieuNhapSach_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            load_DS_CTPN(constr);

            // ComboBox
            HienDS_ComboBox_NXB();
            HienDS_ComboBox_TG();
            HienDS_ComboBox_TL();
        }

        // Sự kiện cập nhật Chi tiết phiếu nhập
        private void btnSua_Click(object sender, EventArgs e)
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
                /*string soPN = dgvDS_PhieuNhap.CurrentRow.Cells["Số PN"].Value.ToString();
                string maSach = dgvDS_PhieuNhap.CurrentRow.Cells["Mã sách"].Value.ToString();*/
                LayThongTin();
                SqlCommand cmd = new SqlCommand(constr, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.Proc_CapNhat_CTPN_Sach";
                cmd.Parameters.AddWithValue("@SoPN", SoPN);
                cmd.Parameters.AddWithValue("@MaSach", MaSach);
                cmd.Parameters.AddWithValue("@SoLuongNhap", SoLuongNhap);
                cmd.Parameters.AddWithValue("@GiaNhap", GiaNhap);
                cmd.Parameters.AddWithValue("@TenSach", TenSach);
                cmd.Parameters.AddWithValue("@MaTL", MaTL);
                cmd.Parameters.AddWithValue("@MaNXB", MaNXB);
                cmd.Parameters.AddWithValue("@MaTG", MaTG);

                int testCmd = cmd.ExecuteNonQuery();
                if (testCmd > 0)
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                    txtTongTien.Text = "";
                    txtSoPhieuNhap.Enabled = true;
                    txtMaSach.Enabled = true;
                    load_DS_CTPN(constr);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo");
                }
            }
        }

        // Sự kiện Xóa Chi tiết phiếu nhập
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            load_DS_CTPN(constr);

            if (txtSoPhieuNhap.Text == "" || txtMaSach.Text =="")
            {
                MessageBox.Show("Chưa đủ dữ liệu");
            }
            else
            {
                /*string soPN = dgvDS_PhieuNhap.CurrentRow.Cells["Số PN"].Value.ToString();
                string maSach = dgvDS_PhieuNhap.CurrentRow.Cells["Mã sách"].Value.ToString();*/
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

        private void dgvDS_CTPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDS_PhieuNhap.Rows.Count > 0)
            {
                txtSoPhieuNhap.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Số PN"].Value.ToString();
                txtMaSach.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Mã sách"].Value.ToString();
                txtTenSach.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Tên sách"].Value.ToString();
                txtSoLuongNhap.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Số lượng"].Value.ToString();
                txtGiaNhap.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Giá nhập"].Value.ToString();
                //ComboBox: NXB, Thể loại, Tác giả 
                cbMaNXB.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Tên NXB"].Value.ToString();
                cbMaTL.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Tên thể loại"].Value.ToString();
                cbMaTG.Text = dgvDS_PhieuNhap.CurrentRow.Cells["Tên tác giả"].Value.ToString();
            }
        }

        // Sự kiện Ghi phiếu nhập mới
        private void btnGhiPhieu_Click(object sender, EventArgs e)
        {
            txtMaSach.Clear();
            txtSoLuongNhap.Clear();
            txtGiaNhap.Clear();
            txtTenSach.Clear();
            if (txtSoPhieuNhap.Text != "")
            {
                txtSoPhieuNhap.Enabled = false;
                dateNgayNhap.Enabled = false;
                txtMaSach.Focus();
            }
            else
            {
                txtSoPhieuNhap.Focus();
            }
            txtTongTien.Text = "";
        }

        // Hàm load dánh sách CTPN Lập phiếu
        public void load_DS_CTPN_LapPhieu()
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

        // Sự kiện Lập phiếu nhập mới
        private void btnLapPhieuMoi_Click(object sender, EventArgs e)
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

        // Sự kiện tính Tổng tiền
        private void button1_Click(object sender, EventArgs e)
        {
            double tongTien = 0;
            for (int i = 0; i < dgvDS_PhieuNhap.Rows.Count; ++i)
            {
                tongTien += Convert.ToDouble(dgvDS_PhieuNhap.Rows[i].Cells[9].Value);
            }
            txtTongTien.Text = tongTien.ToString();
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

        // Hàm hiện danh sách Mã NXB vào ComboBox
        public void HienDS_ComboBox_NXB()
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tblNhaXuatBan", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            cbMaNXB.DataSource = dataTable;
            cbMaNXB.DisplayMember = "sTenNXB";
            cbMaNXB.ValueMember = "sMaNXB";

            conn.Close();
        }

        // Hàm hiện danh sách Mã Tác giả vào ComboBox
        public void HienDS_ComboBox_TG()
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tblTacGia", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            cbMaTG.DataSource = dataTable;
            cbMaTG.DisplayMember = "sTenTG";
            cbMaTG.ValueMember = "sMaTG";

            conn.Close();
        }

        // Hàm hiện danh sách Mã Thể loại vào ComboBox
        public void HienDS_ComboBox_TL()
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tblTheLoai", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            cbMaTL.DataSource = dataTable;
            cbMaTL.DisplayMember = "sTenTL";
            cbMaTL.ValueMember = "sMaTL";

            conn.Close();
        }

        // Sự kiện kiểm tra Số lượng nhập
        private void txtSoLuongNhap_Validating(object sender, CancelEventArgs e)
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

        // Sự kiện kiểm tra Mã Sách
        private void txtMaSach_Validating(object sender, CancelEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string MaSach = txtMaSach.Text;
            string sql = "SELECT * FROM tblSach WHERE sMaSach = '" + MaSach + "'";
            if (MaSach == "")
            {
                errorProvider1.SetError(txtMaSach, "Không được bỏ trống!");
            }
            else if (KiemTraKhoaChinh(constr, conn, sql))
            {
                errorProvider1.SetError(txtMaSach, "Mã tồn tại");
                txtMaSach.Focus();
            }
            else
            {
                errorProvider1.SetError(txtMaSach, "");
            }
            conn.Close();
        }

        public void LamSach()
        {
            txtSoPhieuNhap.Clear();
            txtMaSach.Clear();
            txtSoLuongNhap.Clear();
            txtGiaNhap.Clear();
            txtTenSach.Clear();
        }

    }
}
