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
    public partial class DS_CTPN : Form
    {
        public DS_CTPN()
        {
            InitializeComponent();
        }

        private void dgvDS_CTPN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DS_CTPN_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM vwDS_Ma_CTPN", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgvDS_CTPN.DataSource = dataTable;
            conn.Close();
        }
    }
}
