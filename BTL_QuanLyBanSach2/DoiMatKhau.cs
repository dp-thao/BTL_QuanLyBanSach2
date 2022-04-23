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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void chkHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienThi.Checked)
            {
                txtMatKhau.PasswordChar = (char)0;
                txtMatKhauMoi.PasswordChar = (char)0;
                txtXacNhanMK.PasswordChar = (char)0;
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
                txtMatKhauMoi.PasswordChar = '*';
                txtXacNhanMK.PasswordChar = '*';
            }
        }

        // Kiểm tra xem người dùng đã nhập đầy đủ thông tin hay chưa
        public bool KiemTra()
        {
            if (txtTaiKhoan.Text == "")
            {
                /*lblShowInfor.ForeColor = System.Drawing.Color.Red;
                lblShowInfor.Text = "Vui lòng nhập tên tài khoản !!";*/
                txtTaiKhoan.Focus();
                return false;
            }
            else if (txtMatKhau.Text == "")
            {
                /*lblShowInfor.ForeColor = System.Drawing.Color.Red;
                lblShowInfor.Text = "Vui lòng nhập mật khẩu hiện tại !!";*/
                txtMatKhau.Focus();
                return false;
            }
            else if (txtMatKhauMoi.Text == "")
            {
                /*lblShowInfor.ForeColor = System.Drawing.Color.Red;
                lblShowInfor.Text = "Vui lòng nhập mật khẩu mới !!";*/
                txtMatKhauMoi.Focus();
                return false;
            }
            else if (txtXacNhanMK.Text == "")
            {
                /*lblShowInfor.ForeColor = System.Drawing.Color.Red;
                lblShowInfor.Text = "Vui lòng xác nhận mật khẩu !!";*/
                txtXacNhanMK.Focus();
                return false;
            }
            else if (txtMatKhauMoi.Text != txtXacNhanMK.Text)
            {
                /*lblShowInfor.ForeColor = System.Drawing.Color.Red;
                lblShowInfor.Text = "Mật khẩu mới và mật khẩu xác nhận không trùng khớp";*/
                txtXacNhanMK.Focus();
                txtXacNhanMK.SelectAll();
                return false;
            }
            return true;
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                    SqlConnection conn = new SqlConnection(constr);
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(constr, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.Proc_DoiMK";
                    cmd.Parameters.AddWithValue("@TaiKhoan", txtTaiKhoan.Text);
                    cmd.Parameters.AddWithValue("@MKCu", txtMatKhau.Text);
                    cmd.Parameters.AddWithValue("@MKMoi", txtMatKhauMoi.Text);

                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.GetInt32(0) == 1)
                    {
                        /*lblShowInfor.ForeColor = System.Drawing.Color.Blue;
                        lblShowInfor.Text = dr.GetString(1);*/
                        txtXacNhanMK.Text = "";
                        txtMatKhau.Text = "";
                        txtMatKhauMoi.Text = "";
                        txtMatKhau.Focus();
                    }
                    else
                    {
                        /*lblShowInfor.ForeColor = System.Drawing.Color.Red;
                        lblShowInfor.Text = dr.GetString(1);*/
                        txtMatKhau.Focus();
                        txtMatKhau.SelectAll();
                    }
                    dr.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            
        }

        private void txtThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
