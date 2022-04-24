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
    public partial class TimKiem_LoaiSach : Form
    {
        public TimKiem_LoaiSach()
        {
            InitializeComponent();
        }

        // Hàm hiện danh sách Tên nhà xuất bản vào ComboBox
        public void hienDS_Ten_TheLoai()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tblTheLoai", conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                cbSach_TheLoai.DataSource = dataTable;
                cbSach_TheLoai.DisplayMember = "sTenTL";
                cbSach_TheLoai.ValueMember = "sTenTL";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sự kiện Form load
        private void TimKiem_LoaiSach_Load(object sender, EventArgs e)
        {
            hienDS_Ten_TheLoai();
        }

        // sự kiện button tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                string tenNXB = cbSach_TheLoai.SelectedValue.ToString();

                SqlCommand cmd = new SqlCommand(constr, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.Proc_TimKiem_Sach_sTenTL";
                cmd.Parameters.AddWithValue("@TenTL", tenNXB);

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Close();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    dgvDSSach_TheLoai.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy");
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
