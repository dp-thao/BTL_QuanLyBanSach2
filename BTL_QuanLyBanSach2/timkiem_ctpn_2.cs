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
    public partial class timkiem_ctpn_2 : Form
    {
        public timkiem_ctpn_2()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
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
        }
    }
}
