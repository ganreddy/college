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

public partial class Library_ReportStaffBookIssue : System.Web.UI.Page
{
    BusinessLayer.StaffBL objStaff = new StaffBL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnReport.Attributes.Add("onclick", "javascript:return validate();");
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
        string FullName = string.Empty, IssueFromDate = string.Empty, IssueToDate = string.Empty, DueFromDate = string.Empty, DueToDate = string.Empty;
        FullName = ddlStaff.Items[ddlStaff.SelectedIndex].Value;
        if (txtIssueFromDate.Text != "")
            IssueFromDate = ChangeDateFormat(txtIssueFromDate.Text);
        if (txtIssueToDate.Text != "")
            IssueToDate = ChangeDateFormat(txtIssueToDate.Text);
        if (txtDueFromDate.Text != "")
            DueFromDate = ChangeDateFormat(txtDueFromDate.Text);
        if (txtDueToDate.Text != "")
            DueToDate = ChangeDateFormat(txtDueToDate.Text);


        MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        MyReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportsURI"].ToString()); // Report Server URL
        MyReportViewer.ServerReport.ReportPath = ConfigurationManager.AppSettings["ReportsFolder"].ToString()+ "StaffBookIssue"; // Report Name
        MyReportViewer.ShowParameterPrompts = false;
        MyReportViewer.ShowPrintButton = true;
        MyReportViewer.ShowToolBar = true;
        MyReportViewer.SizeToReportContent = true;
        // Below code demonstrate the Parameter passing method. User only if you have parameters into the reports.

        Microsoft.Reporting.WebForms.ReportParameter[] reportParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[5];
        reportParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter("Staff", FullName);
        reportParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter("IssueFromDate", IssueFromDate);
        reportParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter("IssueToDate", IssueToDate);
        reportParameterCollection[3] = new Microsoft.Reporting.WebForms.ReportParameter("DueFromDate", DueFromDate);
        reportParameterCollection[4] = new Microsoft.Reporting.WebForms.ReportParameter("DueToDate", DueToDate);

        MyReportViewer.ServerReport.SetParameters(reportParameterCollection);

        MyReportViewer.ServerReport.Refresh();
    }

    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    
}


