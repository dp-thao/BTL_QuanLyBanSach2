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
    public partial class TimKiem_Sach : Form
    {
        public TimKiem_Sach()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cbSach_TacGia.Text == "") && (cbSach_TheLoai.Text == "") && (cbSach_NXB.Text == ""))
                {
                    MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string sql = "SELECT ROW_NUMBER() OVER (ORDER BY tblSach.sMaSach) AS [STT], sTenSach AS[Tên sách], sTenTL AS[Tên thể loại], sTenTG AS[Tên tác giả], sTenNXB AS[Tên NXB] from tblSach join tblTacGia on tblTacGia.sMaTG = tblSach.sMaTG join tblTheLoai on tblTheLoai.sMaTL = tblSach.sMaTL join tblNhaXuatBan on tblNhaXuatBan.sMaNXB = tblSach.sMaNXB where 1 = 1";
                if (cbSach_TacGia.Text != "")
                {
                    sql = sql + " AND tblTacGia.sTenTG Like N'%" + cbSach_TacGia.Text + "%'";
                }
                if (cbSach_TheLoai.Text != "")
                {
                    sql = sql + " AND tblTheLoai.sTenTL Like N'%" + cbSach_TheLoai.Text + "%'";
                }
                if (cbSach_NXB.Text != "")
                {
                    sql = sql + " AND tblNhaXuatBan.sTenNXB Like N'%" + cbSach_NXB.Text + "%'";
                }

                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                SqlCommand cmd = new SqlCommand(constr, conn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = cmd;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvDSSach.DataSource = dataTable;
                }

                cbSach_NXB.Text = "";
                cbSach_TheLoai.Text = "";
                cbSach_TacGia.Text = "";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Hàm hiện danh sách Tên tác giả vào ComboBox
        public void hienDS_Ten_TacGia()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tblTacGia", conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                cbSach_TacGia.DataSource = dataTable;
                cbSach_TacGia.DisplayMember = "sTenTG";
                cbSach_TacGia.ValueMember = "sTenTG";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        
        // Hàm hiện danh sách Tên nhà xuất bản vào ComboBox
        public void hienDS_Ten_NXB()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbSach_TacGia_Click(object sender, EventArgs e)
        {
            hienDS_Ten_TacGia();
        }

        private void cbSach_TheLoai_Click(object sender, EventArgs e)
        {
            hienDS_Ten_TheLoai();
        }

        private void cbSach_NXB_Click(object sender, EventArgs e)
        {
            hienDS_Ten_NXB();
        }
    }
}
