using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BTL_QuanLyBanSach2
{
    public partial class BaoCao_PhieuNhap : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
        SqlConnection connection;
        SqlCommand command;

        public BaoCao_PhieuNhap()
        {
            InitializeComponent();
        }

        public void ketnoi()
        {
            connection = new SqlConnection(constr);
            connection.Open();
        }

        public void ngatketnoi()
        {
            connection.Close();
        }

        private DataTable get_cbphieunhap()
        {
            command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM tblPhieuNhap";
            using (SqlDataAdapter da = new SqlDataAdapter(command))
            {
                DataTable dt = new DataTable("tblPhieuNhap");
                da.Fill(dt);
                return dt;
            }
        }

        public void HienDS_ComboBox_PhieuNhap()
        {
            try
            {
                ketnoi();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tblPhieuNhap", connection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                cb_soPhieuNhap.DisplayMember = "sSoPN";
                cb_soPhieuNhap.ValueMember = "sSoPN";
                cb_soPhieuNhap.DataSource = dataTable;
                ngatketnoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void showReportPN(string rpname, string rptitle)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(@"D:\DaiHocMoHaNoi\HKII.2021-2022\LapTrinhHuongSuKien\BTL_QuanLyBanSach\BTL_QuanLyBanSach2\BTL_QuanLyBanSach2\Reports\BaoCao_PhieuNhap.rpt");

            TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
            tableLogOnInfo.ConnectionInfo.ServerName = @"DESKTOP-MQPJKPQ\SQLEXPRESS";
            tableLogOnInfo.ConnectionInfo.DatabaseName = "BTL_QuanLyBanSach";
            tableLogOnInfo.ConnectionInfo.IntegratedSecurity = true;
            foreach (Table table in rpt.Database.Tables)
                table.ApplyLogOnInfo(tableLogOnInfo);
            //rpt.SummaryInfo.ReportTitle = rptitle;
            ParameterFieldDefinition pfd = rpt.DataDefinition.ParameterFields["@soPN"];
            ParameterValues pvl = new ParameterValues();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pdv.Value = cb_soPhieuNhap.SelectedValue.ToString();
            pvl.Add(pdv);
            pfd.CurrentValues.Clear();
            pfd.ApplyCurrentValues(pvl);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }

        private void BaoCao_PhieuNhap_Load(object sender, EventArgs e)
        {
            HienDS_ComboBox_PhieuNhap();
            load_DS_CTPN_LapPhieu();
        }

        private void btn_inPhieuNhap_Click(object sender, EventArgs e)
        {
            if(cb_soPhieuNhap.Text == "")
            {
                MessageBox.Show("Vui lòng chọn số phiếu nhập cần in", "Thông báo");
            }
            else
            {
                showReportPN("BaoCao_PhieuNhap.rpt", "Quản lý bán sách");
            }
        }

        public void load_DS_CTPN_LapPhieu()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["BTL_QuanLyBanSach"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();

                SqlCommand cmd = new SqlCommand(constr, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.proc_BC_TheoThang";
                cmd.Parameters.AddWithValue("@Thang", txtThang.Text);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = cmd;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dgvDanhSach.DataSource = dataTable;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIN_Click(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(@"D:\DaiHocMoHaNoi\HKII.2021-2022\LapTrinhHuongSuKien\BTL_QuanLyBanSach\BTL_QuanLyBanSach2\BTL_QuanLyBanSach2\Reports\BaoCao_TheoThang.rpt");

            TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
            tableLogOnInfo.ConnectionInfo.ServerName = @"DESKTOP-MQPJKPQ\SQLEXPRESS";
            tableLogOnInfo.ConnectionInfo.DatabaseName = "BTL_QuanLyBanSach";
            tableLogOnInfo.ConnectionInfo.IntegratedSecurity = true;
            foreach (Table table in rpt.Database.Tables)
                table.ApplyLogOnInfo(tableLogOnInfo);
            //rpt.SummaryInfo.ReportTitle = rptitle;
            ParameterFieldDefinition pfd = rpt.DataDefinition.ParameterFields["@Thang"];
            ParameterValues pvl = new ParameterValues();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pdv.Value = txtThang.Text;
            pvl.Add(pdv);
            pfd.CurrentValues.Clear();
            pfd.ApplyCurrentValues(pvl);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
            load_DS_CTPN_LapPhieu();
        }
    }
}

//select tblSach.sMaSach as [Mã sách], sTenSach as [Tên sách], fSoLuongNhap as [SL nhập], fGiaNhap as [Giá nhập], dNgayNhap as [Ngày nhập], (fSoLuongNhap * fGiaNhap) as [Thành tiền]
