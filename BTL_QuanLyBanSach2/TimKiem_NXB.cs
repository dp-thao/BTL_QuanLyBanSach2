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
    public partial class TimKiem_NXB : Form
    {
        public TimKiem_NXB()
        {
            InitializeComponent();
        }

        // Hàm hiện danh sách Tên nhà xuất bản vào ComboBox
        public void hienDS_Ten_NXB()
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tblNhaXuatBan", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            cbSach_NXB.DataSource = dataTable;
            cbSach_NXB.DisplayMember = "sTenNXB";
            cbSach_NXB.ValueMember = "sTenNXB";

            conn.Close();
        }

        // Sự kiện Form load
        private void TimKiem_NXB_Load(object sender, EventArgs e)
        {
            hienDS_Ten_NXB();
        }

        // Hàm hiển thị danh sách Sách theo Tên nhà xuất bản
        public void load_DS_NXB()
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            string tenNXB = cbSach_NXB.SelectedValue.ToString();

            SqlCommand cmd = new SqlCommand(constr, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.Proc_TimKiem_Sach_sTenNXB";
            cmd.Parameters.AddWithValue("@TenNXB", tenNXB);

            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Close();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dgvDSSach_NXB.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Không tìm thấy");
            }
            
            conn.Close();
        }

        // Sự kiện tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            load_DS_NXB();
        }
    }
}
