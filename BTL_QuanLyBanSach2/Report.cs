using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace BTL_QuanLyBanSach2
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void DSHoaDonNhapSach_Load(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(@"D:\DaiHocMoHaNoi\HKII.2021-2022\LapTrinhHuongSuKien\BTL_QuanLyBanSach\BTL_QuanLyBanSach2\BTL_QuanLyBanSach2\Reports\HoaDonNhapSach.rpt");
            // Lọc bản ghi theo Số lượng nhập = 10
            //rpt.RecordSelectionFormula = "{tblChiTietPhieuNhap.fSoLuongNhap} = 10";

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();


        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnSLNhap_Click(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(@"D:\DaiHocMoHaNoi\HKII.2021-2022\LapTrinhHuongSuKien\BTL_QuanLyBanSach\BTL_QuanLyBanSach2\BTL_QuanLyBanSach2\HoaDonNhapSach.rpt");
            ParameterFieldDefinition pdf = rpt.DataDefinition.ParameterFields[""];
            //tập parameterValues mới; thư viện CystalDecision.Shared
            ParameterValues pv = new ParameterValues();
            //value mới
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pdv.Value = txtSLNhap.Text;
            //thêm vào tập hợp ParameterValues
            pv.Add(pdv);
            //dùng tập value mới
            pdf.CurrentValues.Clear();
            pdf.ApplyCurrentValues(pv);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
