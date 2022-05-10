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
    public partial class ComboBox_List : Form
    {
        public ComboBox_List()
        {
            InitializeComponent();
        }

        // Hàm hiện danh sách Sách vào ComboBox
        public void HienDS_ComboBox_Sach()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT sTenSach FROM tblSach", conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                cbTenSach.DisplayMember = "sTenSach";
                cbTenSach.ValueMember = "sTenSach";
                cbTenSach.DataSource = dataTable;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBox_List_Load(object sender, EventArgs e)
        {
            HienDS_ComboBox_Sach();
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            int n = cbTenSach.Items.Count;
            for (int i = 0; i < n; i++)
            {
                string ten = ((DataRowView)cbTenSach.Items[i])["sTenSach"].ToString();
                listTenSach.Items.Add(ten);
            }
        }

        // Kiểm tra ký tự nhập vào đủ yêu cầu: hàm kiểm tra một xâu có thỏa mãn ít nhất 1 kí tự in hoa, 1 chữ số, 1 kí tự đặc biêt
        public enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }

        public class PasswordAdvisor
        {
            public static PasswordScore CheckStrength(string password)
            {
                int score = 0;

                if (password.Length < 1)
                    return PasswordScore.Blank;
                if (password.Length < 4)
                    return PasswordScore.VeryWeak;

                if (password.Length >= 8)
                    score++;
                if (password.Length >= 12)
                    score++;
                if (Regex.Match(password, @"/\d+/", RegexOptions.ECMAScript).Success)
                    score++;
                if (Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success &&
                  Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
                    score++;
                if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
                    score++;

                return (PasswordScore)score;
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
                   && password.Length > 7;
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            String password = txtMatKhau.Text; // Substitute with the user input string
            if (CheckPass(password))
            {
                MessageBox.Show("Thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }
        }

        // Tạo mật khẩu random
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var passwordRandom = GeneratePassword(chk_lowercase.Checked, chkUppercase.Checked, chkNumbers.Checked, chkSpecial.Checked, int.Parse(txtlength.Text));
            txt_password.Text = passwordRandom;
        }

        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "123456789";
        const string SPECIALS = @"!@£$%^&*()#€";


        public string GeneratePassword(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial,
            int passwordSize)
        {
            char[] _password = new char[passwordSize];
            string charSet = "";
            System.Random _random = new Random();
            int counter;


            if (useLowercase) charSet += LOWER_CASE;

            if (useUppercase) charSet += UPPER_CASE;

            if (useNumbers) charSet += NUMBERS;

            if (useSpecial) charSet += SPECIALS;

            for (counter = 0; counter < passwordSize; counter++)
            {
                _password[counter] = charSet[_random.Next(charSet.Length - 1)];
            }

            return string.Join(null, _password);
        }

    }
}
