using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BusinessLayer;
public partial class student_ReportStaffBookReturn : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.StaffBL objStaff = new StaffBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = objStaff.GetStaffDetails(0);
            ddlStaff.DataSource = ds.Tables[0];
            ddlStaff.DataTextField = "FullName";
            ddlStaff.DataValueField = "StaffID";
            ddlStaff.DataBind();
            ddlStaff.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }
    protected void btnGetReport_Click(object sender, EventArgs e)
    {
        
        string Staff = string.Empty;
        string ReturnFromDate = string.Empty;
        string ReturnToDate = string.Empty;
        string PaymentFromDate = string.Empty;
        string PaymentToDate = string.Empty;

        Staff = ddlStaff.Items[ddlStaff.SelectedIndex].Value;
        if (txtReturnFromDate.Text != "")
            ReturnFromDate = ChangeDateFormat(txtReturnFromDate.Text);
        if (txtReturnToDate.Text != "")
            ReturnToDate = ChangeDateFormat(txtReturnToDate.Text);
        if (txtPaymentFromDate.Text != "")
            PaymentFromDate = ChangeDateFormat(txtPaymentFromDate.Text);
        if (txtPaymentToDate.Text != "")
            PaymentToDate = ChangeDateFormat(txtPaymentToDate.Text);
        

        StaffBookReturnReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        StaffBookReturnReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
        StaffBookReturnReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString()+ "StaffBookReturn";
        StaffBookReturnReportViewer.ShowParameterPrompts = false;
        StaffBookReturnReportViewer.ShowPrintButton = true;
        StaffBookReturnReportViewer.ShowToolBar = true;
        StaffBookReturnReportViewer.SizeToReportContent = true;
        Microsoft.Reporting.WebForms.ReportParameter[] StaffBookReturnParam = new Microsoft.Reporting.WebForms.ReportParameter[5];
        StaffBookReturnParam[0] = new Microsoft.Reporting.WebForms.ReportParameter("Staff", Staff);
        StaffBookReturnParam[1] = new Microsoft.Reporting.WebForms.ReportParameter("ReturnFromDate", ReturnFromDate);
        StaffBookReturnParam[2] = new Microsoft.Reporting.WebForms.ReportParameter("ReturnToDate", ReturnToDate);
        StaffBookReturnParam[3] = new Microsoft.Reporting.WebForms.ReportParameter("PaymentFromDate", PaymentFromDate);
        StaffBookReturnParam[4] = new Microsoft.Reporting.WebForms.ReportParameter("PaymentToDate", PaymentToDate);
        StaffBookReturnReportViewer.ServerReport.SetParameters(StaffBookReturnParam);
        StaffBookReturnReportViewer.ServerReport.Refresh();
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
}
