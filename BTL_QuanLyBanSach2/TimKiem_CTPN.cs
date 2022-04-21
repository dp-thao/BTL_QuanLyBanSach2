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
    public partial class TimKiem_CTPN : Form
    {
        public TimKiem_CTPN()
        {
            InitializeComponent();
        }

        // Hàm load dánh sách
        public void load_DS_CTPN_LapPhieu()
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            SqlCommand cmd = new SqlCommand(constr, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.Proc_TimKiem_PhieuNhapSach_NgayNhap";
            cmd.Parameters.AddWithValue("@NgayNhap", dateNgayNhap.Text);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvDS_PhieuNhapSach.DataSource = dataTable;

            conn.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            load_DS_CTPN_LapPhieu();
        }
    }
}
