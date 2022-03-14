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

        string SoPN, MaNXB, MaSach, TenSach, MaTG, MaTL;
        DateTime NgayNhap;
        float SoLuongNhap;
        float GiaNhap;
        int kiemtra = 0;

        public void LayThongTin()
        {
            SoPN = txtSoPhieuNhap.Text;
            NgayNhap = DateTime.Parse(dateNgayNhap.Text);
            MaNXB = txtNhaXuatBan.Text;
            MaSach = txtMaSach.Text;
            SoLuongNhap = float.Parse(txtSoLuongNhap.Text);
            GiaNhap = float.Parse(txtGiaNhap.Text);
            TenSach = txtTenSach.Text;
            MaTG = txtMaTG.Text;
            MaTL = txtMaTL.Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LayThongTin();
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            Them_MaTL(constr, conn);
            Them_MaTG(constr, conn);
            ThemSach(constr, conn);
            ThemPhieuNhap(constr, conn);
            ThemCTPN(constr, conn);
            conn.Close();
        }

        // Thêm Mã thể loại
        public void Them_MaTL(string constr, SqlConnection conn)
        {
            string sql = "SELECT * FROM tblTheLoai WHERE sMaTL = '" + txtMaTL.Text + "'";
            
            if (!KiemTraKhoaChinh(constr, conn, sql))
            {
                SqlCommand cmd_MaTL = new SqlCommand(constr, conn);
                cmd_MaTL.CommandType = CommandType.Text;
                cmd_MaTL.CommandText = "INSERT INTO tblTheLoai (sMaTL) VALUES (N'" + MaTL + "')";
                int testCmd_MaTL = cmd_MaTL.ExecuteNonQuery();
                if (testCmd_MaTL > 0)
                {
                    MessageBox.Show("Thêm Thể loại thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thêm Thể loại thất bại", "Thông báo");
                }
            }
        }

        // Thêm Mã nhà xuất bản
        public void Them_MaNXB(string constr, SqlConnection conn)
        {
            string sql = "SELECT * FROM tblNhaXuatBan WHERE sMaNXB = '" + txtNhaXuatBan.Text + "'";
           
            if (!KiemTraKhoaChinh(constr, conn, sql))
            {
                SqlCommand cmd_MaNXB = new SqlCommand(constr, conn);
                cmd_MaNXB.CommandType = CommandType.Text;
                cmd_MaNXB.CommandText = "INSERT INTO tblNhaXuatBan (sMaNXB) VALUES (N'" + MaNXB + "')";
                int testCmd_MaNXB = cmd_MaNXB.ExecuteNonQuery();
                if (testCmd_MaNXB > 0)
                {
                    MessageBox.Show("Thêm Mã NXB thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thêm Mã NXB thất bại", "Thông báo");
                }
            }
        }

        // Thêm Mã tác giả
        public void Them_MaTG(string constr, SqlConnection conn)
        {
            string sql = "SELECT * FROM tblTacGia WHERE sMaTG = '" + txtMaTG.Text + "'";
            
            if (!KiemTraKhoaChinh(constr, conn, sql))
            {
                SqlCommand cmd_MaTG = new SqlCommand(constr, conn);
                cmd_MaTG.CommandType = CommandType.Text;
                cmd_MaTG.CommandText = "INSERT INTO tblTacGia (sMaTG) VALUES (N'" + MaTG + "')";
                int testCmd_MaTG = cmd_MaTG.ExecuteNonQuery();
                if (testCmd_MaTG > 0)
                {
                    MessageBox.Show("Thêm Tác giả thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thêm Tác giả thất bại", "Thông báo");
                }
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
                    MessageBox.Show("Thêm Sách thành công", "Thông báo");
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
                    MessageBox.Show("Thêm Phiếu nhập thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thêm Phiếu nhập thất bại", "Thông báo");
                }
            }            
        }

        // Chi tiết phiếu nhập
        public void ThemCTPN(string constr, SqlConnection conn)
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

        // Hàm load dánh sách
        public void load_DS_CTPN(string constr)
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM vwDS_CTPN", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvDS_CTPN.DataSource = dataTable;
        }

        // Sự kiện load danh sách phiếu nhập
        private void PhieuNhapSach_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            load_DS_CTPN(constr);
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

        // Sự kiện kiểm tra Mã nhà xuất bản
        private void txtNhaXuatBan_Validating(object sender, CancelEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string MaNXB = txtNhaXuatBan.Text;
            string sql = "SELECT * FROM tblNhaXuatBan WHERE sMaNXB = '" + MaNXB + "'";
            if (MaNXB == "")
            {
                errorProvider1.SetError(txtNhaXuatBan, "Không được bỏ trống!");
            }
            else
            {
                errorProvider1.SetError(txtNhaXuatBan, "");
            }
            /*else if (KiemTraKhoaChinh(constr, conn, sql))
            {
                errorProvider1.SetError(txtNhaXuatBan, "Mã tồn tại");
                txtNhaXuatBan.Focus();
            }*/
            conn.Close();
        }

        // Sự kiện kiểm tra Mã Thể loại
        private void txtMaTL_Validating(object sender, CancelEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string MaTL = txtMaTL.Text;
            string sql = "SELECT * FROM tblTheLoai WHERE sMaTL = '" + MaTL + "'";
            if (MaTL == "")
            {
                errorProvider1.SetError(txtMaTL, "Không được bỏ trống!");
            }
            else
            {
                errorProvider1.SetError(txtMaTL, "");
            }
            /*else if (KiemTraKhoaChinh(constr, conn, sql))
            {
                errorProvider1.SetError(txtMaTL, "Mã tồn tại");
                txtMaTL.Focus();
            }*/
            conn.Close();
        }

        // Sự kiện kiểm tra Mã Tác giả
        private void txtMaTG_Validating(object sender, CancelEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string MaTG = txtMaTG.Text;
            string sql = "SELECT * FROM tblTacGia WHERE sMaTG = '" + MaTG + "'";
            if(MaTG == "")
            {
                errorProvider1.SetError(txtMaTG, "Không được bỏ trống!");
            }
            else
            {
                errorProvider1.SetError(txtMaTG, "");
            }
            /*else if (KiemTraKhoaChinh(constr, conn, sql))
            {
                errorProvider1.SetError(txtMaTG, "Mã tồn tại!");
                txtMaTG.Focus();
            }*/
            conn.Close();
        }

        // Sự kiện cập nhật
        private void dgvDS_CTPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
