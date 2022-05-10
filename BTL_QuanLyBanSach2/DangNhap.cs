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
using System.Text.RegularExpressions;

namespace BTL_QuanLyBanSach2
{
    public partial class DangNhap : Form
    {
        public static string UserName = "";

        public DangNhap()
        {
            InitializeComponent();
        }

        private void chkHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienThi.Checked)
            {
                txtMatKhau.PasswordChar = (char)0;
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

        int dem = 0;
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            int DNThanhCong = 0;
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(constr, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.Proc_DangNhap";
                cmd.Parameters.AddWithValue("@TaiKhoan", txtTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);

                UserName = txtTaiKhoan.Text;

                object kq = cmd.ExecuteScalar();
                int code = Convert.ToInt32(kq);

                if (code == 0)
                {
                    MessageBox.Show("Chào mừng User đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DNThanhCong++;

                }
                else if (code == 1)
                {
                    MessageBox.Show("Chào mừng Admin đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DNThanhCong++;

                }
                else if (code == 2)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatKhau.Text = "";
                    txtTaiKhoan.Text = "";
                    txtTaiKhoan.Focus();
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatKhau.Text = "";
                    txtTaiKhoan.Text = "";
                    txtTaiKhoan.Focus();
                }

                // đăng nhập thành công
                if (DNThanhCong > 0)
                {
                    SqlCommand cmd2 = new SqlCommand(constr, conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.CommandText = "Proc_LayNhanVienTheoTaiKhoan";
                    cmd2.Parameters.AddWithValue("@TaiKhoan", txtTaiKhoan.Text);
                    cmd2.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = cmd2;
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        session.TenNhanVien = dataTable.Rows[0]["sTenNV"].ToString();
                        session.MaNhanVien = dataTable.Rows[0]["sMaNV"].ToString();
                    }
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Hide();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTaiKhoan_MouseClick(object sender, MouseEventArgs e)
        {
            txtTaiKhoan.SelectAll();
        }

        private void txtMatKhau_MouseClick(object sender, MouseEventArgs e)
        {
            txtMatKhau.SelectAll();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private static bool CheckPass(string password)
        {
            bool Kitu_dacbiet = false;
            for (int i = 0; i < password.Length; i++)
            {
                if ((password[i] >= 32 && password[i] <= 47)
                   || (password[i] >= 58 && password[i] <= 64)
                   || (password[i] >= 91 && password[i] <= 96)
                   || (password[i] >= 123 && password[i] <= 126))
                {
                    Kitu_dacbiet = true;
                }
            }
            return Regex.IsMatch(password, @"[A-Z]")
                   && Regex.IsMatch(password, @"[0-9]")
                   && Kitu_dacbiet
                   && password.Length > 6;
        }

        private void txtMatKhau_Validating(object sender, CancelEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string matkhau = txtMatKhau.Text;
            if (!CheckPass(matkhau))
            {
                errorProvider1.SetError(txtMatKhau, "Mật khẩu phải 6 kí tự, có chữ số, chữ hoa");
            }
            else
            {
                errorProvider1.SetError(txtMatKhau, "");
            }
            conn.Close();
        }

        private void txtTaiKhoan_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtMatKhau, "");
        }

        //Tối thiểu tám ký tự, ít nhất một chữ cái viết hoa, một chữ cái viết thường, một số và một ký tự đặc biệt:
        //"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"
    }
}
