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

public partial class Stores_ReportStaffProductIssue : System.Web.UI.Page
{
    BusinessLayer.StaffBL objStaff = new StaffBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnReport.Attributes.Add("onclick", "javascript:return validate();");
        ds = new DataSet();
        if (!IsPostBack)
        {
            ds = objStaff.GetStaffDetails(0);
            ddlStaff.DataSource = ds.Tables[0];
            ddlStaff.DataTextField = "FullName";
            ddlStaff.DataValueField = "StaffID";
            ddlStaff.DataBind();
            ddlStaff.Items.Insert(0, new ListItem("---Select---", "0"));
        }


    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string Staff = string.Empty;
        string FromDate = string.Empty;
        string ToDate = string.Empty;

        Staff = ddlStaff.Items[ddlStaff.SelectedIndex].Value;
        if (txtFromDate.Text != "")
            FromDate = ChangeDateFormat(txtFromDate.Text);
        if (txtToDate.Text != "")
            ToDate = ChangeDateFormat(txtToDate.Text);

        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString());
        MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString() + "StaffProdIssue";
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;
        MyReportViewer.SizeToReportContent = true;
        Microsoft.Reporting.WebForms.ReportParameter[] NewProcurementParam = new Microsoft.Reporting.WebForms.ReportParameter[3];
        NewProcurementParam[0] = new Microsoft.Reporting.WebForms.ReportParameter("Staff", Staff);
        NewProcurementParam[1] = new Microsoft.Reporting.WebForms.ReportParameter("Fromdate", FromDate);
        NewProcurementParam[2] = new Microsoft.Reporting.WebForms.ReportParameter("Todate", ToDate);
        MyReportViewer.ServerReport.SetParameters(NewProcurementParam);
        MyReportViewer.ServerReport.Refresh();
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
}
